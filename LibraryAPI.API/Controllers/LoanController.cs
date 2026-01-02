using System;
using System.Threading.Tasks;
using LibraryAPI.Application.Interfaces;
using LibraryAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;



[Authorize]
[ApiController]
[Route("api/loans")]

public class LoanController : ControllerBase
{
    private readonly ILoanRepository _loanRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBookRepository _bookRepository;
    
    public LoanController(ILoanRepository loanRepository, IUserRepository userRepository, IBookRepository bookRepository)
    {
        _loanRepository = loanRepository;
        _userRepository = userRepository;
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _loanRepository.GetAllAsync());
    }

    [HttpPost("borrow")]
    public async Task<IActionResult> BorrowBook(int userId, int bookId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        var book = await _bookRepository.GetByIdAsync(bookId);
        if (user == null || book == null)
        {
            return NotFound("Invalid user or book, or no available copies.");
        }
        if(book.CopiesAvailable <= 0)
        {
            return BadRequest("No available copies of the book.");
        }

        book.CopiesAvailable--;
        var loan = new Loan
        {
            UserId = userId,
            BookId = bookId,
            LoanDate = DateTime.UtcNow,
            DueDate = DateTime.UtcNow.AddDays(14)
        };

        await _loanRepository.AddLoanAsync(loan);
        await _bookRepository.UpdateAsync(book);
        return Ok(loan);

    }
    [HttpPost("return/{loanId}")]
    
    public async Task<IActionResult> ReturnBook(int loanId)
    {
        var loan = await _loanRepository.GetLoanByIdAsync(loanId);
        if (loan == null)
        {
            return NotFound("Loan not found.");
        }

        var book = await _bookRepository.GetByIdAsync(loan.BookId);
        if (book != null)
        {
            book.CopiesAvailable++;
            await _bookRepository.UpdateAsync(book);
        }

        await _loanRepository.UpdateLoanAsync(loan);
        await _bookRepository.UpdateAsync(book);
        return Ok("Book returned successfully.");
    }

}