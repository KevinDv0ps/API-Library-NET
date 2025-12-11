using Library.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces.InterfaceRepository
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAllAsync();
        Task<IEnumerable<Loan>> GetByUserIdAsync(int id_user);
        Task<Loan?> GetByLoanIdAsync(int id_loan);
        Task CreateAsync (Loan loan);
        Task UpdateAsync (Loan loan);
    }
}
