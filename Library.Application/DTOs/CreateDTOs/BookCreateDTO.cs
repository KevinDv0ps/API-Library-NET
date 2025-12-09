using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;

namespace Library.Application.DTOs.CreateDTOs
{
    public class BookCreateDTO
    {
        public string title { get; set; }
        public string description { get; set; }
        public DateTime published_date { get; set; }
        public bool is_available { get; set; }
        public List<int> authors_ids { get; set; }
        public List<int> genres_ids { get; set; }
    }
}
