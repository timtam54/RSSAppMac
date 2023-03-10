using System;
using System.Text;

using RSSApp.Models;

namespace RSSApp.Services
{
	public class InspectionServices: IInspectionRepository
    {

		public InspectionServices()
		{
		}

        public async Task<Inspection> AddNew(Inspection inspection)
        {
       
                var client = new HttpClient();
                string bod = Newtonsoft.Json.JsonConvert.SerializeObject(inspection);
                var stringContent = new StringContent(bod, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.PostAsync("", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    var ret = Newtonsoft.Json.JsonConvert.DeserializeObject<Inspection>(content);
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
                //string content = response.Content.ReadAsStringAsync().Result;
                //var ret = Newtonsoft.Json.JsonConvert.DeserializeObject<Inspection>(content);
                return true;
            }
            return false;
        }

        public async Task<Inspection> Inspection(int id)
        {
            try
            {
                var inspections = new Inspection();
                var client = new HttpClient();
                string url = "https://roofsafetysolutions.azurewebsites.net/api/inspections/"+id.ToString();
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    inspections = Newtonsoft.Json.JsonConvert.DeserializeObject<Inspection>(content);
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
        string url = "https://roofsafetysolutions.azurewebsites.net/api/inspections/";

        public async Task<List<InspectionView>> Inspections()
        {
            try
            {
                var inspections = new List<InspectionView>();
                var client = new HttpClient();
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    inspections = Newtonsoft.Json.JsonConvert.DeserializeObject<List<InspectionView>>(content);
                    return await Task.FromResult(inspections.ToList());
                }
            }
            catch (Exception ex)
            {
                var dd = ex.Message;
                var mm = dd;
            }
            return null;
        }

        public async Task<bool> Update(Inspection inspection)
        {
            string bod = Newtonsoft.Json.JsonConvert.SerializeObject(inspection);
            var stringContent = new StringContent(bod, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.PutAsync(inspection.id.ToString(), stringContent);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                // ret = Newtonsoft.Json.JsonConvert.DeserializeObject<List<InspEquipTypeTest>>(content);
                return true;// await Task.FromResult(ret.ToList());
            }
            return false;
        }

     /*   public async Task<List<InspEquipTypeTestRpt>> InspTests(int Inspequipid)
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

    

        public async Task<InspEquipTypeTest> InspTest(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("int/" + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var ret = Newtonsoft.Json.JsonConvert.DeserializeObject<InspEquipTypeTest>(content);
                return await Task.FromResult(ret);
            }
            return null;
        }*/
    }
}

