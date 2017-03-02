using System.Collections.Generic;
using System.Dynamic;

namespace MultiChainLib.Model
{
    public class CreateRawTransactionAmount
    {
        public string Address { get; set; }
        public decimal Qty { get; set; }

        //"1DK3fuhpAqHWAvNtbWHqsyHYxUsK38N878t3nZ":qty, 
        public virtual object StringifyAmount()
        {
            return Qty;
        }
    }

    public class CreateRawTransactionAsset : CreateRawTransactionAmount
    {
        public string Name { get; set; }

        //"1DK3fuhpAqHWAvNtbWHqsyHYxUsK38N878t3nZ":{"asset":qty}, 
        public override object StringifyAmount()
        {
            dynamic flexible = new ExpandoObject();
            var dictionary = (IDictionary<string, object>) flexible;
            dictionary.Add(Name, Qty);

            return dictionary;
        }
    }
}