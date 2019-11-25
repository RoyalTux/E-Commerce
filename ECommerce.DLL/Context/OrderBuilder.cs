﻿using System.Data.Entity;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.Context
{
    public class OrderBuilder
    {
        public static void BuildOrder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDataEntity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<OrderDataEntity>()
                .Property(x => x.Price)
                .HasPrecision(9, 2)
                .IsRequired();

            modelBuilder.Entity<OrderDataEntity>()
                .Property(x => x.Time)
                .IsRequired();

            modelBuilder.Entity<OrderDataEntity>()
                .HasRequired(x => x.UserProfile);

            modelBuilder.Entity<OrderDataEntity>()
                .HasMany(x => x.OrderLines);
        }
    }
}