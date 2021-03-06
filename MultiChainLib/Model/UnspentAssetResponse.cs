﻿using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class UnspentAssetResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("assetref")]
        public string AssetRef { get; set; }

        [JsonProperty("qty")]
        public decimal Qty { get; set; }
    }
}