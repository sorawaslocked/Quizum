namespace Quizum.Models.Entities.Identity;

public class AppUser : IdentityUser<int>
{
    [Required, StringLength(50)]
    public string FirstName { get; set; }
    
    [Required, StringLength(50)]
    public string LastName { get; set; }
}