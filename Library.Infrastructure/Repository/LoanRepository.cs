using Library.Application.Interfaces.InterfaceRepository;
using Library.Entities;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repository
{
    public class LoanRepository: ILoanRepository
    {
        private readonly DataContextLibrary dataContextLibrary;
        public LoanRepository(DataContextLibrary context)
        {
            dataContextLibrary = context;
        }
        public async Task CreateAsync(Loan loan)
        {
            dataContextLibrary.Loans.Add(loan);
            await dataContextLibrary.SaveChangesAsync();
        }
        public async Task<IEnumerable<Loan>> GetAllAsync()
        {
            return await dataContextLibrary.Loans
                .Include(l => l.book)
                .Include(l => l.user)
                .ToListAsync();
        }
        public async Task<Loan?> GetByLoanIdAsync(int id_loan)
        {
            return await dataContextLibrary.Loans
                .Include(l => l.book)
                .Include(l => l.user)
                .FirstOrDefaultAsync(a => a.id == id_loan);
        }
        public async Task<IEnumerable<Loan>> GetByUserIdAsync(int id_user)
        {
            return await dataContextLibrary.Loans
                .Include(l => l.book)
                .Include(l => l.user)
                .Where(c =>c.id_user == id_user)
                .ToListAsync();
        }
        public async Task UpdateAsync(Loan loan)
        {
            dataContextLibrary.Loans.Update(loan);
            await dataContextLibrary.SaveChangesAsync();
        }
    }
}
