using Newtonsoft.Json;

namespace SuperHeroApp.Entities
{
    public class Connections
    {
        [JsonProperty("group-affiliation")]
        public string GroupAffiliation { get; set; }

        public string Relatives { get; set; }
    }
}
