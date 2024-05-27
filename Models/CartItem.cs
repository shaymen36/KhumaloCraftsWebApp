﻿using System.ComponentModel.DataAnnotations;

namespace KhumaloCraftsWebApp.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string CartId { get; set; }
    }
}