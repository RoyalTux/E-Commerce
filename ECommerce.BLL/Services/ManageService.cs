using AutoMapper;
using ECommerce.BLL.Extensibility;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.DLL.Extensibility.Entities;
using ECommerce.DLL.Extensibility.Repository;

namespace ECommerce.BLL.Services
{
    public class ManageService : IManageService
    {
        private readonly IRepositoryBase<Order> _orderDb;
        private readonly IMapper _mapper;

        public ManageService(
            IRepositoryBase<Order> orderDb,
            IMapper mapper)
        {
            this._orderDb = orderDb;
            this._mapper = mapper;
        }

        public bool UpdateOrder(OrderDto orderDto)
        {
            var order = this._mapper.Map<Order>(orderDto);
            this._orderDb.Edit(order);

            return true;
        }

        public OrderDto GetOrder(int id)
        {
            return this._mapper.Map<OrderDto>(this._orderDb.GetById(id));
        }
    }
}
