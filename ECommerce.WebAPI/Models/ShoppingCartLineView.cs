﻿namespace WebAPI.Models
{
    public class ShoppingCartLineView
    {
        public int ShoppingCartId { get; set; }

        public ProductView Product { get; set; }

        public int Quantity { get; set; }
    }
}