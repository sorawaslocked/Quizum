namespace Quizum.Models.Entities.Identity;

[EntityTypeConfiguration(typeof(AppUserLoginConfiguration))]
public class AppUserLogin : IdentityUserLogin<int>
{
}