namespace LibraryAPI.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public int CopiesAvailable { get; set; }
    public int TotalCopies { get; set; }
    
    public ICollection<Loan> Loans { get; set; }
}