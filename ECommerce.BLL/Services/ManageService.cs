using System;
using AutoMapper;
using ECommerce.BLL.Extensibility;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.BLL.Services
{
    internal class ManageService : IManageService
    {
        private readonly IShopService _db;
        private readonly IMapper _mapper;

        public ManageService(IShopService db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public bool UpdateOrder(OrderDto orderDto)
        {
            try
            {
                var order = this._mapper.Map<Order>(orderDto);
                this._db.Orders.Edit(order);
                this._db.Save();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public OrderDto GetOrder(int id)
        {
            return this._mapper.Map<OrderDto>(this._db.Orders.GetById(id));
        }
    }
}
