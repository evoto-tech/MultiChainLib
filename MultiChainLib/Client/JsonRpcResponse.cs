using System;
using Newtonsoft.Json;

namespace MultiChainLib.Client
{
    public class JsonRpcResponse<T>
    {
        [JsonProperty("result")]
        public T Result { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonIgnore]
        public string RawJson { get; internal set; }

        public void AssertOk()
        {
            if (!string.IsNullOrEmpty(Error))
                throw new InvalidOperationException("Error(s) occurred: " + Error);
        }
    }
}