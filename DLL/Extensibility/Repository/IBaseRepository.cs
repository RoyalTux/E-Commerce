using System.Collections.Generic;

namespace DLL.Extensibility.Repository
{
    public interface IBaseRepository<TDomainEntity>
        where TDomainEntity : class
    {
        IEnumerable<TDomainEntity> GetAll();

        void Add(TDomainEntity entity);

        void Delete(TDomainEntity entity);

        void DeleteById(int id);

        void Edit(TDomainEntity entity);
    }
}
