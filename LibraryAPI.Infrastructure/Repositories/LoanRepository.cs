using LibraryAPI.Application.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace LibraryAPI.Infrastructure.Repositories;

public class LoanRepository: ILoanRepository
{
    private readonly LibraryDbContext _context;
    public LoanRepository(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Loan>> GetLoansAsync()
    {
        return await _context.Loans
            .Include(l => l.Book)
            .Include(l => l.User)
            .ToListAsync();
    }

    public Task<IEnumerable<Loan>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Loan?> GetLoanByIdAsync(int id)
    {
        return await _context.Loans
            .Include(l => l.Book)
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task AddLoanAsync(Loan loan)
    {
        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateLoanAsync(Loan loan)
    {
        _context.Loans.Update(loan);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLoanAsync(Loan loan)
    {
        _context.Loans.Remove(loan);
        await _context.SaveChangesAsync();
    }
}