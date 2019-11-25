using System.Collections.Generic;
using AutoMapper;
using ECommerce.BLL.Extensibility;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.DLL.Extensibility.Repository;

namespace ECommerce.BLL.Services
{
    public class CartLineService : ICartLineService
    {
        private readonly IRepositoryBase<ProductDto> _productDb;
        private readonly IMapper _mapper;

        public CartLineService(
            IRepositoryBase<ProductDto> productDb,
            IMapper mapper)
        {
            this._productDb = productDb;
            this._mapper = mapper;
        }

        public bool AddProduct(ProductDto product, int quantity, ICartLineService lineCollection = new List<ProductDto>)
        {
            if (product != null)
            {
                lineCollection.Add(new ProductDto
                {
                    Name = _productDb.GetById(product.Id).ToString(),
                    Quantity = quantity,
                });
            }

            return true;
        }

        public bool RemoveProduct(ProductDto product, ICartLineService lineCollection)
        {
            lineCollection.Products.RemoveAll(l => l.Id == product.Id);

            return true;
        }
    }
}
