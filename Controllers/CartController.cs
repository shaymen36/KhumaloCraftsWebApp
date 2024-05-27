using Microsoft.AspNetCore.Mvc;
using KhumaloCraftsWebApp.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using KhumaloCraftsWebApp.Data;

namespace KhumaloCraftsWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly KhumaloCraftDBContext _context;
        private readonly ShoppingCart _shoppingCart;

        public CartController(KhumaloCraftDBContext context, IServiceProvider services)
        {
            _context = context;
            _shoppingCart = ShoppingCart.GetCart(services);
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetCartItems();
            return View(items);
        }

        public async Task<IActionResult> AddToCart(int id, int quantity)
        {
            var selectedProduct = await _context.Products.FindAsync(id);
            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct, quantity);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index");
        }

        public IActionResult GetCartItemCount()
        {
            var count = _shoppingCart.GetCartItems().Count;
            return PartialView("_CartItemCount", count);
        }
    }
}
