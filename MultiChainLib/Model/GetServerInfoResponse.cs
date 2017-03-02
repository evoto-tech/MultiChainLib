using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class GetServerInfoResponse
    {
        public GetServerInfoResponse()
        {
            AvailableMethods = new List<string>();
        }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("availableMethods")]
        public List<string> AvailableMethods { get; set; }
    }
}