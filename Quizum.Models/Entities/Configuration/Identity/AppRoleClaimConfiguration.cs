namespace Quizum.Models.Entities.Configuration.Identity;

public class AppRoleClaimConfiguration : IEntityTypeConfiguration<AppRoleClaim>
{
    public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
    {
        builder.ToTable("AppRoleClaims", "Identity");
    }
}