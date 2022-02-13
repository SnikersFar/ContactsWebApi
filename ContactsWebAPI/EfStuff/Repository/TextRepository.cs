using ContactsWebAPI.EfStuff.DbModel;

namespace ContactsWebAPI.EfStuff.Repository
{
    public class TextRepository : BaseRepository<Text>
    {
        public TextRepository(WebContext webContext) : base(webContext)
        {
        }
    }
}
