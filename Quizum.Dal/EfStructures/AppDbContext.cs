namespace Quizum.Dal.EfStructures;

public class AppDbContext
    : IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        new AppRoleClaimConfiguration().Configure(builder.Entity<AppRoleClaim>());
        new AppRoleConfiguration().Configure(builder.Entity<AppRole>());
        new AppUserClaimConfiguration().Configure(builder.Entity<AppUserClaim>());
        new AppUserConfiguration().Configure(builder.Entity<AppUser>());
        new AppUserLoginConfiguration().Configure(builder.Entity<AppUserLogin>());
        new AppUserRoleConfiguration().Configure(builder.Entity<AppUserRole>());
        new AppUserTokenConfiguration().Configure(builder.Entity<AppUserToken>());
    }
}