using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBooksApp.Models;

namespace WebBooksApp.Data.Stores
{
    public class CacheStore : ICacheStore
    {
        public Dictionary<int, Book> Cache { get; set; }

        public CacheStore()
        {
            Cache = new Dictionary<int, Book>();
        }
    }
}
