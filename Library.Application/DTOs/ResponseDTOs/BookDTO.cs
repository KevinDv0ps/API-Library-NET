using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.ResponseDTOs
{
    public class BookDTO 
    {
        public int id_book { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime published_date { get; set; }
        public bool is_available { get; set; }
        public List<AuthorDTO> Authors { get; set; }
        public List<GenreDTO> Genres { get; set; }
        public LoanDTO? Loan { get; set; }
    }
}
