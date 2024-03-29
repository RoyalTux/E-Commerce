﻿using System.Collections.Generic;

namespace ECommerce.WebAPI.Models
{
    public class ShoppingCartView
    {
        public ShoppingCartView()
        {
            this.Lines = new List<ShoppingCartLineView>();
        }

        public List<ShoppingCartLineView> Lines { get; set; }

        public double OverallPrice { get; set; }
    }
}