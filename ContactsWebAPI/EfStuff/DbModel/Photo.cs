namespace ContactsWebAPI.EfStuff.DbModel
{
    public class Photo : BaseModel, IContent
    {
        public string Name { get; set; }
        public string UrlContent { get; set; }
        public string SizeOfPhoto { get; set; }
        public virtual Author Author { get; set; }
        public long Cost { get; set; }
        public long CountOfBuying { get; set; }
        public long Rating { get; set; }
    }
}
