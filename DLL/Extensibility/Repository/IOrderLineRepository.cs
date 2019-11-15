﻿using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.DLL.Extensibility.Repository
{
    public interface IOrderLineRepository<TDataEntity> : IBaseRepository<OrderLine>
        where TDataEntity : class
    {
        TDataEntity GetById(int id);
    }
}
