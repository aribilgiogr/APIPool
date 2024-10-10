using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Concretes.DTOs
{
    public class Currency
    {
        public string? CurrencyCode { get; set; } = string.Empty;
        public string? CurrencyName { get; set; } = string.Empty;
        public decimal ForexBuying { get; set; } = 0;
        public decimal ForexSelling { get; set; } = 0;
        public decimal BanknoteBuying { get; set; } = 0;
        public decimal BanknoteSelling { get; set; } = 0;
        public decimal? CrossRateUSD { get; set; } = 0;
        public decimal? CrossRateOther { get; set; } = 0;
    }
}