using Newtonsoft.Json;

namespace MultiChainLib
{
    public class WalletInfoResponse
    {
        [JsonProperty("walletversion")]
        public int WalletVersion { get; set; }

        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        [JsonProperty("txcount")]
        public int TxCount { get; set; }

        [JsonProperty("keypoololdest")]
        public long KeyPoolOldest { get; set; }

        [JsonProperty("keypoolsize")]
        public int KeypoolSize { get; set; }
    }
}