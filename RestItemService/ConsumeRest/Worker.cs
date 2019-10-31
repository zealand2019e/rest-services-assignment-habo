using ModelLib.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeRest
{
    class Worker
    {

        public void Start()
        {
            //DeleteItem(3);
            Console.WriteLine("GetAll:");
            var t = Task.Run(() => {
                 foreach (var item in GetAllItemsAsync().Result)
                 {
                     Console.WriteLine(JsonConvert.SerializeObject(item));
                 }
             });
            t.Wait();
            Console.WriteLine("getbyid:");
            t = Task.Run(() => {
                Console.WriteLine(JsonConvert.SerializeObject(GetOneItemsAsync(5).Result));
            });
            t.Wait();
            




        }



        public void DeleteItem(int id)
        {
            string sURL = "https://itemservice-habo.azurewebsites.net/api/localitems/" + id;

            WebRequest request = WebRequest.Create(sURL);
            request.Method = "DELETE";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }
        public async Task PostItem(Item item)
        {
            using (HttpClient client = new HttpClient())
            {

                String jsonStr = JsonConvert.SerializeObject(item);
                StringContent content =
                new StringContent(jsonStr, Encoding.UTF8, "application/json");
                HttpResponseMessage dolog = await client.PostAsync("https://itemservice-habo.azurewebsites.net/api/localitems/",content);
                
            }
        }
        public async Task PostItem(int id,Item item)
        {
            using (HttpClient client = new HttpClient())
            {

                String jsonStr = JsonConvert.SerializeObject(item);
                StringContent content =
                new StringContent(jsonStr, Encoding.UTF8, "application/json");
                HttpResponseMessage dolog = await client.PutAsync("https://itemservice-habo.azurewebsites.net/api/localitems/"+id, content);

            }
        }


        public async Task<Item> GetOneItemsAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync("https://itemservice-habo.azurewebsites.net/api/localitems/"+id);
                Item item =
                JsonConvert.DeserializeObject<Item>(content);
                return item;
            }
        } 

        public async Task<IList<Item>> GetAllItemsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync("https://itemservice-habo.azurewebsites.net/api/localitems");
                IList <Item> cList =
                JsonConvert.DeserializeObject<IList<Item>>(content);
                return cList;
            }
        }

    }
}
