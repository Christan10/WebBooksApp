using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBooksApp.ViewModels.Books
{
    public class BookCreateViewModel
    {
        [Required, MinLength(2)]
        public string Title { get; set; }
        [MinLength(2)]
        public string Description { get; set; }
        [MinLength(2)]
        public string AuthorName { get; set; }
    }

}
