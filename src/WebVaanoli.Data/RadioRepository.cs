using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebVaanoli.Data.Interfaces;
using WebVaanoli.Domain;

namespace WebVaanoli.Data
{
    public class RadioRepository : IRadioRepository
    {
        private readonly IFirebaseRepository<Radio> _firebaseRadioRepository;
        public RadioRepository(IFirebaseRepository<Radio> firebaseRadioRepository)
        {
            _firebaseRadioRepository = firebaseRadioRepository;
        }

        public string Add(Radio radio)
        {
            return _firebaseRadioRepository.Add(radio);
        }

        public Radio Find(string id)
        {
            return _firebaseRadioRepository.Find(id);
        }

        public IQueryable<Radio> FindAll(Expression<Func<Radio, bool>> filter = null)
        {
            return _firebaseRadioRepository.FindAll(filter);
        }

        public void Save(Radio radio)
        {
            _firebaseRadioRepository.Save(radio);

        }
    }
}
