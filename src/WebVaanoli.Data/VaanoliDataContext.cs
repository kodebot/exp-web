using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.Extensions.OptionsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVaanoli.Common.ConfigOptions;
using WebVaanoli.Data.Interfaces;

namespace WebVaanoli.Data
{
    public class VaanoliDataContext : IVaanoliDataContext, IDisposable
    {
        private const string GENRES_ENTITY_NAME = "";
        private const string STREAM_QUALITIES_ENTITY_NAME = "StreamQualities";
        private const string RADIOS_ENTITY_NAME = "Radios";

        private IFirebaseClient _genresClient;
        private IFirebaseClient _streamQualitiesClient;
        private IFirebaseClient _radiosClient;
        private readonly IOptions<FirebaseOptions> _firebaseOptions;

        public VaanoliDataContext(IOptions<FirebaseOptions> firebaseOptions)
        {
            _firebaseOptions = firebaseOptions;

        }

        public IFirebaseClient Genres
        {
            get
            {
                return _genresClient = _genresClient ?? CreateFirebaseClient(GENRES_ENTITY_NAME);
            }

        }

        public IFirebaseClient StreamQualities
        {
            get
            {
                return _streamQualitiesClient = _streamQualitiesClient ?? CreateFirebaseClient(STREAM_QUALITIES_ENTITY_NAME);
            }

        }

        public IFirebaseClient Radios
        {
            get
            {
                return _radiosClient = _radiosClient ?? CreateFirebaseClient(RADIOS_ENTITY_NAME);
            }

        }

        private IFirebaseClient CreateFirebaseClient(string entityName)
        {
            var firebaseConfig = new FirebaseConfig()
            {
                AuthSecret = "3Y58a7to6BNx4WgCaoBYpNNyPixHLT0I7RWZBW2x",
                BasePath = String.Format("{0}/{1}", _firebaseOptions.Value.VaanoliDatabase, GENRES_ENTITY_NAME)
            };

            return new FirebaseClient(firebaseConfig);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((FirebaseClient)this.Genres).Dispose();
                ((FirebaseClient)this.StreamQualities).Dispose();
                ((FirebaseClient)this.Radios).Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

