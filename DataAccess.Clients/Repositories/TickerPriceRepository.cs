using CryptoTrader.DataAccess.Clients.Clients;
using CryptoTrader.DataAccess.Clients.Mappers;
using CryptoTrader.DataAccess.Clients.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTrader.DataAccess.Clients.Repositories
{
    public class TickerPriceRepository : IRepository<List<Domain.Models.TickerPrice>>
    {
        private readonly IBitvavoClient<List<TickerPrice>> client;
        private readonly IMapper<TickerPrice, Domain.Models.TickerPrice> mapper;

        public TickerPriceRepository(IBitvavoClient<List<TickerPrice>> client, IMapper<TickerPrice, Domain.Models.TickerPrice> mapper)
        {
            this.client = client;
            this.mapper = mapper;
        }

        public async Task<List<Domain.Models.TickerPrice>> Get()
        {
            List<TickerPrice> tickerPrices = await client.Get();
            return tickerPrices.Select(mapper.Map).ToList();
        }
    }
}
