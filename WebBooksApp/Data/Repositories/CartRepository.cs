using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBooksApp.Models;

namespace WebBooksApp.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Cart> _dbSet;

        public CartRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Cart;
        }

        public async Task<Cart> SaveAsync(Cart cart)
        {
            _dbContext.Entry(cart).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0 ? cart : null;
        }
    }
}
