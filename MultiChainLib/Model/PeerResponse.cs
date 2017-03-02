using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class PeerResponse
    {
        public PeerResponse()
        {
            Inflight = new List<object>();
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("addr")]
        public string Addr { get; set; }

        [JsonProperty("services")]
        public string Services { get; set; }

        [JsonProperty("lastsend")]
        public long LastSend { get; set; }

        [JsonProperty("lastrecv")]
        public long LastRecv { get; set; }

        [JsonProperty("bytessent")]
        public long BytesSent { get; set; }

        [JsonProperty("bytesrecv")]
        public long BytesRecv { get; set; }

        [JsonProperty("conntime")]
        public long ConnTime { get; set; }

        [JsonProperty("pingtime")]
        public decimal PingTime { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("subver")]
        public string SubVer { get; set; }

        [JsonProperty("handshakelocal")]
        public string HandshakeLocal { get; set; }

        [JsonProperty("handshake")]
        public string Handshake { get; set; }

        [JsonProperty("inbound")]
        public bool Inbound { get; set; }

        [JsonProperty("startingheight")]
        public int StartingHeight { get; set; }

        [JsonProperty("banscore")]
        public int BanScore { get; set; }

        [JsonProperty("synced_headers")]
        public int SyncedHeaders { get; set; }

        [JsonProperty("synced_blocks")]
        public int SyncedBlocks { get; set; }

        [JsonProperty("inflight")]
        public List<object> Inflight { get; set; }
    }
}