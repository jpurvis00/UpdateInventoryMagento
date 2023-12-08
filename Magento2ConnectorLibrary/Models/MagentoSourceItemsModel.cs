
using Newtonsoft.Json;

namespace Magento2ConnectorLibrary.Models
{
    public class MagentoSourceItemsModel
    {
        [JsonProperty("sourceItems")]
        public List<ItemModel> SourceItems { get; set; } = new List<ItemModel>();
    }
}
