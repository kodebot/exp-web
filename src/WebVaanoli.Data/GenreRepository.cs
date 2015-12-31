using Microsoft.Extensions.OptionsModel;
using System;
using System.Collections.Generic;
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
        public string Add(Genre genre)
        {
            if (genre == null) { throw new ArgumentNullException(nameof(genre)); }

            var response = _vaanoliDataContext.Genres.Push("/", genre);
            genre.Id = response.Result.Name;
            _vaanoliDataContext.Genres.Set($"/{genre.Id}/", genre);
            return genre.Id;
        }

        public Genre Find(string id)
        {
            var response = _vaanoliDataContext.Genres.Get($"/{id}/");
            return response.ResultAs<Genre>();
        }

        public IQueryable<Genre> FindAll(Expression<Func<Genre, bool>> filter = null)
        {
            var result = _vaanoliDataContext.Genres.Get("/");
            return result.ResultAs<List<Genre>>().AsQueryable();
            throw new NotImplementedException();
        }

        public void Save(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
