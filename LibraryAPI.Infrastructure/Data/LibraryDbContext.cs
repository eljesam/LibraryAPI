using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Infrastructure.Data;


public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }
    
    public DbSet<Book> Books  => Set<Book>();
    public DbSet<User> Users  => Set<User>();
    public DbSet<Loan> Loans  => Set<Loan>();
}