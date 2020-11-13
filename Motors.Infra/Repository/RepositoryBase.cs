using Microsoft.EntityFrameworkCore;
using Motors.Domain.Interface.InterfaceBase;
using Motors.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Motors.Infra.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IGenericsBase<TEntity> where TEntity : class
    {
        private DbContextOptionsBuilder<Contexto> _OptionsBuilder;

        public RepositoryBase()
        {
            _OptionsBuilder = new DbContextOptionsBuilder<Contexto>();
        }

        ~RepositoryBase()
        {
            Dispose(false);
        }

        public void Add(TEntity t)
        {
            Contexto _db = new Contexto();
            _db.Add(t);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Contexto _db = new Contexto();
            var obj = _db.Set<TEntity>().Find(id);
            _db.Remove(obj);
            _db.SaveChanges();
        }

        public List<TEntity> ListAll(bool lazyLoading)
        {
            Contexto _db = new Contexto();
            if (lazyLoading)
                return _db.Set<TEntity>().ToList();

            return _db.Set<TEntity>().AsNoTracking().ToList();
        }

        public void Update(TEntity t)
        {
            using (Contexto _db = new Contexto())
            {
                _db.Update(t);
                _db.SaveChanges();
            }
        }

        public TEntity GetById(int id)
        {
            Contexto _db = new Contexto();
            return _db.Set<TEntity>().Find(id);
        }

        public TEntity GetAsNoTrackingById(int id)
        {
            Contexto _db = new Contexto();
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var model = _db.Set<TEntity>().Find(id);
            return model;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool Status)
        {
            if (!Status)
                return;
        }

        public void AddRange(IEnumerable<TEntity> t)
        {
            Contexto _db = new Contexto();
            _db.AddRange(t);
            _db.SaveChanges();
        }
    }
}
