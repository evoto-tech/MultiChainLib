﻿using Newtonsoft.Json;

namespace MultiChainLib
{
    public class MultiSigResponse
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("redeemScript")]
        public string RedeemScript { get; set; }
    }
}