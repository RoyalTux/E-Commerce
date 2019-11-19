using System.Collections.Generic;

namespace ECommerce.DLL.Extensibility.Repository
{
    public interface IRepositoryBase<TDomainEntity>
        where TDomainEntity : class
    {
        IEnumerable<TDomainEntity> GetAll();

        TDomainEntity GetById(int id);

        void Add(TDomainEntity entity);

        void Delete(TDomainEntity entity);

        void DeleteById(int id);

        void Edit(TDomainEntity entity);
    }
}
