using System;
using System.Text.Json.Serialization;

namespace ConsoleApp.Dtos
{
    public class Transaction
    {
        public string Merchant { get; set; }
        public long Amount { get; set; }

        [JsonIgnore]
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
