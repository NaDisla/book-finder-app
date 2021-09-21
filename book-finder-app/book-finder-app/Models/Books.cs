using System.Collections.Generic;

namespace book_finder_app.Models
{
    public class Books
    {
        public int TotalItems { get; set; }
        public List<Items> Items { get; set; }
    }
}
