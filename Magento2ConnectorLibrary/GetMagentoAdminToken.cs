
using Magento2ConnectorLibrary.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Magento2ConnectorLibrary
{
    public class GetMagentoAdminToken
    {
        private RestClient _client { get; set; }

        public GetMagentoAdminToken(string magentoUrl)
        {
            _client = new RestClient(magentoUrl);
        }

        public string GetAdminToken(string userName, string password)
        {
            var request = CreateRequest("/rest/V1/integration/admin/token", Method.Post);

            var user = new CredentialsModel();
            user.username = userName;
            user.password = password;

            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = _client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Content;
            }
            else
            {
                //Should probably throw an exception here.
                return "";
            }
        }

        private RestRequest CreateRequest(string endPoint, Method method)
        {
            var request = new RestRequest(endPoint, method);
            request.RequestFormat = DataFormat.Json;
            return request;
        }
    }
}