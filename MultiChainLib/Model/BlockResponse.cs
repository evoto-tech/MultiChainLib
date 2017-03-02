using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class BlockResponse
    {
        public BlockResponse()
        {
            Tx = new List<string>();
        }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("miner")]
        public string Miner { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("merkleroot")]
        public string MerkleRoot { get; set; }

        [JsonProperty("tx")]
        public List<string> Tx { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("nonce")]
        public int Nonce { get; set; }

        [JsonProperty("bits")]
        public string Bits { get; set; }

        [JsonProperty("difficulty")]
        public decimal Difficulty { get; set; }

        [JsonProperty("chainwork")]
        public string Chainwork { get; set; }

        [JsonProperty("previousblockhash")]
        public string PreviousBlockHash { get; set; }

        [JsonProperty("nextblockhash")]
        public string NextBlockHash { get; set; }
    }
}