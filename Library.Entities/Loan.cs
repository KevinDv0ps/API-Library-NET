using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class Loan
    {
        public int id_loan { get; set; }
        public int id_book { get; set; } // FK
        public int id_user { get; set; } // FK
        public DateTime loan_date { get; set; }
        public DateTime due_date { get; set; }
        public DateTime? return_date { get; set; }
        public bool is_return { get; set; }


        public Book book { get; set; }
        public User user { get; set; }
    }
}
