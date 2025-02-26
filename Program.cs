using System.Text.Json;
using System.Text.Json.Serialization;

const string KEY = "3fe3618da3f5d90fb993d05aa32c0afc";
Console.WriteLine("Please enter the city name: ");
string city = Console.ReadLine();

using (HttpClient client = new())
{
    try 
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={KEY}";
        HttpResponseMessage response = await client.GetAsync(url);


        if(response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            WeatherData weatherInfo = JsonSerializer.Deserialize<WeatherData>(result);
            Console.WriteLine($"Shahar nomi: {weatherInfo.name}\nTemperature: {weatherInfo.main.Temp - 273.15f:F0}°C\nMa'lumot: {weatherInfo.weather[0].Description}");        
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
    }
}

class WeatherData
{
    public string? name { get; set; } // to be fixed
    public MainData? main { get; set; } // to be fixed
    public WeatherInfo[]? weather { get; set; } // to be fixed
}

class MainData
{
    [JsonPropertyName("temp")]
    public float Temp { get; set; }
}

class WeatherInfo
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}