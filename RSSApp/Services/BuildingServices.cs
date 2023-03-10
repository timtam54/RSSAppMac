using System;
using RSSApp.Models;

namespace RSSApp.Services
{
	public class BuildingServices: IBuildingRepository
    {
      
        public async Task<List<Building>> Buildings()
        {
            try
            {
                List<Building> inspections;
                var client = new HttpClient();
                string url = "https://roofsafetysolutions.azurewebsites.net/api/Buildings" ;
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    inspections = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Building>>(content);
                    return await Task.FromResult(inspections);
                }
            }
            catch (Exception ex)
            {
                var dd = ex.Message;
                var mm = dd;
            }
            return null;
        }
    }
}

