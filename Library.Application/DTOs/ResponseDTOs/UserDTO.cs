using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.ResponseDTOs
{
    public class UserDTO
    {
        public int id_user { get; set; }
        public string first_name { get; set; }
        public string? second_name { get; set; }
        public string first_lastname { get; set; }
        public string? second_lastname { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateTime register_date { get; set; }
    }
}
