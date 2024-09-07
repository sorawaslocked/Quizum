namespace Quizum.Models.Entities.Configuration.Identity;

public class AppUserTokenConfiguration : IEntityTypeConfiguration<AppUserToken>
{
    public void Configure(EntityTypeBuilder<AppUserToken> builder)
    {
        builder.ToTable("AppUserTokens", "Identity");
    }
}