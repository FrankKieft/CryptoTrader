using CryptoTrader.DataAccess.Clients.Clients;
using CryptoTrader.DataAccess.Clients.Mappers;
using CryptoTrader.DataAccess.Clients.Models;
using CryptoTrader.DataAccess.Clients.Repositories;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DataAccess.Clients.UnitTests
{
    public class TickerPriceRepositoryTests
    {
        [Fact]
        public async void CanRequestPriceOfBtcInEurFromBitvavo()
        {
            decimal price = await GetTickerPrice("BTC-EUR");
            price.Should().BeGreaterThan(1);
        }

        [Fact]
        public async Task CanRequestPriceOfBsvInBtcFromBitvavo()
        {
            decimal price = await GetTickerPrice("BSV-BTC");
            price.Should().BeLessThan(1);
        }

        private async Task<decimal> GetTickerPrice(string market)
        {
            // Arrange
            var client = new BitvavoClient<List<TickerPrice>>();
            var mapper = new TickerPriceMapper();
            var repository = new TickerPriceRepository(client, mapper);

            // Act
            List<Domain.Models.TickerPrice> result = await repository.Get();
            Domain.Models.TickerPrice tickerPrice = result.SingleOrDefault(x => x.Market == market);

            // Assert
            tickerPrice.Should().NotBeNull();
            return tickerPrice.Price;
        }
    }
}
