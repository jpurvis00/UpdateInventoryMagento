
using Magento2ConnectorLibrary.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Magento2ConnectorLibrary
{
    public class GetSkus
    {
        private RestClient _client { get; set; }

        public GetSkus(string magentoUrl)
        {
            _client = new RestClient(magentoUrl);
        }

        public GetSkus(string magentoUrl, string token)
        {
            _client = new RestClient(magentoUrl);
        }

        public ApiResponseModel GetAllSkus(ApiResponseModel apiResponse, int currentPage, string token)
        {
            ApiResponseModel apiPagedResults = new ApiResponseModel();
            var searchQty = 300;
            var sortField = "Sku";
            var sortOrderDirection = "ASC";

            var request = CreateRequest($"/rest/all/V1/inventory/source-items?searchCriteria%5BsortOrders%5D%5B0%5D%5Bfield%5D={sortField}" +
                $"&searchCriteria%5BsortOrders%5D%5B0%5D%5Bdirection%5D={sortOrderDirection}&searchCriteria%5BpageSize%5D={searchQty}" +
                $"&searchCriteria%5BcurrentPage%5D={currentPage}", Method.Get, token);

            var response = _client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                apiPagedResults = JsonConvert.DeserializeObject<ApiResponseModel>(response.Content);
            }

            if (apiResponse.Items == null)
            {
                apiResponse = apiPagedResults;
            }
            else
            {
                foreach (var item in apiPagedResults.Items)
                {
                    apiResponse.Items.Add(item);
                }
            }

            return apiResponse;
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