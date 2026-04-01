using Microsoft.AspNetCore.Mvc;
using LuxeEcommerce.Models.MockData;
using System.Linq;

namespace LuxeEcommerce.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index(string category = "All", string sort = "default")
        {
            var products = MockDataStore.Products.AsQueryable();

            if (category != "All" && !string.IsNullOrEmpty(category))
                products = products.Where(p => p.Category == category);

            products = sort switch
            {
                "price-asc" => products.OrderBy(p => p.Price),
                "price-desc" => products.OrderByDescending(p => p.Price),
                "rating" => products.OrderByDescending(p => p.Rating),
                "newest" => products.OrderByDescending(p => p.IsNew),
                _ => products.OrderByDescending(p => p.IsFeatured)
            };

            ViewBag.SelectedCategory = category;
            ViewBag.SelectedSort = sort;
            ViewBag.Categories = MockDataStore.Categories;
            return View(products.ToList());
        }

        public IActionResult Detail(int id)
        {
            var product = MockDataStore.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var related = MockDataStore.Products
                .Where(p => p.Category == product.Category && p.Id != id)
                .Take(4).ToList();

            ViewBag.RelatedProducts = related;
            return View(product);
        }
    }
}