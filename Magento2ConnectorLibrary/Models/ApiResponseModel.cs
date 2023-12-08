
using Newtonsoft.Json;

namespace Magento2ConnectorLibrary.Models
{
    public class ApiResponseModel
    {
        [JsonProperty("items")]
        public IList<ItemModel> Items { get; set; }

        [JsonProperty("search_criteria")]
        public SearchCriteriaModel SearchCriteria { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
    }
}
