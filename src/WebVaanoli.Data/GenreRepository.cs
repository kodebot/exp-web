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
            if (genre == null) { throw new ArgumentNullException(nameof(genre)); }

            var response = _vaanoliDataContext.Genres.Push("genres.json", genre);
            var addedGenre = response.ResultAs<Genre>();
            return addedGenre.Id;
        }

        public Genre Find(int id)
        {
            var response = _vaanoliDataContext.Genres.Get($"{id}");
            return response.ResultAs<Genre>();
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
