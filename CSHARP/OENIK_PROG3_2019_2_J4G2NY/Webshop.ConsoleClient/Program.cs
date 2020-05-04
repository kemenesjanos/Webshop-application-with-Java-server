using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.ConsoleClient
{
    public class Location
    {
        
        public decimal ID { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public Nullable<decimal> House_Number { get; set; }
        public Nullable<decimal> Zip_Code { get; set; }

        public override string ToString()
        {
            return $"ID={ID}\tCountry={Country}\tStreet={Street}\tHouse_Number={House_Number}\tZip_Code={Zip_Code}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("waiting...");
            Console.ReadKey();

            string url = "http://localhost:63263/api/LocationsApi/";
            using(HttpClient client = new HttpClient())
            {
                string json = client.GetStringAsync(url + "all").Result;
                var list = JsonConvert.DeserializeObject<List<Location>>(json);
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                Console.ReadKey();

                Dictionary<string, string> postData;
                string response;

                postData = new Dictionary<string, string>();
                postData.Add(nameof(Location.Country), "Magyarország");
                postData.Add(nameof(Location.Street), "Alma Dűlő");
                postData.Add(nameof(Location.House_Number), "12");
                postData.Add(nameof(Location.Zip_Code), "4253");
                postData.Add(nameof(Location.ID), "41315");

                response = client.PostAsync(url + "add", new FormUrlEncodedContent
                    (postData)).Result.Content.ReadAsStringAsync().Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("ADD:" + response);
                Console.WriteLine("All:" + json);
                Console.ReadKey();

                postData = new Dictionary<string, string>();
                postData.Add(nameof(Location.Country), "Magyarország");
                postData.Add(nameof(Location.Street), "Alma aholy");
                postData.Add(nameof(Location.House_Number), "12");
                postData.Add(nameof(Location.Zip_Code), "4253");
                postData.Add(nameof(Location.ID), "41315");

                response = client.PostAsync(url + "mod", new FormUrlEncodedContent
                    (postData)).Result.Content.ReadAsStringAsync().Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("MOD:" + response);
                Console.WriteLine("All:" + json);
                Console.ReadKey();

                response = client.GetStringAsync(url + "del/" + "41315").Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("DEL:" + response);
                Console.WriteLine("All:" + json);
                Console.ReadKey();
            }
        }
    }
}
