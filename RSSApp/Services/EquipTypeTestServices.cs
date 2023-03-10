using System;
using System.Text;

using RSSApp.Models;

namespace RSSApp.Services
{
	public class EquipTypeTestServices : IEquipTypeTestRepository
    {
        public async Task<EquipTypeTest> AddNew(EquipTypeTest equipTypeTest)
        {
            var client = new HttpClient();
            string bod = Newtonsoft.Json.JsonConvert.SerializeObject(equipTypeTest);
            var stringContent = new StringContent(bod, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.PostAsync("", stringContent);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var ret = Newtonsoft.Json.JsonConvert.DeserializeObject<EquipTypeTest>(content);
                return await Task.FromResult(ret);
            }
            return null;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        string url = "https://roofsafetysolutions.azurewebsites.net/api/EquipTypeTests/";

        public async Task<List<EquipTypeTest>> EquipTypeTests(int EquipTypeID)
        {
            var clients = new List<EquipTypeTest>();
            var client = new HttpClient();

            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(EquipTypeID.ToString());
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                clients = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EquipTypeTest>>(content);
                return await Task.FromResult(clients.ToList());
            }
            return null;
        }

        public Task<EquipTypeTest> InspItem(int EquipTypeID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(EquipTypeTest equipTypeTest)
        {
            throw new NotImplementedException();
        }
    }
}

