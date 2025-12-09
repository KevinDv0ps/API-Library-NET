using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.ResponseDTOs
{
    public class LoanDTO
    {
        public int id_loan { get; set; }
        public int id_book { get; set; } 
        public int id_user { get; set; } 
        public DateTime loan_date { get; set; }
        public DateTime due_date { get; set; }
        public DateTime? return_date { get; set; }
        public bool is_return { get; set; }
    }
}
