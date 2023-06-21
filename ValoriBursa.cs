using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BursaDeValori
{
    internal class ValoriBursa
    {
        public static async Task<List<Bursa>> PreiaBursa(List<String> symbols)
        {
            List<Bursa> listaBursa = new List<Bursa>();

            using (var httpClient = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://query1.finance.yahoo.com/v6/finance/quote?symbols=" +
                    String.Join(",", symbols));
                requestMessage.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36");

                HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

                var json = await response.Content.ReadAsStringAsync(); ;

                /*var json = await httpClient.GetStringAsync("https://query1.finance.yahoo.com/v6/finance/quote?symbols=" +
                    String.Join(",", symbols));*/


                JObject o = JObject.Parse(json);
                
                foreach (var current_object in o["quoteResponse"]["result"])
                {
                    var symbol = current_object["symbol"] != null ? current_object["symbol"].ToString() : "Unknown";
                    var shortName = current_object["shortName"] != null ? current_object["shortName"].ToString() : "Unknown";
                    var currency = current_object["currency"] != null ? current_object["currency"].ToString() : "Unknown";
                    var region = current_object["region"] != null ? current_object["region"].ToString() : "Unknown";
                    var regularMarketPrice = current_object["regularMarketPrice"] != null ?
                        Convert.ToDouble(current_object["regularMarketPrice"].ToString()) : -1;
                    var regularMarketDayHigh = current_object["regularMarketDayHigh"] != null ?
                        Convert.ToDouble(current_object["regularMarketDayHigh"].ToString()) : -1;
                    var regularMarketDayLow = current_object["regularMarketDayLow"] != null ?
                        Convert.ToDouble(current_object["regularMarketDayLow"].ToString()) : -1;
                    var regularMarketVolume = current_object["regularMarketVolume"] != null ?
                        Convert.ToInt32(current_object["regularMarketVolume"].ToString()) : -1;
                    var averageDailyVolume3Month = current_object["averageDailyVolume3Month"] != null ?
                        Convert.ToInt32(current_object["averageDailyVolume3Month"].ToString()) : -1;
                    var averageDailyVolume10Day = current_object["averageDailyVolume10Day"] != null ?
                        Convert.ToInt32(current_object["averageDailyVolume10Day"].ToString()) : -1;
                    var tradeable = current_object["tradeable"] != null ?
                        Convert.ToBoolean(current_object["tradeable"].ToString()) : false;
                    var cryptoTradeable = current_object["cryptoTradeable"] != null ?
                        Convert.ToBoolean(current_object["cryptoTradeable"].ToString()) : false;
                    Bursa current_bursa = new Bursa(symbol, shortName, currency, region, regularMarketPrice, regularMarketDayHigh,
                        regularMarketDayLow, regularMarketVolume, averageDailyVolume3Month,
                        averageDailyVolume10Day, tradeable, cryptoTradeable);
                    listaBursa.Add(current_bursa);
                }
            }

            return listaBursa;
        }

    }
}
