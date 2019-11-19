using System;
using AutoMapper;
using ECommerce.BLL.Extensibility;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.DLL.Extensibility.Entities;
using ECommerce.DLL.Extensibility.Repository;

namespace ECommerce.BLL.Services
{
    internal class AdminService : IAdminService
    {
        private readonly IRepositoryBase<Category> _categoryDb;
        private readonly IRepositoryBase<Order> _orderDb;
        private readonly IRepositoryBase<Product> _productDb;
        private readonly IMapper _mapper;

        public AdminService(
            IRepositoryBase<Category> categoryDb,
            IRepositoryBase<Order> orderDb,
            IRepositoryBase<Product> productDb,
            IMapper mapper)
        {
            this._categoryDb = categoryDb;
            this._orderDb = orderDb;
            this._productDb = productDb;
            this._mapper = mapper;
        }

        public bool AddCategory(CategoryDto categoryDto)
        {
            try
            {
                var category = this._mapper.Map<Category>(categoryDto);
                this._categoryDb.Add(category);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateCategory(CategoryDto categoryDto)
        {
            try
            {
                var category = this._mapper.Map<Category>(categoryDto);
                this._categoryDb.Edit(category);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool RemoveCategory(int id)
        {
            try
            {
                this._categoryDb.DeleteById(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool AddProduct(ProductDto productDto)
        {
            try
            {
                var item = this._mapper.Map<Product>(productDto);
                this._productDb.Add(item);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateProduct(ProductDto productDto)
        {
            try
            {
                var item = this._mapper.Map<Product>(productDto);
                this._productDb.Edit(item);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool RemoveProduct(int id)
        {
            try
            {
                this._productDb.DeleteById(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public CategoryDto GetCategory(int id)
        {
            return this._mapper.Map<CategoryDto>(this._categoryDb.GetById(id));
        }

        public ProductDto GetProduct(int id)
        {
            return this._mapper.Map<ProductDto>(this._productDb.GetById(id));
        }

        public OrderDto GetOrder(int id)
        {
            return this._mapper.Map<OrderDto>(this._orderDb.GetById(id));
        }
    }
}
