using Newtonsoft.Json;
using System.Collections.Generic;

namespace SuperHeroApp.Entities
{
    public class SearchResult
    {
        public string Response { get; set; }

        [JsonProperty("results-for")]
        public string ResultsFor { get; set; }

        public List<SuperHero> Results { get; set; }
    }
}
