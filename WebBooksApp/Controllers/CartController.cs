using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBooksApp.Data;
using WebBooksApp.Data.Repositories;
using WebBooksApp.Models;
using WebBooksApp.ViewModels.Cart;

namespace WebBooksApp.Controllers
{
    [Route("api/[controller]"), AllowAnonymous]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly ApplicationDbContext _dbContext;

        public CartController(ICartRepository cartRepository, ApplicationDbContext dbContext)
        {
            _cartRepository = cartRepository;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CartCreateViewModel[] cartItems)
        {
            var carts = new List<Cart>();

            foreach (var model in cartItems)
            {
                var cart = new Cart
                {
                    BookId = model.BookId,
                    Quantity = model.Quantity
                };

                _dbContext.Cart.Add(cart);
                carts.Add(cart);
            }
            await _dbContext.SaveChangesAsync();

            return Ok(carts);
        }
    }
}
