namespace LibraryAPI.Domain.Entities;

public class User
{
    public int Id { get; set; }
    
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    
    public String Role { get; set; } = "User"; // Possible roles: User, Admin
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public ICollection<Loan> Loans { get; set; }
}