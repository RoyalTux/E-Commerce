using System;
using System.Linq;
using AutoMapper;
using ECommerce.BLL.Extensibility;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.BLL.Extensibility.Entities;

namespace ECommerce.BLL.Services
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

        public bool AddProduct(ProductDto product, int quantity, IShoppingCart lineCollection)
        {
            try
            {
                if (product != null)
                {
                    lineCollection.Lines.Add(new ShoppingCartLine
                    {
                        Product = this._mapper.Map<ProductDto>(this._db.Products.GetById(product.Id)),
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

        public bool RemoveProduct(ProductDto product, IShoppingCart lineCollection)
        {
            try
            {
                lineCollection.Lines.RemoveAll(l => l.Product.Id == product.Id);
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
            decimal cartPrice = lineCollection.Lines.Sum(product => product.Product.Price);

            var cart = new ShoppingCart
            {
                Lines = lineCollection.Lines,
                OverallPrice = cartPrice,
            };

            return cart;
        }

        public OrderDto MakeOrder(IShoppingCart cart)
        {
            var products = cart.Lines.Select(product => product.Product).ToList();
            var order = new OrderDto
            {
                Products = products,
                Time = System.DateTime.Now,
                Price = products.Sum(x => x.Price),
                State = StateDto.InProcess,
            };

            return order;
        }
    }
}
