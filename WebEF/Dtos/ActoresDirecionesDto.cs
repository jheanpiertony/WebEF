using System.Text.Json.Serialization;

namespace WebEF.Dtos
{
    public class ActoresDireccionesDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("lat")]
        public string Lat { get; set; }
        [JsonPropertyName("lng")]
        public string Lng { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
