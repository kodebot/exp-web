using System;
using System.Linq;
using System.Linq.Expressions;
using WebVaanoli.Domain;

namespace WebVaanoli.Data.Interfaces
{
    public interface IRadioRepository
    {
        Radio Find(int id);
        IQueryable<Radio> FindAll(Expression<Func<Radio, bool>> filter = null);
    }
}
