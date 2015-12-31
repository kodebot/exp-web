using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebVaanoli.Data.Tests.TestHelpers
{
    public static class FirebaseClientTestHelper
    {
        public static PushResponse CreatePushResponse<T>(T responseData, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var response = new HttpResponseMessage();
            return new PushResponse(JsonConvert.SerializeObject(responseData), statusCode, response);
        }

        public static FirebaseResponse CreateResponse<T>(T responseData, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var response = new HttpResponseMessage();
            return new FirebaseResponse(JsonConvert.SerializeObject(responseData), statusCode, response);
        }

        public static SetResponse CreateSetResponse<T>(T responseData, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var response = new HttpResponseMessage();
            return new SetResponse(JsonConvert.SerializeObject(responseData), statusCode, response);
        }
    }
}
