using System.Linq.Expressions;

const string KEY = "9fc7ce0d68888e27260293804ed3fbf3";

string input = Console.ReadLine()!;

using (HttpClient client = new ())
{
    try
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={input}&appid={KEY}";    
        HttpResponseMessage response = await client.GetAsync(url);

        if(response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
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
