using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web;

namespace ReadTrial1.Data
{
    public class GenderApparelService : IGenderApparelService
    {
        private readonly HttpClient _client;
        public GenderApparelService(HttpClient client)
        {
            _client = client;
        }
        public  Task<GenderApparel[]> GetProductByGenderId()
        {
            //var apparel= await _client.GetFromJsonAsync<GenderApparel[]>("api/ReadValues/7");
            //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GenderApparel));
            //MemoryStream msobj = new MemoryStream();
            //serializer.WriteObject(msobj, apparel);
            //msobj.Position = 0;
            //StreamReader sr = new StreamReader(msobj);
            //string a = sr.ReadToEnd();
            //sr.Close();
            //msobj.Close();
            //
            ////var a = _client.GetAsync("api/ReadValues/7");
            //DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(GenderApparel));
            //GenderApparel Obj = (GenderApparel)deserializer.ReadObject(msobj);




            //var result = await System.Text.Json.JsonSerializer.Deserialize<GenderApparel>(a);


            var responseTask =  _client.GetAsync("api/ReadValues/api/1");
            responseTask.Wait();
            var res = responseTask.Result;
            if(res.IsSuccessStatusCode)
            {
                var readTask = res.Content.ReadAsAsync<GenderApparel[]>();
                readTask.Wait();
                return readTask;
            }
            else
            {
                throw new Exception("CouldnotFind");
            }

        }

        
    }
}
