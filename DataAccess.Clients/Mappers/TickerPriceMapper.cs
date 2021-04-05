using CryptoTrader.DataAccess.Clients.Models;
using System;

namespace CryptoTrader.DataAccess.Clients.Mappers
{
    public class TickerPriceMapper : IMapper<TickerPrice, Domain.Models.TickerPrice>
    {
        public Domain.Models.TickerPrice Map(TickerPrice input)
        {
            return new Domain.Models.TickerPrice
            {
                Market = input.market,
                Price = Convert.ToDecimal(input.price)
            };
        }
    }
}
