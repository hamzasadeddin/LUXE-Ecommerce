using System.Collections.Generic;

namespace LuxeEcommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? OriginalPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public bool InStock { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> Colors { get; set; }

        public decimal? DiscountPercent =>
            OriginalPrice.HasValue && OriginalPrice > 0
                ? Math.Round((1 - Price / OriginalPrice.Value) * 100)
                : (decimal?)null;
    }
}