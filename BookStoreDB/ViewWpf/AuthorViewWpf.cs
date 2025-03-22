using BookStoreDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDB.ViewWpf
{
    public class AuthorViewWpf
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public ICollection<BookViewWpf> Books { get; set; } 
    }
}
