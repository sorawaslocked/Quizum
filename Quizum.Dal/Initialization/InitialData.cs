namespace Quizum.Dal.Initialization;

public static class InitialData
{
    public static List<RegisterUser> AppUsers => new()
    {
        new()
        {
            UserName = "admin",
            Email = "admin@mail.com",
            Password = "!Administrator1",
            FirstName = "Admin",
            LastName = "Admin"
        },
        new()
        {
            UserName = "unclebob",
            Email = "uncbob@mail.com",
            Password = "!Cl3anc0de",
            FirstName = "Robert",
            LastName = "Martin"
        }
    };

    public static List<string> AppRoleNames => new()
    {
        "Admin",
        "User"
    };
}