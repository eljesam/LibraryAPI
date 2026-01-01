using LibraryAPI.Application.Interfaces;
using LibraryAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/books")]



public class BooksControllers :ControllerBase
{
    private readonly IBookRepository _repository;
    
    public BooksControllers(IBookRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _repository.GetAllAsync();
        return Ok(books);

    }
    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] Book book)
    {
        await _repository.AddAsync(book);
        return CreatedAtAction(nameof(GetAllBooks), new { id = book.Id }, book);
    }
}