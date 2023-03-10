using System;
using RSSApp.Models;

namespace RSSApp.Services
{
	public class ClientServices: IClientRepository
    {

		public ClientServices()
		{
		}


        public async Task<List<Client>> Clients()
        {
            var clients = new List<Client>();
            var client = new HttpClient();
            string url = "https://roofsafetysolutions.azurewebsites.net/api/clients";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                clients = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Client>>(content);
                return await Task.FromResult(clients.ToList());
            }
            return null;
        }
    }
}

