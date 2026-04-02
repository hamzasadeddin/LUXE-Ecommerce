# LUXE — Premium Fashion E-Commerce Platform

**A modern, elegant e-commerce platform built with ASP.NET Core MVC**

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)](https://getbootstrap.com/)
[![JavaScript](https://img.shields.io/badge/JavaScript-ES6+-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)](https://developer.mozilla.org/en-US/docs/Web/JavaScript)
[![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)](https://developer.mozilla.org/en-US/docs/Web/HTML)
[![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white)](https://developer.mozilla.org/en-US/docs/Web/CSS)

</div>

---

## 📖 About The Project

**LUXE** is a fully functional, front-to-back e-commerce web application developed as a showcase project to demonstrate proficiency in ASP.NET Core MVC development. The platform simulates a premium fashion retail experience with a refined, editorial aesthetic inspired by high-end Parisian boutiques.

> 💡 This project uses **mock/static data** instead of a database, making it fully portable and easy to run without any setup beyond Visual Studio.

---

## ✨ Features

### 🛍️ Shopping Experience
- **Home Page** — Hero section, category browsing, featured products, new arrivals & customer testimonials
- **Shop Page** — Full product catalog with category filtering and sorting (price, rating, newest)
- **Product Detail Page** — Image gallery, size & color selector, quantity control, related products
- **Shopping Cart** — Live AJAX quantity updates, real-time subtotal calculation, persistent session cart
- **Checkout Page** — Shipping form, payment method selection (Credit Card / PayPal)
- **Order Confirmation** — Full order summary with unique order number

### 👤 User Account
- **Login Page** — Session-based authentication with demo credentials
- **Registration Page** — New account creation with validation
- **Profile Page** — Account overview with order stats and member information
- **Session Management** — Persistent login state across pages

### 🎨 UI / UX Design
- **Warm Parisian Aesthetic** — Cream, warm stone & antique gold color palette
- **Cormorant Garamond + Jost** — Elegant editorial font pairing
- **Scroll Reveal Animations** — Elements animate in as you scroll
- **Staggered Product Cards** — Smooth cascading load animation
- **Animated Counters** — Stats count up when they enter the viewport
- **Gold Progress Bar** — Reading progress indicator at the top of the page
- **Shimmer Banner** — Animated promotional banner
- **Frosted Glass Navbar** — Sticky navbar with blur effect
- **Toast Notifications** — Smooth slide-in feedback messages
- **Fully Responsive** — Mobile-friendly layout across all screen sizes

---

## 🛠️ Built With

| Technology | Purpose |
|---|---|
| **ASP.NET Core MVC (.NET 9)** | Backend framework & routing |
| **Razor Views (.cshtml)** | Server-side HTML templating |
| **C#** | Controllers, models & business logic |
| **Bootstrap 5.3** | Responsive grid & UI components |
| **Vanilla JavaScript (ES6+)** | AJAX cart, animations & interactions |
| **CSS3 Custom Properties** | Design system & theming |
| **Session Storage** | Cart & user authentication state |
| **Font Awesome 6** | Icons throughout the UI |
| **Google Fonts** | Cormorant Garamond + Jost typography |

---

## 🗂️ Project Structure

```
LuxeEcommerce/
├── Controllers/
│   ├── HomeController.cs         # Home page
│   ├── ShopController.cs         # Product listing & detail
│   ├── CartController.cs         # Cart AJAX operations
│   ├── AccountController.cs      # Login & registration
│   ├── CheckoutController.cs     # Checkout & order confirmation
│   └── ProfileController.cs      # User profile
│
├── Models/
│   ├── Product.cs                # Product model
│   ├── CartItem.cs               # Cart item model
│   ├── Order.cs                  # Order & shipping address models
│   ├── User.cs                   # User model
│   └── MockData/
│       └── MockDataStore.cs      # Static mock data (12 products, 2 users)
│
├── Views/
│   ├── Shared/
│   │   ├── _Layout.cshtml        # Master layout (navbar + footer)
│   │   └── _ProductCard.cshtml   # Reusable product card partial
│   ├── Home/Index.cshtml
│   ├── Shop/Index.cshtml
│   ├── Shop/Detail.cshtml
│   ├── Cart/Index.cshtml
│   ├── Checkout/Index.cshtml
│   ├── Checkout/Confirmation.cshtml
│   ├── Account/Login.cshtml
│   ├── Account/Register.cshtml
│   └── Profile/Index.cshtml
│
├── wwwroot/
│   ├── css/luxe-styles.css       # Custom design system
│   └── js/luxe-app.js            # Application JavaScript
│
└── Program.cs                    # App configuration & middleware
```

---

## 🚀 Getting Started

### Prerequisites
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or later)
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/LuxeEcommerce.git
   ```

2. **Open in Visual Studio**
   - Open `LuxeEcommerce.sln`

3. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

4. **Run the project**
   - Press `F5` in Visual Studio, or:
   ```bash
   dotnet run
   ```

5. **Open in browser**
   ```
   https://localhost:[port]
   ```

### Demo Credentials
> Use these to log in and explore the full authenticated experience

| Field | Value |
|---|---|
| **Email** | alex@luxe.com |
| **Password** | password123 |

---

## 📸 Pages Overview

| Page | Route | Description |
|---|---|---|
| Home | `/` | Landing page with hero, categories & featured products |
| Shop | `/Shop` | Full product catalog with filters |
| Product Detail | `/Shop/Detail/{id}` | Individual product page |
| Cart | `/Cart` | Shopping bag with live updates |
| Checkout | `/Checkout` | Shipping & payment form |
| Confirmation | `/Checkout/Confirmation` | Order success page |
| Login | `/Account/Login` | Sign in page |
| Register | `/Account/Register` | Create account page |
| Profile | `/Profile` | User dashboard |

---

## 🎯 Key Technical Highlights

- **AJAX Cart Operations** — Add, update quantity, and remove items without page reload using `fetch()` API
- **Session-Based Auth** — Login state persisted across pages using `HttpContext.Session`
- **Partial Views** — Reusable `_ProductCard.cshtml` component used across multiple pages
- **Tag Helpers** — ASP.NET Core tag helpers (`asp-controller`, `asp-action`) for clean routing
- **Intersection Observer API** — Scroll-triggered animations using native browser API
- **CSS Custom Properties** — Full design system with CSS variables for consistent theming
- **Mock Data Architecture** — Static data store simulating a real database layer, easily replaceable with Entity Framework

---

## 🔮 Future Improvements

- [ ] Connect to a real database using **Entity Framework Core**
- [ ] Add **product search** functionality
- [ ] Implement **wishlist** persistence
- [ ] Add **admin dashboard** for product management
- [ ] Integrate a real **payment gateway** (Stripe / PayPal)
- [ ] Add **email confirmation** on order placement
- [ ] Implement **JWT authentication**
- [ ] Add **product reviews & ratings** system

---

## 👨‍💻 About the Developer

This project was built as an internship showcase to demonstrate full-stack web development skills using the **ASP.NET Core MVC** framework. It covers the complete development lifecycle from UI design to server-side logic and state management.

**Skills demonstrated:**
- ASP.NET Core MVC architecture (Controllers, Views, Models)
- RESTful AJAX endpoints with JSON responses
- Session state management
- Responsive UI design with Bootstrap
- Custom CSS design systems
- Vanilla JavaScript DOM manipulation & animations
- Clean code organization and project structure

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

---

<div align="center">

Made with ❤️ using ASP.NET Core MVC

⭐ **If you found this project helpful, please consider giving it a star!** ⭐

</div>
