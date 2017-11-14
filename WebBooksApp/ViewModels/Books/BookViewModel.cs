using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBooksApp.ViewModels.Books
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
    }
}
