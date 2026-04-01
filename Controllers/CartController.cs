using Microsoft.AspNetCore.Mvc;
using LuxeEcommerce.Models;
using LuxeEcommerce.Models.MockData;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace LuxeEcommerce.Controllers
{
    public class CartController : Controller
    {
        private List<CartItem> GetCart()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            return cartJson != null
                ? JsonSerializer.Deserialize<List<CartItem>>(cartJson)
                : new List<CartItem>();
        }

        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
        }

        public IActionResult Index()
        {
            return View(GetCart());
        }

        [HttpPost]
        public IActionResult Add(int productId, int quantity = 1, string size = "", string color = "")
        {
            var product = MockDataStore.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                return Json(new { success = false });

            var cart = GetCart();
            var existing = cart.FirstOrDefault(c => c.ProductId == productId
                && c.SelectedSize == size && c.SelectedColor == color);

            if (existing != null)
                existing.Quantity += quantity;
            else
                cart.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = product.Name,
                    Brand = product.Brand,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Quantity = quantity,
                    SelectedSize = size,
                    SelectedColor = color
                });

            SaveCart(cart);
            return Json(new { success = true, cartCount = cart.Sum(c => c.Quantity) });
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity, string size = "", string color = "")
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.ProductId == productId
                && c.SelectedSize == size && c.SelectedColor == color);

            if (item != null)
            {
                if (quantity <= 0) cart.Remove(item);
                else item.Quantity = quantity;
            }

            SaveCart(cart);
            var total = cart.Sum(c => c.Subtotal);
            return Json(new { success = true, cartCount = cart.Sum(c => c.Quantity), total = total.ToString("F2") });
        }

        [HttpPost]
        public IActionResult Remove(int productId, string size = "", string color = "")
        {
            var cart = GetCart();
            cart.RemoveAll(c => c.ProductId == productId
                && c.SelectedSize == size && c.SelectedColor == color);
            SaveCart(cart);
            return Json(new { success = true, cartCount = cart.Sum(c => c.Quantity) });
        }

        public IActionResult GetCount()
        {
            var cart = GetCart();
            return Json(new { count = cart.Sum(c => c.Quantity) });
        }
    }
}