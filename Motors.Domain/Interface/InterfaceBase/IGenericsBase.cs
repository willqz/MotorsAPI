using System.Collections.Generic;

namespace Motors.Domain.Interface.InterfaceBase
{
    public interface IGenericsBase<TEntity> where TEntity : class
    {
        void Add(TEntity t);

        void Update(TEntity t);

        void Delete(int id);

        List<TEntity> ListAll(bool lazyloading);

        TEntity GetById(int Id);

        TEntity GetAsNoTrackingById(int id);

        void AddRange(IEnumerable<TEntity> t);
    }
}
