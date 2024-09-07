namespace Quizum.Models.Entities.Identity;

[EntityTypeConfiguration(typeof(AppUserTokenConfiguration))]
public class AppUserToken : IdentityUserToken<int>
{
}