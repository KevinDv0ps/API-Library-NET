using Library.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Book>> GetAsync();
        Task<IEnumerable<Loan>> GetAsyncByUrserId(int id_user);
        Task<Loan> GetAsyncByLoanId (int id_loan);
        Task<Loan> PosAsync (Loan loan);
        Task<bool> IsBookAvailable(int id_book);
    }
}
