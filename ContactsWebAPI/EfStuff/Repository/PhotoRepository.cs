using ContactsWebAPI.EfStuff.DbModel;

namespace ContactsWebAPI.EfStuff.Repository
{
    public class PhotoRepository : BaseRepository<Photo>
    {
        public PhotoRepository(WebContext webContext) : base(webContext)
        {
        }
    }
}
