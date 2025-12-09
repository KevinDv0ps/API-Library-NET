using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.UpdateDTOs
{
    public  class BookUpdateDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime published_date { get; set; }
        public bool is_available { get; set; }
        public List<int> authors_ids { get; set; }
        public List<int> genres_ids { get; set; }
    }
}
