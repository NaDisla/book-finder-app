using System;
using System.Collections.Generic;
using System.Text;

namespace book_finder_app.Models
{
    public class Book
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public DateTime PublishedDate { get; set; }
        public string SmallThumbnail { get; set; }
        public string Description { get; set; }
    }
}
