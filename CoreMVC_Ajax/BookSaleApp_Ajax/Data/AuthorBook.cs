using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSaleApp_Ajax.Data
{
    public class AuthorBook
    {
        public int AuthorId{get;set;}
        public int BookId { get; set; }
        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
