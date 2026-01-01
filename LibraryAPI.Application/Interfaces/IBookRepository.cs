using LibraryAPI.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace LibraryAPI.Application.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book> GetByIdAsync(int id);
    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task DeleteAsync(Book book);

}
