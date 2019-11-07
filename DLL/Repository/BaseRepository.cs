using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using DLL.Extensibility;
using DLL.Extensibility.Repository;

namespace DLL.Repository
{
    internal abstract class BaseRepository<TDomainEntity> : IBaseRepository<TDomainEntity>
        where TDomainEntity : class
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
