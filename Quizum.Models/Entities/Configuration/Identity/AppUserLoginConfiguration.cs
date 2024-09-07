namespace Quizum.Models.Entities.Configuration.Identity;

public class AppUserLoginConfiguration : IEntityTypeConfiguration<AppUserLogin>
{
    public void Configure(EntityTypeBuilder<AppUserLogin> builder)
    {
        builder.ToTable("AppUserLogins", "Identity");
    }
}