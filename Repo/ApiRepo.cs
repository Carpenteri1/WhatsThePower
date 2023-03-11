using Newtonsoft.Json;
using WhatsThePower.Models;

namespace WhatsThePower.Repo
{
    public class ApiRepo
    {
        private static readonly string apiUri = "https://www.elprisetjustnu.se/api/v1/prices/";
        HttpClient HttpClient { get; }
        public async Task<List<PrisingModel>> GetData(string request) => 
            await DeserializeData(await HttpClient.GetAsync(apiUri + request));
        private async Task<List<PrisingModel>> DeserializeData(HttpResponseMessage responseMessage) =>
            responseMessage.IsSuccessStatusCode? 
            JsonConvert.DeserializeObject<List<PrisingModel>>(
                await responseMessage.Content.ReadAsStringAsync()) : null;
        public ApiRepo()
        {
            HttpClient = new HttpClient();
        }
    }
}
