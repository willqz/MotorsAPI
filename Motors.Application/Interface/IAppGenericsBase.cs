using System;
using System.Collections.Generic;
using System.Text;

namespace Motors.Application.Interface
{
    public interface IAppGenericsBase<TEntity> where TEntity : class
    {
        void Add(TEntity t);

        void Update(TEntity t);

        void Delete(int id);

        List<TEntity> ListAll(bool lazyLoading);

        TEntity GetById(int id);

        TEntity GetAsNoTrackingById(int id);

        void AddRange(IEnumerable<TEntity> t);
    }
}
