using System;
using System.Linq;
using AutoMapper;
using ECommerce.BLL.Extensibility;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.DLL.Extensibility.Entities;
using ECommerce.DLL.Extensibility.Repository;

namespace ECommerce.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryBase<Product> _productDb;
        private readonly IMapper _mapper;

        public UserService(
            IRepositoryBase<Product> productDb,
            IMapper mapper)
        {
            this._productDb = productDb;
            this._mapper = mapper;
        }

        public bool AddProduct(ProductDto product, int quantity, IShoppingCart lineCollection)
        {
            try
            {
                if (product != null)
                {
                    //lineCollection.Products.Add(new Product
                    //{
                    //    Name = this._mapper.Map<ProductDto>(this._productDb.GetById(product.Id)),
                    //    Quantity = quantity,
                    //});
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
                lineCollection.Products.RemoveAll(l => l.Id == product.Id);
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
                lineCollection.Products.Clear();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public CartDto ComposeCart(IShoppingCart lineCollection)
        {
            decimal cartPrice = lineCollection.Products.Sum(product => product.Price);

            var cart = new CartDto
            {
                Products = lineCollection.Products,
                OverallPrice = cartPrice,
                Quantity = lineCollection.Quantity,
            };

            return cart;
        }

        //public OrderDto MakeOrder(Order cart)
        //{
        //    var products = cart.Products.Select(product => product.Product).ToList();
        //    var order = new OrderDto
        //    {
        //        Products = products,
        //        Time = System.DateTime.Now,
        //        Price = products.Sum(x => x.Price),
        //        State = StateDto.InProcess,
        //    };

        //    return order;
        //}
    }
}
