namespace Quizum.Models.Entities.Identity;

[EntityTypeConfiguration(typeof(AppRoleClaimConfiguration))]
public class AppRoleClaim : IdentityRoleClaim<int>
{
}