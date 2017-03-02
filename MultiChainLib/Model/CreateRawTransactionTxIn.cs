using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class CreateRawTransactionTxIn
    {
        [JsonProperty("txid")]
        public string TxId { get; set; }

        [JsonProperty("vout")]
        public int Vout { get; set; }
    }
}