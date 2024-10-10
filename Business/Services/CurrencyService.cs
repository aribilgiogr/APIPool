using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Business.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient client;

        public CurrencyService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient();
        }

        private readonly string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
        public async Task<IEnumerable<Currency>?> GetCurrenciesAsync()
        {
            var response = await client.GetStringAsync(url);
            XmlDocument doc = new();
            doc.LoadXml(response);
            XmlElement? root = doc.DocumentElement;
            if (root != null)
            {
                var result = new List<Currency>();
                foreach (XmlNode item in root.ChildNodes)
                {
                    var currency = new Currency
                    {
                        CurrencyCode = item.Attributes?["CurrencyCode"]?.Value.Trim(),
                        CurrencyName = item["CurrencyName"]?.InnerText.Trim(),
                        ForexBuying = toDecimal(item["ForexBuying"]?.InnerText.Trim()),
                        ForexSelling = toDecimal(item["ForexSelling"]?.InnerText.Trim()),
                        BanknoteBuying = toDecimal(item["BanknoteBuying"]?.InnerText.Trim()),
                        BanknoteSelling = toDecimal(item["BanknoteSelling"]?.InnerText.Trim()),
                        CrossRateUSD = toDecimal(item["CrossRateUSD"]?.InnerText.Trim()),
                        CrossRateOther = toDecimal(item["CrossRateOther"]?.InnerText.Trim())

                    };
                    result.Add(currency);
                }
                return result;
            }
            return null;

        }

        private decimal toDecimal(string? value)
        {
            decimal.TryParse(value, CultureInfo.InvariantCulture, out decimal result);
            return result;
        }
    }
}
