using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebVaanoli.Data.Interfaces;
using WebVaanoli.Domain;

namespace WebVaanoli.Data
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IFirebaseRepository<Genre> _firebaseGenreRepository;
        public GenreRepository(IFirebaseRepository<Genre> firebaseGenreRepository)
        {
            _firebaseGenreRepository = firebaseGenreRepository;
        }

        public string Add(Genre genre)
        {
            return _firebaseGenreRepository.Add(genre);
        }

        public Genre Find(string id)
        {
            return _firebaseGenreRepository.Find(id);
        }

        public IQueryable<Genre> FindAll(Expression<Func<Genre, bool>> filter = null)
        {
            return _firebaseGenreRepository.FindAll(filter);
        }

        public void Save(Genre genre)
        {
            _firebaseGenreRepository.Save(genre);

        }
    }
}
