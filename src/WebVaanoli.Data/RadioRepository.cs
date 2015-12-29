using GenFu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebVaanoli.Data.Interfaces;
using WebVaanoli.Domain;

namespace WebVaanoli.Data
{
    public class RadioRepository : IRadioRepository
    {
        private static IList<Radio> _radios;

        public RadioRepository()
        {
            if (_radios == null)
            {
                _radios = A.ListOf<Radio>();
            }
        }
        public Radio Find(int id)
        {
            return _radios.FirstOrDefault(item => item.Id == id);
        }

        public IQueryable<Radio> FindAll(Expression<Func<Radio, bool>> filter = null)
        {
            if (filter == null) return _radios.AsQueryable();
            return _radios.AsQueryable().Where(filter);
        }
    }
}
