using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.UpdateDTOs
{
    public class LoanUpdateDTO
    {
        public int id { get; set; }
        public DateTime due_date { get; set; }
        public DateTime? return_date { get; set; }
        public bool is_return { get; set; }
    }
}
