using Microsoft.AspNetCore.Mvc;
using LuxeEcommerce.Models.MockData;
using System.Linq;

namespace LuxeEcommerce.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var featuredProducts = MockDataStore.Products
                .Where(p => p.IsFeatured).Take(8).ToList();
            var newArrivals = MockDataStore.Products
                .Where(p => p.IsNew).Take(4).ToList();
            ViewBag.FeaturedProducts = featuredProducts;
            ViewBag.NewArrivals = newArrivals;
            return View();
        }
    }
}