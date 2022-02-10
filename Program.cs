
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sandbox
{
    //public class Program
    //{
    //    static async Task Main(string[] args)
    //    {
    //        using var client = new HttpClient();
            
    //        var request = new HttpRequestMessage(HttpMethod.Get, "https://api.weather.gov/points/30.4515%2C-91.1871");

    //        request.Headers.Add("User-Agent", Guid.NewGuid().ToString());
    //        request.Headers.Add("token", "nfkNnOjBXCOWmQMaGociisYzEayXnEBR");

    //        var result = await client.SendAsync(request);

    //        var jsonData = await result.Content.ReadAsStringAsync();

    //        var observationStations = JsonConvert.DeserializeObject<ObservationStationProperties>(jsonData);

    //        Console.WriteLine(observationStations?.Properties.ObservationStations);

    //        var uri = observationStations?.Properties.ObservationStations;

    //        var foo = await GetNearestObservationStationId(uri);

    //        var latestObservationUri = foo + "/observations/latest?require_qc=true";

    //        Console.WriteLine(latestObservationUri);

    //        var windSpeed = await GetWindSpeed(latestObservationUri);

    //        Console.WriteLine(JsonConvert.SerializeObject(windSpeed));

    //    }

    //    public class ObservationStationProperties
    //    {
    //        public ObservationStationUri Properties { get; set; }
    //    }

    //    public class ObservationStationUri
    //    {
    //        public string ObservationStations { get; set; }
    //    }

    //    public class NearestObservationStation
    //    {
    //        public string[] ObservationStations { get; set; }
    //    }

    //    public class JsonFoo
    //    {
    //        public WeatherProperties Properties { get; set; }
    //    }

    //    public class WeatherProperties
    //    {
    //        public WindSpeed WindSpeed { get; set; }
    //        public Precipitation PrecipitationLastHour { get; set; }
    //    }

    //    public class Precipitation
    //    {
    //        public string UnitCode { get; set; }
    //        public decimal? Value { get; set; }
    //        public string QualityControl { get; set; }
    //    }

    //    public class WindSpeed
    //    {
    //        public string UnitCode { get; set; }
    //        public decimal Value { get; set; }
    //        public string QualityControl { get; set; }
    //    }

    //    static async Task<string> GetNearestObservationStationId(string observationStationsUri)
    //    {
    //        using var client = new HttpClient();

    //        var request = new HttpRequestMessage(HttpMethod.Get, observationStationsUri);

    //        request.Headers.Add("User-Agent", Guid.NewGuid().ToString());
    //        request.Headers.Add("token", "nfkNnOjBXCOWmQMaGociisYzEayXnEBR");

    //        var result = await client.SendAsync(request);

    //        var jsonData = await result.Content.ReadAsStringAsync();

    //        var observationStations = JsonConvert.DeserializeObject<NearestObservationStation>(jsonData);

    //        return observationStations?.ObservationStations.FirstOrDefault();
    //    }

    //    static async Task<WeatherProperties> GetWindSpeed(string uri)
    //    {
    //        using var client = new HttpClient();

    //        var request = new HttpRequestMessage(HttpMethod.Get, uri);

    //        request.Headers.Add("User-Agent", Guid.NewGuid().ToString());
    //        request.Headers.Add("token", "nfkNnOjBXCOWmQMaGociisYzEayXnEBR");

    //        var result = await client.SendAsync(request);

    //        var jsonData = await result.Content.ReadAsStringAsync();

    //        var reading = JsonConvert.DeserializeObject<JsonFoo>(jsonData);

    //        return reading?.Properties;
    //    }
    //}
}