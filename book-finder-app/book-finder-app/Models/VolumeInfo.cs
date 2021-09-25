
namespace book_finder_app.Models
{
    public class VolumeInfo
    {
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public string FinalAuthors { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }
        public ImageLinks ImageLinks { get; set; }
        public string SourceImage { get; set; }
    }
}
