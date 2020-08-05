using InfinitusApp.Core.Data.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.External.Iugu
{
    public class PlanRequestMessage
    {
        public PlanRequestMessage(string name, string uniqueIdentifier, int cycle, PlanIntervalType interval, int valueInCents)
        {
            Name = name;
            UniqueIdentifier = uniqueIdentifier;
            Cycle = cycle;
            IntervalType = interval.ToString();
            ValueInCents = valueInCents;
            CurrencyTypeName = CurrencyType.BRL.ToString();
        }
        public PlanRequestMessage(string name, string uniqueIdentifier, int cycle, PlanIntervalType interval, int valueInCents, CurrencyType currency)
        {
            Name = name;
            UniqueIdentifier = uniqueIdentifier;
            Cycle = cycle;
            IntervalType = interval.ToString();
            ValueInCents = valueInCents;
            CurrencyTypeName = currency.ToString();
        }

        public PlanRequestMessage(CreateSignaturePlanCommand cmd)
        {
            Name = cmd.Title;
            UniqueIdentifier = string.Format("{0} - {1}", cmd.Title, cmd.DataStoreId);
            Cycle = 1;
            IntervalType = PlanIntervalType.Monthly.ToString();
            ValueInCents = int.Parse((cmd.Amount * 100).ToString());
            CurrencyTypeName = CurrencyType.BRL.ToString();
        }

        [JsonProperty("name")]
        public string Name { get; }
        [JsonProperty("identifier")]
        public string UniqueIdentifier { get; }
        [JsonProperty("interval")]
        public int Cycle { get; }
        [JsonProperty("interval_type")]
        public string IntervalType { get; }
        [JsonProperty("currency")]
        public string CurrencyTypeName { get; }
        [JsonProperty("value_cents")]
        public int ValueInCents { get; }
        [JsonProperty("payable_with")]
        public string PaymentMethod { get; set; }


        public enum PlanIntervalType
        {
            Weekly = 0,
            Monthly = 1
        }

        public enum CurrencyType
        {
            BRL = 0
        }
    }
}
