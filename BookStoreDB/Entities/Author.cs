﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDB.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
