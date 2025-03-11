using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DemoApiCalls.Models
{
    public class APIRequestModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("resolution")]
        public string Resolution { get; set; }

        [JsonPropertyName("window1-src")]
        public int? Window1Src { get; set; }

        [JsonPropertyName("window2-src")]
        public int? Window2Src { get; set; }

        [JsonPropertyName("window3-src")]
        public int? Window3Src { get; set; }

        [JsonPropertyName("window4-src")]
        public int? Window4Src { get; set; }

        [JsonPropertyName("layout")]
        public string Layout { get; set; }

        [JsonPropertyName("icon")]
        public int? Icon { get; set; }

        [JsonPropertyName("enable")]
        public bool? Enable { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = false });
        }
    }

}
