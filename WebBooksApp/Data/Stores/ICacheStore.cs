using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBooksApp.Models;

namespace WebBooksApp.Data.Stores
{
    public interface ICacheStore
    {
        Dictionary<int, Book> Cache { get; set; }
    }
}
