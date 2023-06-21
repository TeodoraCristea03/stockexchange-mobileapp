using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BursaDeValori
{
    public class Bursa
    {
        
        public Bursa()
        {

        }

        public Bursa(string symbol, string shortName, string currency, string region, double regularMarketPrice, double regularMarketDayHigh, double regularMarketDayLow, int regularMarketVolume, int averageDailyVolume3Month, int averageDailyVolume10Day, bool tradeable, bool cryptoTradeable)
        {
            //Id = id;
            Symbol = symbol;
            ShortName = shortName;
            Currency = currency;
            Region = region;
            RegularMarketPrice = regularMarketPrice;
            RegularMarketDayHigh = regularMarketDayHigh;
            RegularMarketDayLow = regularMarketDayLow;
            RegularMarketVolume = regularMarketVolume;
            AverageDailyVolume3Month = averageDailyVolume3Month;
            AverageDailyVolume10Day = averageDailyVolume10Day;
            Tradeable = tradeable;
            CryptoTradeable = cryptoTradeable;
        }


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string ShortName { get; set; }
        public string Currency { get; set; }
        public string Region { get; set; }
        public double RegularMarketPrice { get; set; }
        public double RegularMarketDayHigh { get; set; }
        public double RegularMarketDayLow { get; set; }
        public int RegularMarketVolume { get; set; }
        public int AverageDailyVolume3Month { get; set; }
        public int AverageDailyVolume10Day { get; set; }
        public bool Tradeable { get; set; }
        public bool CryptoTradeable { get; set; }

        public override string ToString()
        {
            return ShortName;
        }

    }
}
