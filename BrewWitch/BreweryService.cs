using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace BrewWitch
{
    public class BreweryService
    {   
        HttpClient client = new HttpClient();
        const string baseURL = "https://api.openbrewerydb.org/v1/";

        public async Task<List<Brewery>> GetBreweriesAsync(string searchParam)
        {
            string apiURL = $"{baseURL}breweries?by_city={searchParam.Trim()}";
            

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,apiURL);

            // if header add
            // request.Headers.Add("apiKey"...)

            HttpResponseMessage response = await client.SendAsync(request);

            if(!response.IsSuccessStatusCode)
            {
                //log
                //return
                throw new HttpRequestException($"Server Responded with: {response.StatusCode}");
            }

            string contentString = await response.Content.ReadAsStringAsync();

            //converts to our brewery object  
            List<Brewery> Breweries = JsonConvert.DeserializeObject<List<Brewery>>(contentString) ?? [];
            
            return Breweries;
        }
    }
}