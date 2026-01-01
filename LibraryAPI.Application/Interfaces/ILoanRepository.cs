using LibraryAPI.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace LibraryAPI.Application.Interfaces;

public interface ILoanRepository
{
Task<IEnumerable<Loan>> GetAllAsync();
Task<Loan?> GetLoanByIdAsync(int id);
Task AddLoanAsync(Loan loan);
Task UpdateLoanAsync(Loan loan);
Task DeleteLoanAsync(Loan loan);
}