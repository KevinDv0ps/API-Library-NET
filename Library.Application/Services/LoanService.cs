using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.DTOs.CreateDTOs;
using Library.Application.DTOs.ResponseDTOs;
using Library.Application.DTOs.UpdateDTOs;
using Library.Application.Interfaces.InterfaceRepository;
using Library.Application.Interfaces.InterfaceService;
using Library.Entities;

namespace Library.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public LoanService(ILoanRepository loanRepository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public async Task<bool> CreateAsync(LoanCreateDTO loanDTO)
        {
            var user = await _userRepository.GetByIdAsync(loanDTO.id_user);
            if (user == null) throw new Exception("User does not exist");

            var book = await _bookRepository.GetByIdAsync(loanDTO.id_book);
            if (book == null) throw new Exception("Book does not exist");

            if (!book.is_available) throw new Exception("Book is not available");

            var loan = new Loan
            {
                id_user = loanDTO.id_user,
                id_book = loanDTO.id_book,
                loan_date = DateTime.Now,
                due_date = DateTime.Now.AddDays(14),
                is_return = false,
                return_date = null,
            };

            await _loanRepository.CreateAsync(loan);

            book.is_available = false;
            await _bookRepository.UpdateAsync(book);

            return true;
        }

        public async Task<IEnumerable<LoanDTO>> GetAllAsync()
        {
            var loans = await _loanRepository.GetAllAsync();
            return loans.Select(loan => new LoanDTO
            {
                id_loan = loan.id,
                id_user = loan.id_user,
                id_book = loan.id_book,
                loan_date = loan.loan_date,
                due_date = loan.due_date,
                return_date = loan.return_date,
                is_return = loan.is_return
            });
        }

        public async Task<LoanDTO?> GetByLoanIdAsync(int id_loan)
        {
            var loan = await _loanRepository.GetByLoanIdAsync(id_loan);
            return new LoanDTO
            {
                id_loan = loan.id,
                id_user = loan.id_user,
                id_book = loan.id_book,
                loan_date = loan.loan_date,
                due_date = loan.due_date,
                return_date = loan.return_date,
            };
        }

        public async Task<IEnumerable<LoanDTO?>> GetByUserIdAsync(int id_user)
        {
            var loans = await _loanRepository.GetByUserIdAsync(id_user);
            if (loans == null) return null;
            return loans.Select(loan => new LoanDTO
            {
                id_loan = loan.id,
                id_user = loan.id_user,
                id_book = loan.id_book,
                loan_date = loan.loan_date,
                due_date = loan.due_date,
                return_date = loan.return_date,
                is_return = loan.is_return
            });
        }

        public async Task<bool> UpdateAsync(LoanUpdateDTO loanDTO)
        {
            var loan = await _loanRepository.GetByLoanIdAsync(loanDTO.id);
            if (loan == null) throw new Exception("Loan does not exist");

            loan.id = loanDTO.id;
            loan.due_date = loanDTO.due_date;
            loan.return_date = loanDTO.return_date;

            await _loanRepository.UpdateAsync(loan);
            return true;
        }

        public async Task<int> ReturnBookAsync(int id_loan)
        {
            var loan = await _loanRepository.GetByLoanIdAsync(id_loan);
            if (loan == null) throw new Exception("Loan does not exist");

            if (loan.is_return) throw new Exception("Book already returned");
            loan.is_return = true;

            loan.return_date = DateTime.Now;
            var book = await _bookRepository.GetByIdAsync(loan.id_book);

            if (book == null) throw new Exception("Book does not exist");
            book.is_available = true;

            await _loanRepository.UpdateAsync(loan);
            await _bookRepository.UpdateAsync(book);

            if (loan.due_date != loan.return_date)
            {
                if (loan.return_date > loan.due_date)
                {
                    var daysLate = (loan.return_date - loan.due_date).Value.Days;
                    var fineAmount = daysLate * 150; // $150 COP por dia de retraso

                    return fineAmount;
                }
                return 1;
            }
            return 0;
        }

        public async Task<bool> ExtendLoan(int id_loan)
        {
            var loan = await _loanRepository.GetByLoanIdAsync(id_loan);
            if (loan == null) throw new Exception("Loan does not exist");

            if (loan.is_return) throw new Exception("Book already returned");

            if(loan.due_date < DateTime.Now) throw new Exception("Cannot extend a loan that is already overdue");
            loan.due_date = loan.due_date.AddDays(7);

            await _loanRepository.UpdateAsync(loan);
            return true;
        }
    }
}
