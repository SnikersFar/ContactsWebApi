using ContactsWebAPI.EfStuff.DbModel;
using System.Collections.Generic;

namespace ContactsWebAPI.Models
{
    public class DataViewModel
    {
        public List<Author> Authors { get; set; }
        public List<Text> Texts { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
