namespace Quizum.Models.Entities.Identity;

[EntityTypeConfiguration(typeof(AppUserClaimConfiguration))]
public class AppUserClaim : IdentityUserClaim<int>
{
}