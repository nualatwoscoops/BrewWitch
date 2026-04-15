using Newtonsoft.Json;

namespace BrewWitch
{
    public class Brewery
    {
            [JsonProperty("id")]
            public string? Id { get; set; }
            [JsonProperty("name")]
            public string? Name { get; set; }
            [JsonProperty("brewery_type")]
            public string? Brewery_type { get; set; }
            [JsonProperty("city")]
            public string? City { get; set; }
            [JsonProperty("state_province")]
            public string? State_province { get; set; }
            [JsonProperty("country")]
            public string? Country { get; set; }
            [JsonProperty("phone")]
            public string? Phone { get; set; }
            [JsonProperty("website_url")]
            public string? Website_url { get; set; }
    }
}
