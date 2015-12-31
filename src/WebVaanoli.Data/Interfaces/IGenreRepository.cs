using System;
using System.Linq;
using System.Linq.Expressions;
using WebVaanoli.Domain;

namespace WebVaanoli.Data.Interfaces
{
    public interface IGenreRepository
    {
        Genre Find(string id);
        IQueryable<Genre> FindAll(Expression<Func<Genre, bool>> filter = null);
        string Add(Genre genre);
        void Save(Genre genre);
    }
}
