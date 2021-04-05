using CryptoTrader.DataAccess.Clients.Clients;
using CryptoTrader.DataAccess.Clients.Mappers;
using CryptoTrader.DataAccess.Clients.Models;
using CryptoTrader.DataAccess.Clients.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoTrader.Console
{
    public class Program
    {
        private static readonly TickerPriceRepository repository =
            new TickerPriceRepository(new BitvavoClient<List<TickerPrice>>(), new TickerPriceMapper());

        public static async Task Main(string[] args)
        {
            List<Domain.Models.TickerPrice> prices = await repository.Get();
            prices.ForEach(WriteTickerPrice);
        }

        private static void WriteTickerPrice(Domain.Models.TickerPrice tickerPrice)
        {
            System.Console.WriteLine($"{tickerPrice.Market} {tickerPrice.Price}");
        }
    }
}
