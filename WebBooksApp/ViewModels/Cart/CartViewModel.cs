using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBooksApp.ViewModels.Cart
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int Quantity { get; set; }
    }
}
