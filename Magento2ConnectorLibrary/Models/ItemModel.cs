
using Newtonsoft.Json;

namespace Magento2ConnectorLibrary.Models
{
    public class ItemModel
    {

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("source_code")]
        public string Source_Code { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("extension_attributes")]
        public ExtensionAttributesModel ExtensionAttributes { get; set; }
    }
}
