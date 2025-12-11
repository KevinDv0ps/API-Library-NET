namespace Library.Entities
{
    public class Book
    {

        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime published_date { get; set; }
        public bool is_available { get; set; }

        // Navigation property
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
        public Loan? Loan { get; set; }

        public void setAvailable(bool available)
        {
            this.is_available = available;
        }
    }
}
