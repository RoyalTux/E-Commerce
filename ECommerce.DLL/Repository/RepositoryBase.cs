using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using ECommerce.DLL.Context;
using ECommerce.DLL.Extensibility.Repository;

namespace ECommerce.DLL.Repository
{
    internal class RepositoryBase<TDomainEntity, TDataEntity> : IRepositoryBase<TDomainEntity>
        where TDomainEntity : class
        where TDataEntity : class
    {
        private readonly IShopDbContext _shopDbContext;

        public RepositoryBase(IShopDbContext context, IMapper mapper)
        {
            this._shopDbContext = context;
            this.Set = this._shopDbContext.Set<TDataEntity>();
            this.Mapper = mapper;
        }

        protected IDbSet<TDataEntity> Set { get; }

        protected IMapper Mapper { get; }

        public virtual IEnumerable<TDomainEntity> GetAll()
        {
            return this.Mapper.Map<IEnumerable<TDomainEntity>>(this.Set.AsEnumerable());
        }

        public virtual TDomainEntity GetById(int id)
        {
            return this.Mapper.Map<TDomainEntity>(this.Set.Find(id));
        }

        public virtual void Add(TDomainEntity entity)
        {
            var dataEntity = this.Mapper.Map<TDataEntity>(entity);
            this.Set.Add(dataEntity);
        }

        public virtual void Delete(TDomainEntity entity)
        {
            var dataEntity = this.Mapper.Map<TDataEntity>(entity);
            this.Set.Remove(dataEntity);
        }

        public virtual void DeleteById(int id)
        {
            var entity = this.Set.Find(id);
            this.Set.Remove(entity);
        }

        public virtual void Edit(TDomainEntity entity)
        {
            this._shopDbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
