using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

internal class Program
{
    const string TEXT = "The quick brown fox jumps over the lazy dog.";

    private static async Task Main(string[] args)
    {
        Console.WriteLine(TEXT);

        string reverse = null;
        /*
        * REVERSE THE TEXT AND STORE IT IN THE **reverse** VARIABLE (5 min)
        */
        Console.WriteLine(reverse);

        // CREATE A HISTOGRAM OF THE CHARACTER COUNT
        Dictionary<char, int> histogram = new Dictionary<char, int>();

        /*
        * CREATE CASE-INSENSITIVE HISTOGRAM OF ALL ALPHA-NUMERIC CHARACTERS IN **TEXT** CONSTANT (10 min)
        *   HINT: Use the Linq library where applicable
        */

        foreach (var item in histogram.OrderByDescending(h => h.Value).ThenBy(h => h.Key))
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        // MAKE A WEB REQUEST TO A SITE AND WRITE THE HEADERS AND CONTENT (20 min)
        using (var client = new HttpClient()) {
            HttpResponseMessage response = null;
            
            /*
            *  MAKE GET REQUEST TO https://jwt.ms
            */

            if (response?.IsSuccessStatusCode ?? false) {
                Console.WriteLine($"{response.StatusCode} {response.ReasonPhrase}");

                /*
                *  WRITE ALL HEADERS AND VALUES OUT TO CONSOLE
                */

                /*
                *  WRITE RESPONSE BODY OUT TO CONSOLE
                */
            }
        }

        // PULL DOWN AND PARSE JSON DATA AND WRITE TO THE CONSOLE (20 min)
        IndicatorResponse indicators = null;

        using (var client = new HttpClient()) {
            HttpResponseMessage response = null;
            
            /*
            *  MAKE GET REQUEST TO https://ghoapi.azureedge.net/api/WHOSIS_000015
            */

            if (response?.IsSuccessStatusCode ?? false) {
                /*
                * DESERIALIZE RESPONSE HERE AND SAVE TO **indicators** VARIABLE
                */
            }
        }

        if (indicators != null) {
            foreach (var indicator in indicators.value.Where(i => i.SpatialDim.Equals("USA")).OrderBy(i => i.TimeDim).Take(100)) {
                Console.WriteLine(indicator.ToString());
            }
        }        
    }
}

class IndicatorResponse {
    [JsonPropertyName("@odata.context")]
    public string OdataContext { get; set; }
    public IEnumerable<Indicator> value { get; set; }
}

class Indicator {
    public int Id { get; set; }
    public string IndicatorCode { get; set; }
    public string SpatialDimType { get; set; }
    public string SpatialDim { get; set; }
    public string TimeDimType { get; set; }
    public int TimeDim { get; set; }
    public string Dim1Type { get; set; }
    public string Dim1 { get; set; }
    public string Value { get; set; }
    public float NumericValue { get; set; }
    public DateTimeOffset Date { get; set; }

    public override string ToString()
    {
        return $"({SpatialDim},{TimeDim}): {NumericValue} [{Date.ToUniversalTime():yyyy-MM-ddTHH:mm:ss}]";
    }
}
