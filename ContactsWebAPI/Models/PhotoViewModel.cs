namespace ContactsWebAPI.Models
{
    public class PhotoViewModel
    {
        public long Id { get; set; }
        public long AutrhorId { get; set; }
        public string Name { get; set; }
        public string UrlContent { get; set; }
        public string SizeOfPhoto { get; set; }
        public long Cost { get; set; }
        public long CountOfBuying { get; set; }
        public long Rating { get; set; }
    }
}
