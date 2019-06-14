using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Http;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using IdentityModel.Client;
using WebApplication1.MiddleWare;

namespace WebApplication1.ExternalAPI
{
    public class APICall : MiddleWareTech
    {
        public string apiUrl;
        public string accessToken;

        public async Task<string> CallExtAPI(string resource, string accessToken)
        {
            const int LIMIT = 3;  // 1 = no retry

            int tries = 0;
            string res = "";
            do
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("x-access-token", accessToken);
                    string result = "";
                    using (HttpResponseMessage t = await httpClient.GetAsync(resource))
                    if (t.StatusCode == HttpStatusCode.OK)
                    {
                        using (HttpContent content = t.Content)
                        {

                            res = await content.ReadAsStringAsync();
                            //res = JsonConvert.DeserializeObject<byte[]>(result);
                            return res;
                        }
                    }
                }

            } while (++tries < LIMIT);
            return res; // Not 200 but return it anyway after a few tries
        }
    }
}
