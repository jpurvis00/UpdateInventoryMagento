
using Magento2ConnectorLibrary.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Magento2ConnectorLibrary
{
    public class UpdateInventoryQuantity
    {
        private RestClient _client { get; set; }

        public UpdateInventoryQuantity(string magentoUrl, string token)
        {
            _client = new RestClient(magentoUrl);
        }

        public bool UpdateProductQty(MagentoSourceItemsModel updateFollowingInventoryItems, string token)
        {
            var request = CreateRequest("/rest/all/V1/inventory/source-items", Method.Post, token);

            string json = JsonConvert.SerializeObject(updateFollowingInventoryItems, Formatting.Indented);

            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = _client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private RestRequest CreateRequest(string endPoint, Method method, string token)
        {
            var request = new RestRequest(endPoint, method);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Accept", "application/json");
            return request;
        }
    }
}