using System;
using System.Linq;
using System.Linq.Expressions;
using WebVaanoli.Domain;

namespace WebVaanoli.Data.Interfaces
{
    public interface IStreamQualityRepository
    {
        StreamQuality Find(string id);
        IQueryable<StreamQuality> FindAll(Expression<Func<StreamQuality, bool>> filter = null);
    }
}
