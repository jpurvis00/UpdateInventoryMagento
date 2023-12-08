
using System.Text.Json;
using UpdateInventoryMagentoUI.Models;

namespace UpdateInventoryMagentoUI
{
    public class GetAllOCInventoryFromAPI
    {
        private readonly HttpClient _client;
        
        public GetAllOCInventoryFromAPI(HttpClient client) 
        {
            _client = client;
        }

        public async Task<List<InventoryModel>> GetAllInventory()
        {
            var response = await _client.GetAsync("https://localhost:7087/api/Inventory");

            if(response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };

                string responseText = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<InventoryModel>>(responseText, options);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
