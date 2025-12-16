using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.DTOs.CreateDTOs;
using Library.Application.DTOs.ResponseDTOs;
using Library.Application.DTOs.UpdateDTOs;

namespace Library.Application.Interfaces.InterfaceService
{
    public interface ILoanService
    {
        Task<bool> CreateAsync(LoanCreateDTO loanDTO);
        Task<IEnumerable<LoanDTO>> GetAllAsync();
        Task<LoanDTO?> GetByLoanIdAsync(int id_loan);
        Task<IEnumerable<LoanDTO?>> GetByUserIdAsync(int id_user);
        Task<bool> UpdateAsync(LoanUpdateDTO loanDTO);
        Task<int> ReturnBookAsync(int id_loan);
        Task<bool> ExtendLoan(int id_loan);
    }
}
