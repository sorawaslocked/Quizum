namespace Quizum.Models.Entities.Configuration.Identity;

public class AppUserClaimConfiguration : IEntityTypeConfiguration<AppUserClaim>
{
    public void Configure(EntityTypeBuilder<AppUserClaim> builder)
    {
        builder.ToTable("AppUserClaims", "Identity");
    }
}