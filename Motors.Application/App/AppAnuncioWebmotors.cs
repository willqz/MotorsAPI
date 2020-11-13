using Motors.Application.Interface;
using Motors.Domain.Entidades;
using Motors.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motors.Application.App
{
    public class AppAnuncioWebmotors : IAppAnuncioWebmotors
    {
        readonly IAnuncioWebmotors _IAnuncioWebmotors;

        public AppAnuncioWebmotors(IAnuncioWebmotors IAnuncioWebmotors)
        {
            _IAnuncioWebmotors = IAnuncioWebmotors;
        }

        public void Add(TbAnuncioWebmotors t)
        {
            _IAnuncioWebmotors.Add(t);
        }

        public void AddRange(IEnumerable<TbAnuncioWebmotors> t)
        {
            _IAnuncioWebmotors.AddRange(t);
        }

        public void Delete(int id)
        {
            _IAnuncioWebmotors.Delete(id);
        }

        public TbAnuncioWebmotors GetAsNoTrackingById(int id)
        {
            return _IAnuncioWebmotors.GetAsNoTrackingById(id);
        }

        public TbAnuncioWebmotors GetById(int id)
        {
            return _IAnuncioWebmotors.GetById(id);
        }

        public List<TbAnuncioWebmotors> ListAll(bool lazyLoading)
        {
            return _IAnuncioWebmotors.ListAll(lazyLoading);
        }

        public void Update(TbAnuncioWebmotors t)
        {
            _IAnuncioWebmotors.Update(t);
        }
    }
}
