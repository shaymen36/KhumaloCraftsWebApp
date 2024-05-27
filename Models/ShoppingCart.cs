using KhumaloCraftsWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KhumaloCraftsWebApp.Models
{
    public class ShoppingCart
    {
        private readonly KhumaloCraftDBContext _context;

        public ShoppingCart(KhumaloCraftDBContext context)
        {
            _context = context;
        }

        public string ShoppingCartId { get; set; }

        public List<CartItem> CartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<KhumaloCraftDBContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product, int quantity)
        {
            var cartItem = _context.CartItems.SingleOrDefault(
                c => c.ProductId == product.Id && c.CartId == ShoppingCartId);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity,
                    CartId = ShoppingCartId
                };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }
            _context.SaveChanges();
        }

        public List<CartItem> GetCartItems()
        {
            return CartItems ?? (CartItems = _context.CartItems.Where(c => c.CartId == ShoppingCartId).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _context.CartItems.Where(cart => cart.CartId == ShoppingCartId);

            _context.CartItems.RemoveRange(cartItems);

            _context.SaveChanges();
        }
    }
}
