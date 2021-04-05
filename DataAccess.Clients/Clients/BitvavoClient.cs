using Common;
using CryptoTrader.DataAccess.Clients.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoTrader.DataAccess.Clients.Clients
{
    public class BitvavoClient<TModel> : IBitvavoClient<TModel>
    {
        private static readonly HttpClient client = new HttpClient();
        private static string requestUri;

        public BitvavoClient()
        {
            requestUri = GetRequestUri();
        }

        public async Task<TModel> Get()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("*/*"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync(requestUri);
            return await JsonSerializer.DeserializeAsync<TModel>(await streamTask);
        }

        private string GetRequestUri()
        {
            if (typeof(TModel) == typeof(List<TickerPrice>))
            {
                return "https://api.bitvavo.com/v2/ticker/price";
            }

            throw new CryptoTraderArgumentException($"Unknow model {typeof(TModel)}.");
        }
    }
}