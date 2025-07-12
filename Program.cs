using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eiger_stop_Console_app_01
{
    internal class Program
    {
        private static HttpClient eiger_client = new HttpClient();
        static async Task Main(string[] args)
        {
            Dictionary<string, string> stop_dict = new Dictionary<string, string>();
            string json_stop = JsonConvert.SerializeObject(stop_dict, Formatting.Indented);
            var stop_content = new StringContent(json_stop, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await eiger_client.PutAsync("http://10.10.10.31/detector/api/1.8.0/command/abort", stop_content);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine("Stop is done!");
        }
    }
}
