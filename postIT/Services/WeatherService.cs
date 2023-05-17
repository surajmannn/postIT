using System;
using System.Net.Http.Json;
using System.Text.Json;

namespace postIT.Services;

public class WeatherService
{
    IGeolocation geolocation;
    HttpClient httpClient;

    public WeatherService()
	{
        this.httpClient = new HttpClient();
    }

    public async Task<double> GetWeather()
    {
        // Gets current weather in coventry and returns the temperature using open Weather API
        var response = await httpClient.GetAsync("https://api.openweathermap.org/data/2.5/forecast?q=London,uk&APPID=7a23354318d9d429a7b41dd215826c42&units=metric");
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var weatherData = JsonSerializer.Deserialize<WeatherData>(jsonString, options);
            Console.WriteLine("Response");
            Console.WriteLine(JsonSerializer.Serialize(weatherData));
            return weatherData.List[0].Main.Temp;
        }
        else
        {
            throw new Exception("Failed to retrieve weather data");
        }
    }

    async void getLocation()
    {
        var location = await geolocation.GetLocationAsync(new GeolocationRequest
        {
            DesiredAccuracy = GeolocationAccuracy.Medium,
            Timeout = TimeSpan.FromSeconds(30)
        });
    }
}

public class WeatherData
{
    public List<WeatherItem> List { get; set; }
}

public class WeatherItem
{
    public MainData Main { get; set; }
}

public class MainData
{
    public double Temp { get; set; }
}