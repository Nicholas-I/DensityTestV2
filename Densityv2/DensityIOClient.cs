using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Densityv2
{
    public class DensityIOClient
    {
        private string _baseUrl = "https://api.density.io/v2/";
        private string _authToken = "tok_Un7Qj5gCQ3mNsPRkvGMLMcEYRtYZsVXxZUIVgQJeJpk";

        public HttpClient densityHttpClient;

        public DensityIOClient()
        {
            densityHttpClient = new HttpClient{BaseAddress = new Uri(_baseUrl), DefaultRequestHeaders = {Authorization = AuthenticationHeaderValue.Parse($"Bearer {_authToken}")}};
        }

        public async Task<List<Space>> ListSpaces()
        {
            var result = await densityHttpClient.GetAsync("spaces");
            if (!result.IsSuccessStatusCode)
            {
                Console.Write(result.StatusCode);
            }

            var listOfSpaces = JsonConvert.DeserializeObject<SpaceResult>(result.Content.ReadAsStringAsync().Result);
            if (listOfSpaces == null)
            {
                Console.Write("No data could be retrieved");
                return null;
            }

            var spaces = listOfSpaces.Results;

            return spaces;
        }
    }
}
