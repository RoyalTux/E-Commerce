﻿using System;
using System.Collections.Generic;

namespace BLL.Extensibility.Dto
{
    public enum StateDto
    {
        Confirmed,
        InProcess,
        Declined,
    }

    public class OrderDto
    {
        public OrderDto()
        {
            this.Items = new List<ProductDto>();
        }

        public int Id { get; set; }

        public DateTime Time { get; set; }

        public decimal Price { get; set; }

        public StateDto State { get; set; }

        public ICollection<ProductDto> Items { get; set; }
    }
}
