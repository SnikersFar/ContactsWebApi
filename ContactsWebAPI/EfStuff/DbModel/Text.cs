using System;

namespace ContactsWebAPI.EfStuff.DbModel
{
    public class Text : BaseModel, IContent
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public long Size { get; set; }
        public DateTime DateCreate { get; set; }
        public long Cost { get; set; }
        public virtual Author Author { get; set; }
        public long CountOfBuying { get; set; }
        public long Rating { get; set; }
    }
}
