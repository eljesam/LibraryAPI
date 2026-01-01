using LibraryAPI.Application.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace LibraryAPI.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _libraryDbContext;
    
    public BookRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }
    
    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _libraryDbContext.Books.ToListAsync();
    }
    
    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _libraryDbContext.Books.FindAsync(id);
    }
    
    public async Task AddAsync(Book book)
    {
        await _libraryDbContext.Books.AddAsync(book);
        await _libraryDbContext.SaveChangesAsync();
    }
    public async Task UpdateAsync(Book book)
    {
        _libraryDbContext.Books.Update(book);
        await _libraryDbContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(Book book)
    {
        _libraryDbContext.Books.Remove(book);
        await _libraryDbContext.SaveChangesAsync();
    }
}