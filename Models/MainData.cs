using System.Text.Json.Serialization;

class MainData
{
    [JsonPropertyName("temp")]
    public float Temp { get; set; }
}
