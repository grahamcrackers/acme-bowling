using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ACME.Domain
{
    public class HttpRemoteDataService : IRemoteDataService
    {
        private readonly string _url;

        public HttpRemoteDataService()
        {
            _url = "https://grn4aewhhg.execute-api.us-east-1.amazonaws.com/prod/games/";
        }

        public GameData Retrieve(string code)
        {
            return JsonConvert.DeserializeObject<GameData>(
                new HttpClient().GetStringAsync(_url + code).Result);
        }
    }
}
