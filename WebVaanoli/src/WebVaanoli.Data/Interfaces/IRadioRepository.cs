using System;
using System.Linq;
using System.Linq.Expressions;
using WebVaanoli.Domain;

namespace WebVaanoli.Data.Interfaces
{
    public interface IRadioRepository
    {
        Radio Find(string id);
        IQueryable<Radio> FindAll(Expression<Func<Radio, bool>> filter = null);
        string Add(Radio radio);
        void Save(Radio radio);
    }
}
