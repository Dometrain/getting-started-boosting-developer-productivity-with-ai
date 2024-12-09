namespace AIDemoLibrary;

public class Person
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName => $"{FirstName} {LastName}";
    public string? Email { get; set; }

    // Generate a constructor for all parameters in the class 

    public Person(string? firstName, string? lastName, string? email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

}
