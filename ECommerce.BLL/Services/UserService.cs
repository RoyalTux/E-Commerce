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

        public bool RemoveProduct(ProductDto product, IShoppingCartService lineCollection)
        {
            lineCollection.Products.RemoveAll(l => l.Id == product.Id);

            return true;
        }

        public bool Clear(IShoppingCartService lineCollection)
        {
            lineCollection.Products.Clear();

            return true;
        }
    }
}
