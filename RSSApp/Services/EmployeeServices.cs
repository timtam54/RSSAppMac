using System;
using RSSApp.Models;

namespace RSSApp.Services
{
	public class EmployeeServices: IEmployeeRepository
    {
      
        public async Task<List<Employee>> Employees()
        {
            try
            {
                List<Employee> inspections;
                var client = new HttpClient();
                string url = "https://roofsafetysolutions.azurewebsites.net/api/Employees" ;
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    inspections = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(content);
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

