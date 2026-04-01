using Microsoft.AspNetCore.Mvc;
using LuxeEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace LuxeEcommerce.Controllers
{
    public class CheckoutController : Controller
    {
        private List<CartItem> GetCart()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            return cartJson != null
                ? JsonSerializer.Deserialize<List<CartItem>>(cartJson)
                : new List<CartItem>();
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") == null)
                return RedirectToAction("Login", "Account", new { returnUrl = "/Checkout" });

            var cart = GetCart();
            if (!cart.Any()) return RedirectToAction("Index", "Cart");
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrder(string fullName, string street, string city,
            string country, string phone, string paymentMethod)
        {
            var cart = GetCart();
            if (!cart.Any()) return RedirectToAction("Index", "Cart");

            var subtotal = cart.Sum(c => c.Subtotal);
            var shipping = subtotal > 200 ? 0 : 15;
            var tax = Math.Round(subtotal * 0.08m, 2);

            var order = new Order
            {
                OrderNumber = "LX-" + DateTime.Now.ToString("yyyyMMdd") + "-" + new Random().Next(1000, 9999),
                OrderDate = DateTime.Now,
                Items = cart,
                Subtotal = subtotal,
                Shipping = shipping,
                Tax = tax,
                Total = subtotal + shipping + tax,
                PaymentMethod = paymentMethod,
                ShippingAddress = new ShippingAddress
                {
                    FullName = fullName,
                    Street = street,
                    City = city,
                    Country = country,
                    Phone = phone
                },
                Status = "Confirmed"
            };

            HttpContext.Session.SetString("LastOrder", JsonSerializer.Serialize(order));
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            var orderJson = HttpContext.Session.GetString("LastOrder");
            if (string.IsNullOrEmpty(orderJson)) return RedirectToAction("Index", "Home");
            var order = JsonSerializer.Deserialize<Order>(orderJson);
            return View(order);
        }
    }
}