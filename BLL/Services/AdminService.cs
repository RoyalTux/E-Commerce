using System;
using AutoMapper;
using BLL.Extensibility;
using BLL.Extensibility.Dto;
using DLL.Extensibility.Entities;

namespace BLL.Services
{
    internal class AdminService : IAdminService
    {
        private readonly IShopService _db;
        private readonly IMapper _mapper;

        public AdminService(IShopService db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public bool AddCategory(CategoryDto categoryDto)
        {
            try
            {
                var category = this._mapper.Map<Category>(categoryDto);
                this._db.Categories.Add(category);
                this._db.Save();
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
                this._db.Categories.Edit(category);
                this._db.Save();
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
                this._db.Categories.DeleteById(id);
                this._db.Save();
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
                this._db.Products.Add(item);
                this._db.Save();
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
                this._db.Products.Edit(item);
                this._db.Save();
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
                this._db.Products.DeleteById(id);
                this._db.Save();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public CategoryDto GetCategory(int id)
        {
            return this._mapper.Map<CategoryDto>(this._db.Categories.GetById(id));
        }

        public ProductDto GetProduct(int id)
        {
            return this._mapper.Map<ProductDto>(this._db.Products.GetById(id));
        }

        public OrderDto GetOrder(int id)
        {
            return this._mapper.Map<OrderDto>(this._db.Orders.GetById(id));
        }

        public void Dispose(bool disposing)
        {
            this._db.Dispose();
        }
    }
}
