using Microsoft.Extensions.OptionsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebVaanoli.Common.ConfigOptions;
using WebVaanoli.Domain;

namespace WebVaanoli.Data
{
    public class GenreRepository : IGenreRepository
    {
        private readonly FirebaseOptions _firebaseOptions;
        public GenreRepository(IOptions<FirebaseOptions> firebaseOptions)
        {
            _firebaseOptions = firebaseOptions.Value;
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
