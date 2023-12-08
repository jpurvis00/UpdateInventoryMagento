using Newtonsoft.Json;

namespace Magento2ConnectorLibrary.Models
{
    public class SearchCriteriaModel
    {

        [JsonProperty("filter_groups")]
        public IList<object> FilterGroups { get; set; }

        [JsonProperty("page_size")]
        public int PageSize { get; set; }
    }
}