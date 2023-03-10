using System;
using RSSApp.Models;

namespace RSSApp.Services
{
	public class InspPhotoServices: IInspPhotoRepository
    {

		public InspPhotoServices()
		{
		}

       /* public async Task<InspPhoto> InspItem(int Inspphotoid)
        {
            var ret = new InspEquip();
            var client = new HttpClient();
            string url = "https://roofsafetysolutions.azurewebsites.net/api/inspphotos/" + Inspphotoid.ToString();
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                ret = Newtonsoft.Json.JsonConvert.DeserializeObject<InspEquip>(content);
                return await Task.FromResult(ret);
            }
            return null;
        }*/

        public async Task<List<InspPhoto>> InspPhotos(int Inspequipid)
        {
            var ret = new List<InspPhoto>();
            var client = new HttpClient();
            string url = "https://roofsafetysolutions.azurewebsites.net/api/inspphotos/"+ Inspequipid.ToString();
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                ret = Newtonsoft.Json.JsonConvert.DeserializeObject<List<InspPhoto>>(content);
                return await Task.FromResult(ret.ToList());
            }
            return null;
        }
        
    }
}

