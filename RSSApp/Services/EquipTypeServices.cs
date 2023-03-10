﻿using System;
using RSSApp.Models;

namespace RSSApp.Services
{
	public class EquipTypeServices: IEquipTypeRepository
    {

		public EquipTypeServices()
		{
		}


       

      public async Task<List<EquipType>> EquipTypes()
        {
            var clients = new List<EquipType>();
            var client = new HttpClient();
            string url = "https://roofsafetysolutions.azurewebsites.net/api/EquipTypes";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                clients = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EquipType>>(content);
                return await Task.FromResult(clients.ToList());
            }
            return null;
        }
    }
}

