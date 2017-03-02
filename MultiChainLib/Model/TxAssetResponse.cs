﻿using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class TxAssetResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("genesistxid")]
        public string GenesisTxId { get; set; }

        [JsonProperty("assetref")]
        public string AssetRef { get; set; }

        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        [JsonProperty("raw")]
        public long Raw { get; set; }

        [JsonProperty("genesis")]
        public bool Genesis { get; set; }
    }
}