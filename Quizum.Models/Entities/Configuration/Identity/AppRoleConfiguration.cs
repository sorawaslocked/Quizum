namespace Quizum.Models.Entities.Configuration.Identity;

public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.ToTable("AppRoles", "Identity");

        builder.Property(r => r.Name).HasMaxLength(64);
        builder.Property(r => r.NormalizedName).HasMaxLength(64);
    }
}