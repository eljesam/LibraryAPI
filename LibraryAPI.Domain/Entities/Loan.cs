namespace LibraryAPI.Domain.Entities;

public class Loan
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    public int BookId { get; set; }
    
    public User User { get; set; }
    public Book Book { get; set; }
    
    public DateTime LoanDate { get; set; } = DateTime.UtcNow;
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    
    public string Status { get; set; } = "Borrowed"; // Possible statuses: Borrowed, Returned, Overdue
    
}