using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataFiller
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            var sw = new Stopwatch();

            var values = new Dictionary<string, string>
                    {
                        {
                            "DATA137",
                            "000019134D74732E6279000000000000000000011508252144550000CC4100002042CDCC2842CDCC1A4200000E42CDCCA842CDCC1E426666DE419A99C141008009440000E14300802244009C05BC0000FC3F35"
                        }
                    };
            using (var client = new HttpClient())
            {
                for (var i = 0; i < 1000; i++)
                {
                    sw.Start();
                    
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("http://trainsmonitor.net/Trains", content);

                    sw.Stop();
                    var responseString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Elapsed = {0}, Record No = {1}, response {2}", sw.Elapsed, i, responseString);
                }
            }

            Console.ReadKey();
        }
    }
}
