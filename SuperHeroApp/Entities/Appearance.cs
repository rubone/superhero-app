using Newtonsoft.Json;
using System.Collections.Generic;

namespace SuperHeroApp.Entities
{
    public class Appearance
    {
        public string Gender { get; set; }

        public string Race { get; set; }

        public List<string> Height { get; set; }

        public List<string> Weight { get; set; }

        [JsonProperty("eye-color")]
        public string EyeColor { get; set; }

        [JsonProperty("hair-color")]
        public string HairColor { get; set; }
    }
}
