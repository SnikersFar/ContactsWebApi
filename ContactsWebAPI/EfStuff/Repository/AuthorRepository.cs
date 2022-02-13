using ContactsWebAPI.EfStuff.DbModel;

namespace ContactsWebAPI.EfStuff.Repository
{
    public class AuthorRepository : BaseRepository<Author>
    {
        public AuthorRepository(WebContext webContext) : base(webContext)
        {
        }
    }
}
