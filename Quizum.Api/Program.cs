var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Quizum");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(connectionString));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    if (app.Configuration.GetValue<bool>("RebuildDatabase"))
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
        var userManager = scope.ServiceProvider.GetService<UserManager<AppUser>>();
        var roleManager = scope.ServiceProvider.GetService<RoleManager<AppRole>>();
        await DatabaseInitializer.ClearAndReseedDatabase(dbContext, userManager, roleManager);
    }
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();