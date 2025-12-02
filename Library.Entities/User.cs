using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class User
    {
        public int id_user { get; set; }
        public string first_name { get; set; }
        public string? second_name { get; set; }
        public string first_lastname { get; set; }
        public string? second_lastname { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateTime register_date { get; set; }

        // 1 Usuario -> Muchos Préstamos
        public List<Loan> loans { get; set; }

    }
}
