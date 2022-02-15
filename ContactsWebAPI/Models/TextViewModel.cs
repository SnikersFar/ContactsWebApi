using System;

namespace ContactsWebAPI.Models
{
    public class TextViewModel
    {
        public long Id { get; set; }
        public long AutrhorId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public long Size { get; set; }
        public DateTime DateCreate { get; set; }
        public long Cost { get; set; }
        public long CountOfBuying { get; set; }
        public long Rating { get; set; }
    }
}
