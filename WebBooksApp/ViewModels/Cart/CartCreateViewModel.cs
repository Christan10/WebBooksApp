using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBooksApp.ViewModels.Cart
{
    public class CartCreateViewModel
    {
        [Required]
        public int BookId { get; set; }

        [Required, MinLength(2)]
        public string BookTitle { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
