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
        Task<IEnumerable<Loan>> GetAllAsync();
        Task<IEnumerable<Loan>> GetByUserIdAsync(int id_user);
        Task<Loan?> GetByLoanIdAsync(int id_loan);
        Task CreateAsync (Loan loan);

        // Extender fecha de devolución
        Task ExtendDueDateAsync(int id_loan, DateTime newDueDate);

        // Marcar como devuelto (registrar la devolución)
        Task MarkAsReturnedAsync(int id_loan);

        // Verificar si un préstamo ya fue devuelto
        Task<bool> IsReturnedAsync(int id_loan);
    }
}
