using System.Collections.Generic;

namespace MultiChainLib.Client
{
    public class JsonRpcRequest
    {
        public JsonRpcRequest()
        {
            Values = new Dictionary<string, object>();
        }

        public Dictionary<string, object> Values { get; }

        internal string Method
        {
            get { return GetValue<string>("method"); }
            set { SetValue("method", value); }
        }

        internal object[] Params
        {
            get { return GetValue<object[]>("params"); }
            set { SetValue("params", value); }
        }


        internal int Id
        {
            get { return GetValue<int>("id"); }
            set { SetValue("int", value); }
        }

        internal string ChainName
        {
            get { return GetValue<string>("chain_name"); }
            set { SetValue("chain_name", value); }
        }

        internal string ChainKey
        {
            get { return GetValue<string>("chain_key"); }
            set { SetValue("chain_key", value); }
        }

        private void SetValue(string name, object value)
        {
            Values[name] = value;
        }

        public T GetValue<T>(string name)
        {
            if (Values.ContainsKey(name))
                return (T) Values[name];
            return default(T);
        }
    }
}