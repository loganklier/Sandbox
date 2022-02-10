using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sandbox
{
    //public class Noaa
    //{
    //    public MetaData metadata { get; set; }
    //    public List<Result> results;
    //}

    //public class MetaData
    //{
    //    public ResultSet resultset { get; set; }
    //}

    //public class ResultSet
    //{
    //    public int offset { get; set; }
    //    public int count { get; set; }
    //    public int limit { get; set; }
    //}

    //[DataContract]
    //public class Result
    //{
    //    [DataMember(Name = "date")]
    //    public string Date { get; set; }

    //    [DataMember(Name = "datatype")]
    //    public string DataType { get; set; }

    //    [DataMember(Name = "station")]
    //    public string Station { get; set; }

    //    [DataMember(Name = "attributes")]
    //    public string Attributes { get; set; }
        
    //    [DataMember(Name = "value")]
    //    public int Value { get; set; }
    //}

    //static async Task Test(string[] args)
    //{
    //await ProcessRepositories();
    //}

    //private static async Task ProcessRepositories()
    //{
    //var serializer = new DataContractJsonSerializer(typeof(Noaa));

    //string token = "qUQpaHIXAYfOqsxThtTzbgFKTWfdblLX";

    //Client.DefaultRequestHeaders.Accept.Clear();
    //Client.DefaultRequestHeaders.Add("token", token);

    ////url taken from https://www.ncdc.noaa.gov/cdo-web/webservices/v2#data for daily summaries
    //string url =
    //    "https://www.ncdc.noaa.gov/cdo-web/api/v2/data?datasetid=GHCND&locationid=ZIP:28801&startdate=2010-05-01&enddate=2010-05-01";

    //var streamTask = Client.GetStreamAsync(url);

    //var repositories = (Noaa)serializer.ReadObject(await streamTask);

    //    foreach (var repo in repositories.results)
    //{
    //    Console.WriteLine(repo.Value);
    //    Console.WriteLine(repo.Attributes);
    //    Console.WriteLine(repo.DataType);
    //    Console.WriteLine(repo.Date);
    //    Console.WriteLine(repo.Station);
    //    Console.WriteLine("________________________________________________________");
    //}
    //}
}
