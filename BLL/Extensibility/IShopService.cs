﻿using System;
using DLL.Extensibility.Repository;

namespace BLL.Extensibility
{
    public interface IShopService : IDisposable
    {
        ICategoryRepository Categories { get; }

        IItemRepository Products { get; }

        IOrderRepository Orders { get; }

        int Save();
    }
}
