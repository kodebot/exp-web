using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebVaanoli.Domain;

namespace WebVaanoli.Data
{
    public interface IRadioRepository
    {
        Radio Find(int id);
        IQueryable<Radio> FindAll(Expression<Func<Radio, bool>> filter = null);
    }
}
