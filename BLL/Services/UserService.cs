﻿using System;
using System.Linq;
using AutoMapper;
using BLL.Extensibility;
using BLL.Extensibility.Dto;
using BLL.Extensibility.Entity;
using ShoppingCart = BLL.Entity.ShoppingCart;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IShopService _db;
        private readonly IMapper _mapper;

        public UserService(IShopService db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public bool AddItem(ProductDto item, int quantity, IShoppingCart lineCollection)
        {
            try
            {
                if (item != null)
                {
                    lineCollection.Lines.Add(new ShoppingCartLine
                    {
                        Item = this._mapper.Map<ProductDto>(this._db.Products.GetById(item.Id)),
                        Quantity = quantity,
                    });
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool RemoveItem(ProductDto item, IShoppingCart lineCollection)
        {
            try
            {
                lineCollection.Lines.RemoveAll(l => l.Item.Id == item.Id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Clear(IShoppingCart lineCollection)
        {
            try
            {
                lineCollection.Lines.Clear();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public IShoppingCart ComposeCart(IShoppingCart lineCollection)
        {
            decimal cartPrice = lineCollection.Lines.Sum(item => item.Item.Price);

            var cart = new ShoppingCart
            {
                Lines = lineCollection.Lines,
                OverallPrice = cartPrice,
            };

            return cart;
        }

        public OrderDto MakeOrder(IShoppingCart cart)
        {
            var items = cart.Lines.Select(item => item.Item).ToList();
            var order = new OrderDto
            {
                Items = items,
                Time = System.DateTime.Now,
                Price = items.Sum(x => x.Price),
                State = StateDto.InProcess,
            };

            return order;
        }
    }
}