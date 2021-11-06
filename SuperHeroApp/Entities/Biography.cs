using Newtonsoft.Json;
using System.Collections.Generic;

namespace SuperHeroApp.Entities
{
    public class Biography
    {
        [JsonProperty("full-name")]

        public string FullName { get; set; }

        [JsonProperty("alter-egos")]
        public string AlterEgos { get; set; }

        public List<string> Aliases { get; set; }

        [JsonProperty("place-of-birth")]
        public string PlaceOfBirth { get; set; }

        [JsonProperty("first-appearance")]
        public string FirstAppearance { get; set; }

        public string Publisher { get; set; }

        public string Alignment { get; set; }
    }
}
