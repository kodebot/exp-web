using System;
using System.Linq;
using System.Linq.Expressions;
using WebVaanoli.Domain;

namespace WebVaanoli.Data.Interfaces
{
    public interface IFirebaseRepository<T> where T : Entity
    {
        string Add(T entity);
        T Find(string id);
        IQueryable<T> FindAll(Expression<Func<T, bool>> filter = null);
        void Save(T entity);
    }
}