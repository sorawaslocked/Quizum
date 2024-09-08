namespace Quizum.Dal.Initialization;

public static class DatabaseInitializer
{
    private static void DropAndCreateDatabase(AppDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.Migrate();
    }

    private static void ClearDatabase(AppDbContext context)
    {
        var entityNames = new[]
        {
            typeof(AppRole).FullName,
            typeof(AppRoleClaim).FullName,
            typeof(AppUser).FullName,
            typeof(AppUserClaim).FullName,
            typeof(AppUserLogin).FullName,
            typeof(AppUserRole).FullName,
            typeof(AppUserToken).FullName
        };

        foreach (var entityName in entityNames)
        {
            var entity = context.Model.FindEntityType(entityName);
            var tableName = entity?.GetTableName();
            var schemaName = entity?.GetSchema();

            context.Database.ExecuteSqlRaw($"TRUNCATE \"{schemaName}\".\"{tableName}\" RESTART IDENTITY CASCADE");
        }
    }

    private static async Task SeedRoles(RoleManager<AppRole> roleManager)
    {
        foreach (var appRoleName in InitialData.AppRoleNames)
        {
            AppRole appRole = new()
            {
                Name = appRoleName,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            await roleManager.CreateAsync(appRole);
        }
    }

    private static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        await SeedRoles(roleManager);
        
        foreach (var appUser in InitialData.AppUsers)
        {
            AppUser user = new()
            {
                UserName = appUser.UserName,
                Email = appUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = appUser.FirstName,
                LastName = appUser.LastName
            };

            var createUserResult = await userManager.CreateAsync(user, appUser.Password);

            if (!createUserResult.Succeeded)
            {
                return;
            }

            if (user.UserName == "admin")
            {
                await userManager.AddToRolesAsync(user, new []{ "Admin", "User" });
                continue;
            }

            await userManager.AddToRoleAsync(user, "User");
        }
    }
    
    public static async Task InitializeDatabase(
        AppDbContext context,
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager)
    {
        DropAndCreateDatabase(context);
        await SeedData(userManager, roleManager);
    }
    
    public static async Task ClearAndReseedDatabase(
        AppDbContext context,
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager)
    {
        ClearDatabase(context);
        await SeedData(userManager, roleManager);
    }

    public static async Task InitializeDatabaseWithRolesOnly(
        AppDbContext context,
        RoleManager<AppRole> roleManager)
    {
        DropAndCreateDatabase(context);
        await SeedRoles(roleManager);
    }

    public static async Task ClearAndReseedDatabaseWithRolesOnly(
        AppDbContext context,
        RoleManager<AppRole> roleManager)
    {
        ClearDatabase(context);
        await SeedRoles(roleManager);
    }
}