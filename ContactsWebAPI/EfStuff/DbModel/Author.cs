using System;
using System.Collections.Generic;

namespace ContactsWebAPI.EfStuff.DbModel
{
    public class Author : BaseModel
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public long Age { get; set; }
        public DateTime DateCreateAccount { get; set; }
        public virtual List<Photo> Photos { get; set; }
        public virtual List<Text> Texts { get; set; }

    }
}
