using System;
using System.Collections.Generic;
using MultiChainLib.Client;
using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class VerboseTransactionResponse
    {
        public VerboseTransactionResponse()
        {
            Vin = new List<TransactionVin>();
            Vout = new List<TransactionVout>();
            Data = new List<string>();
        }

        [JsonProperty("hex")]
        public string Hex { get; set; }

        [JsonProperty("txid")]
        public string TxId { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("locktime")]
        public string LockTime { get; set; }

        [JsonProperty("vin")]
        public List<TransactionVin> Vin { get; set; }

        [JsonProperty("vout")]
        public List<TransactionVout> Vout { get; set; }

        [JsonProperty("data")]
        public List<string> Data { get; set; }

        [JsonIgnore]
        public byte[] DataAsBytes
        {
            get { throw new NotImplementedException("This operation has not been implemented."); }
        }

        public byte[] GetDataAsBytes(int index)
        {
            return MultiChainClient.ParseHexString(Data[index]);
        }
    }
}