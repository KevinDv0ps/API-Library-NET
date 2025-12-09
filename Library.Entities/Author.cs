using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class Author
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string? second_name { get; set; }
        public string first_lastname { get; set; }
        public string? second_lastname { get; set; }
        public string nacionality { get; set; }
        public DateTime birth_date { get; set; }
        public DateTime? death_date { get; set; }

        // Relation
        public List<Book> Books { get; set; }
    }
}
