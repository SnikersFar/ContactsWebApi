using ContactsWebAPI.EfStuff.DbModel;
using System;
using System.Collections.Generic;

namespace ContactsWebAPI.Models
{
    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public long Age { get; set; }
        public DateTime DateCreateAccount { get; set; }
        public virtual List<PhotoViewModel> Photos { get; set; }
        public virtual List<TextViewModel> Texts { get; set; }
    }
}
