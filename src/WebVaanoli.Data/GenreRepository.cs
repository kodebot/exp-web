using Microsoft.Extensions.OptionsModel;
using System;
using System.Linq;
using System.Linq.Expressions;
using WebVaanoli.Common.ConfigOptions;
using WebVaanoli.Data.Interfaces;
using WebVaanoli.Domain;

namespace WebVaanoli.Data
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IVaanoliDataContext _vaanoliDataContext;

        public GenreRepository(IVaanoliDataContext vaanoliDataContext)
        {
            _vaanoliDataContext = vaanoliDataContext;
        }
        public int Add(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Genre Find(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Genre> FindAll(Expression<Func<Genre, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Save(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
