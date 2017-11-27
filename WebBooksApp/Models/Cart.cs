using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebBooksApp.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
    }
}
