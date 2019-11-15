using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using ECommerce.DLL.Extensibility;
using ECommerce.DLL.Extensibility.Repository;

namespace ECommerce.DLL.Repository
{
    internal abstract class BaseRepository<TDomainEntity, TDataEntity> : IBaseRepository<TDomainEntity>
        where TDomainEntity : class
        where TDataEntity : class
    {
        private readonly IShopDbContext _shopDbContext;

        protected BaseRepository(IShopDbContext context, IMapper mapper)
        {
            this._shopDbContext = context;
            this.Set = this._shopDbContext.Set<TDomainEntity>();
            this.Mapper = mapper;
        }

        protected IDbSet<TDomainEntity> Set { get; }

        protected IMapper Mapper { get; }

        public virtual IEnumerable<TDomainEntity> GetAll()
        {
            return this.Mapper.Map<IEnumerable<TDomainEntity>>(this.Set.AsEnumerable());
        }

        public virtual TDataEntity GetById(int id)
        {
            return this.Mapper.Map<TDataEntity>(this.Set.Find(id));
        }

        public virtual void Add(TDomainEntity entity)
        {
            this.Set.Add(entity);
        }

        public virtual void Delete(TDomainEntity entity)
        {
            this.Set.Remove(entity);
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
