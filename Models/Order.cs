using System;
using System.Collections.Generic;

namespace LuxeEcommerce.Models
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Shipping { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public string Status { get; set; }
    }

    public class ShippingAddress
    {
        public string FullName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}