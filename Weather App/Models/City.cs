using Newtonsoft.Json;

namespace Weather.Models
{
    public class City
    {
        public int Version { get; set; }
        
        public string Key { get; set; }
        
        public string Type { get; set; }

        public int Rank { get; set; }

        [JsonProperty(PropertyName = "LocalizedName")]
        public string Name { get; set; }
        
        public Area Country { get; set; }

        [JsonProperty(PropertyName = "AdministrativeArea")]
        public Area State { get; set; }
    }
}
