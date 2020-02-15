using Newtonsoft.Json;

namespace Weather.Models
{
    public class Area
    {
        [JsonProperty(PropertyName = "ID")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "LocalizedName")]
        public string Name { get; set; }
    }
}
