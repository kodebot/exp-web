using FireSharp.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebVaanoli.Data.Interfaces;
using WebVaanoli.Domain;

namespace WebVaanoli.Data
{
    public class FirebaseRepository<T> : IFirebaseRepository<T> where T :Entity
    {
        private readonly IFirebaseClient _client;

        public FirebaseRepository(IFirebaseClient client)
        {
            _client = client;
        }
        public string Add(T entity)
        {
            if (entity == null) { throw new ArgumentNullException(nameof(entity)); }

            // push and set to update the Id
            var response = _client.Push("/", entity);
            entity.Id = response.Result.Name;
            _client.Set($"/{entity.Id}/", entity);
            return entity.Id;
        }

        public T Find(string id)
        {
            if (String.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }

            var response = _client.Get($"/{id}/");
            return response.ResultAs<T>();
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> filter = null)
        {
            var result = _client.Get("/");

            var resultEntities = new List<T>();

            // when no genre is present
            if (String.IsNullOrWhiteSpace(result.Body) || result.Body == "null")
            {
                return resultEntities.AsQueryable();
            }

            try
            {
                resultEntities = result.ResultAs<List<T>>();
            }
            catch (JsonSerializationException)// when only one item is returned
            {
                resultEntities.AddRange(result.ResultAs<Dictionary<string, T>>()
                    .AsEnumerable()
                    .Select(item => item.Value)
                    .ToList());
            }

            if (filter != null)
            {
                // TODO: change this to apply the filter on the server side
                return resultEntities.AsQueryable().Where(filter);
            }
            else
            {
                return resultEntities.AsQueryable();
            }
        }

        public void Save(T entity)
        {
            if (entity == null) { throw new ArgumentNullException(nameof(entity)); }
            if (String.IsNullOrWhiteSpace(entity.Id)) { throw new ArgumentNullException(nameof(entity.Id)); }

            _client.Set($"/{entity.Id}/", entity);

        }
    }
}
