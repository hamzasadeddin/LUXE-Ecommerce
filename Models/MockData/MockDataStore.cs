using System;
using System.Collections.Generic;
using LuxeEcommerce.Models;

namespace LuxeEcommerce.Models.MockData
{
    public static class MockDataStore
    {

        public static List<Product> Products = new List<Product>
        {
            new Product {
                Id = 1, Name = "Aurora Silk Blouse", Brand = "Maison Élite",
                Description = "Crafted from 100% mulberry silk, the Aurora Blouse drapes beautifully with a relaxed silhouette. Features mother-of-pearl buttons and a subtle sheen that catches the light.",
                Price = 189.00m, OriginalPrice = 240.00m,
                ImageUrl = "https://images.unsplash.com/photo-1551489186-cf8726f514f8?w=600",
                Category = "Women", SubCategory = "Tops",
                Rating = 4.8, ReviewCount = 124, IsNew = false, IsFeatured = true, InStock = true,
                Tags = new List<string>{"silk","blouse","formal"},
                Sizes = new List<string>{"XS","S","M","L","XL"},
                Colors = new List<string>{"Ivory","Blush","Noir"}
            },
            new Product {
                Id = 2, Name = "Obsidian Leather Jacket", Brand = "Vega Studio",
                Description = "Full-grain Italian leather jacket with a sleek moto silhouette. Asymmetric zipper, quilted liner, and YKK hardware throughout.",
                Price = 495.00m, OriginalPrice = null,
                ImageUrl = "https://images.unsplash.com/photo-1521223890158-f9f7c3d5d504?w=600",
                Category = "Men", SubCategory = "Jackets",
                Rating = 4.9, ReviewCount = 89, IsNew = true, IsFeatured = true, InStock = true,
                Tags = new List<string>{"leather","jacket","premium"},
                Sizes = new List<string>{"S","M","L","XL","XXL"},
                Colors = new List<string>{"Black","Dark Brown"}
            },
            new Product {
                Id = 3, Name = "Celestine Midi Dress", Brand = "Atelier Blanc",
                Description = "A flowing midi dress in organic cotton voile. Features a smocked bodice, adjustable straps, and a tiered skirt that moves with every step.",
                Price = 148.00m, OriginalPrice = 195.00m,
                ImageUrl = "https://images.unsplash.com/photo-1595777457583-95e059d581b8?w=600",
                Category = "Women", SubCategory = "Dresses",
                Rating = 4.7, ReviewCount = 203, IsNew = true, IsFeatured = true, InStock = true,
                Tags = new List<string>{"dress","midi","summer"},
                Sizes = new List<string>{"XS","S","M","L"},
                Colors = new List<string>{"Sage","Terracotta","Cream"}
            },
            new Product {
                Id = 4, Name = "Meridian Slim Chinos", Brand = "Vega Studio",
                Description = "Tailored from a stretch-cotton blend for all-day comfort. Clean lines, a tapered leg, and a modern fit that goes from office to weekend.",
                Price = 95.00m, OriginalPrice = null,
                ImageUrl = "https://images.unsplash.com/photo-1473966968600-fa801b869a1a?w=600",
                Category = "Men", SubCategory = "Trousers",
                Rating = 4.6, ReviewCount = 167, IsNew = false, IsFeatured = false, InStock = true,
                Tags = new List<string>{"chinos","trousers","casual"},
                Sizes = new List<string>{"28","30","32","34","36"},
                Colors = new List<string>{"Khaki","Navy","Stone"}
            },
            new Product {
                Id = 5, Name = "Velvet Wrap Blazer", Brand = "Maison Élite",
                Description = "Luxurious crushed velvet blazer with a wrap-front silhouette and self-tie belt. Rich jewel-tone color for evenings that demand attention.",
                Price = 265.00m, OriginalPrice = 320.00m,
                ImageUrl = "https://images.unsplash.com/photo-1591047139829-d91aecb6caea?w=600",
                Category = "Women", SubCategory = "Blazers",
                Rating = 4.9, ReviewCount = 56, IsNew = true, IsFeatured = true, InStock = true,
                Tags = new List<string>{"velvet","blazer","evening"},
                Sizes = new List<string>{"XS","S","M","L","XL"},
                Colors = new List<string>{"Emerald","Burgundy","Sapphire"}
            },
            new Product {
                Id = 6, Name = "Linen Oxford Shirt", Brand = "Atelier Blanc",
                Description = "Classic Oxford shirt reimagined in premium Irish linen. Slightly relaxed fit, button-down collar, and a chest pocket. Perfect for warm weather dressing.",
                Price = 85.00m, OriginalPrice = null,
                ImageUrl = "https://images.unsplash.com/photo-1594938298603-c8148c4b4a17?w=600",
                Category = "Men", SubCategory = "Shirts",
                Rating = 4.5, ReviewCount = 312, IsNew = false, IsFeatured = false, InStock = true,
                Tags = new List<string>{"linen","shirt","casual"},
                Sizes = new List<string>{"S","M","L","XL","XXL"},
                Colors = new List<string>{"White","Sky Blue","Pale Yellow"}
            },
            new Product {
                Id = 7, Name = "Onyx Crossbody Bag", Brand = "Vega Studio",
                Description = "Structured crossbody in pebbled calfskin leather. Adjustable chain strap, magnetic clasp, and interior card slots. An everyday essential, elevated.",
                Price = 320.00m, OriginalPrice = 380.00m,
                ImageUrl = "https://images.unsplash.com/photo-1548036328-c9fa89d128fa?w=600",
                Category = "Accessories", SubCategory = "Bags",
                Rating = 4.8, ReviewCount = 78, IsNew = false, IsFeatured = true, InStock = true,
                Tags = new List<string>{"bag","leather","accessories"},
                Sizes = new List<string>{"One Size"},
                Colors = new List<string>{"Black","Caramel","White"}
            },
            new Product {
                Id = 8, Name = "Cashmere Turtleneck", Brand = "Maison Élite",
                Description = "Grade A Mongolian cashmere turtleneck with a refined ribbed collar and cuffs. Lightweight yet insulating, with an incredibly soft hand feel.",
                Price = 225.00m, OriginalPrice = null,
                ImageUrl = "https://images.unsplash.com/photo-1576566588028-4147f3842f27?w=600",
                Category = "Women", SubCategory = "Knitwear",
                Rating = 4.9, ReviewCount = 145, IsNew = false, IsFeatured = true, InStock = true,
                Tags = new List<string>{"cashmere","knitwear","luxury"},
                Sizes = new List<string>{"XS","S","M","L","XL"},
                Colors = new List<string>{"Oatmeal","Charcoal","Dusty Rose"}
            },
            new Product {
                Id = 9, Name = "Heritage Denim Jacket", Brand = "Atelier Blanc",
                Description = "Sanforized Japanese selvedge denim jacket in a classic trucker silhouette. Raw indigo that fades beautifully over time. Built to last generations.",
                Price = 175.00m, OriginalPrice = 210.00m,
                ImageUrl = "https://images.unsplash.com/photo-1543076447-215ad9ba6923?w=600",
                Category = "Men", SubCategory = "Jackets",
                Rating = 4.7, ReviewCount = 93, IsNew = false, IsFeatured = false, InStock = true,
                Tags = new List<string>{"denim","jacket","heritage"},
                Sizes = new List<string>{"S","M","L","XL"},
                Colors = new List<string>{"Raw Indigo","Washed Blue"}
            },
            new Product {
                Id = 10, Name = "Amber Hoop Earrings", Brand = "Vega Studio",
                Description = "Hand-hammered 18k gold-plated hoops with a subtle brushed texture. Lightweight and comfortable for all-day wear. Hypoallergenic posts.",
                Price = 68.00m, OriginalPrice = null,
                ImageUrl = "https://images.unsplash.com/photo-1535632066927-ab7c9ab60908?w=600",
                Category = "Accessories", SubCategory = "Jewelry",
                Rating = 4.6, ReviewCount = 234, IsNew = true, IsFeatured = false, InStock = true,
                Tags = new List<string>{"jewelry","earrings","gold"},
                Sizes = new List<string>{"Small","Medium","Large"},
                Colors = new List<string>{"Gold","Rose Gold","Silver"}
            },
            new Product {
                Id = 11, Name = "Pleated Wide-Leg Trousers", Brand = "Maison Élite",
                Description = "High-waisted wide-leg trousers in a fluid crepe fabric. Front pleats add volume and movement. Pairs perfectly with a tucked-in blouse.",
                Price = 155.00m, OriginalPrice = 195.00m,
                ImageUrl = "https://images.unsplash.com/photo-1509631179647-0177331693ae?w=600",
                Category = "Women", SubCategory = "Trousers",
                Rating = 4.7, ReviewCount = 88, IsNew = false, IsFeatured = false, InStock = true,
                Tags = new List<string>{"trousers","wide-leg","formal"},
                Sizes = new List<string>{"XS","S","M","L","XL"},
                Colors = new List<string>{"Black","Camel","Forest Green"}
            },
            new Product {
                Id = 12, Name = "Merino Crew Sweater", Brand = "Atelier Blanc",
                Description = "Extra-fine merino wool crewneck in a relaxed fit. Ribbed collar, cuffs and hem. A wardrobe cornerstone that layers perfectly.",
                Price = 120.00m, OriginalPrice = null,
                ImageUrl = "https://images.unsplash.com/photo-1556905055-8f358a7a47b2?w=600",
                Category = "Men", SubCategory = "Knitwear",
                Rating = 4.8, ReviewCount = 176, IsNew = false, IsFeatured = false, InStock = true,
                Tags = new List<string>{"merino","knitwear","sweater"},
                Sizes = new List<string>{"S","M","L","XL","XXL"},
                Colors = new List<string>{"Navy","Forest Green","Burgundy","Oatmeal"}
            }
        };


        public static List<User> Users = new List<User>
        {
            new User {
                Id = 1, FullName = "Hamza Sadeddin",
                Email = "hamza@luxe.com", Password = "password123",
                Phone = "+962 79 623-5274",
                AvatarUrl = "https://i.pravatar.cc/150?img=12",
                MemberSince = "January 2023"
            },
            new User {
                Id = 2, FullName = "Sarah Ahmad",
                Email = "sarah@luxe.com", Password = "password123",
                Phone = "+1 (555) 987-6543",
                AvatarUrl = "https://i.pravatar.cc/150?img=47",
                MemberSince = "March 2022"
            }
        };


        public static List<string> Categories = new List<string>
        {
            "All", "Women", "Men", "Accessories"
        };
    }
}