namespace Quizum.Models.Entities.Configuration.Identity;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("AppUsers", "Identity");
        
        builder.Property(u => u.UserName).HasMaxLength(64);
        builder.Property(u => u.NormalizedUserName).HasMaxLength(64);
        builder.Property(u => u.Email).HasMaxLength(64);
        builder.Property(u => u.NormalizedEmail).HasMaxLength(64);
        builder.Property(u => u.PhoneNumber).HasMaxLength(40);
    }
}