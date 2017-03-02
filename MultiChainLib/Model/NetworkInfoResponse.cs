using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class NetworkInfoResponse
    {
        public NetworkInfoResponse()
        {
            Networks = new List<NetworkResponse>();
            LocalAddresses = new List<LocalAddress>();
        }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("subversion")]
        public string Subversion { get; set; }

        [JsonProperty("protocolversion")]
        public int ProtocolVersion { get; set; }

        [JsonProperty("localservices")]
        public string LocalServices { get; set; }

        [JsonProperty("timeoffset")]
        public int TimeOffset { get; set; }

        [JsonProperty("connections")]
        public int Connections { get; set; }

        [JsonProperty("networks")]
        public List<NetworkResponse> Networks { get; set; }

        [JsonProperty("relayfee")]
        public decimal RelayFee { get; set; }

        [JsonProperty("localaddresses")]
        public List<LocalAddress> LocalAddresses { get; set; }
    }

    public class LocalAddress
    {
        [JsonProperty("address")]
        public string IpAddress { get; set; }

        [JsonProperty("port")]
        public short Port { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }
}