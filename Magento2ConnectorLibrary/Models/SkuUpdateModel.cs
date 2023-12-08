
using Newtonsoft.Json;

namespace Magento2ConnectorLibrary.Models
{
    public class SkuUpdateModel
    {
        [JsonProperty("item")]
        public ItemModel Item { get; set; }
    }
}
