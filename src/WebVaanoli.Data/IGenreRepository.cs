using System;
using System.Linq;
using System.Linq.Expressions;
using WebVaanoli.Domain;

namespace WebVaanoli.Data
{
    public interface IGenreRepository
    {
        Genre Find(int id);
        IQueryable<Genre> FindAll(Expression<Func<Genre, bool>> filter = null);
        int Add(Genre genre);
    }
}
