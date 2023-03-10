﻿using System;
using System.Text;
using RSSApp.Models;

namespace RSSApp.Services
{
	public class InspEquipTestService: IInspEquipTestRepository
    {

		public InspEquipTestService()
		{
		}

        public async Task<InspEquipTypeTest> AddNew(InspEquipTypeTest inspEquipTypeTest)
        {
            var client = new HttpClient();
            string bod = Newtonsoft.Json.JsonConvert.SerializeObject(inspEquipTypeTest);
            var stringContent = new StringContent(bod, Encoding.UTF8, "application/json");       
             client.BaseAddress = new Uri(url);        
            HttpResponseMessage response = await client.PostAsync("",stringContent);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
               var ret = Newtonsoft.Json.JsonConvert.DeserializeObject<InspEquipTypeTest>(content);
                return await Task.FromResult(ret);
            }
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.DeleteAsync(id.ToString());
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var ret = Newtonsoft.Json.JsonConvert.DeserializeObject<InspEquipTypeTest>(content);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(InspEquipTypeTest inspEquipTypeTest)
        {
            string bod = Newtonsoft.Json.JsonConvert.SerializeObject(inspEquipTypeTest);
            var stringContent = new StringContent(bod, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.PutAsync(inspEquipTypeTest.id.ToString(), stringContent);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                // ret = Newtonsoft.Json.JsonConvert.DeserializeObject<List<InspEquipTypeTest>>(content);
                return true;// await Task.FromResult(ret.ToList());
            }
            return false;
        }

        public async Task<List<InspEquipTypeTestRpt>> InspTests(int Inspequipid)
        {
            var client = new HttpClient();  
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(Inspequipid.ToString());
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var ret = Newtonsoft.Json.JsonConvert.DeserializeObject<List<InspEquipTypeTestRpt>>(content);
                return await Task.FromResult(ret.ToList());
            }
            return null;
        }

        string url = "https://roofsafetysolutions.azurewebsites.net/api/InspEquipTypeTests/";

       

        public   async Task<InspEquipTypeTest> InspTest(int id)
        {   
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("int/"+id.ToString());
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
               var ret = Newtonsoft.Json.JsonConvert.DeserializeObject<InspEquipTypeTest>(content);
                return await Task.FromResult(ret);
            }
            return null;
        }
    }
}

