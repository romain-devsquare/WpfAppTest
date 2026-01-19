namespace WpfAppTest.Domain.Users.Model;

public class User
{
    public Guid Id { get; }
    public string Name { get; }
    public string Email { get; }

    public User(string name, string email)
    {
        // Some simple domain validation
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required", nameof(name));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required", nameof(email));

        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }
}