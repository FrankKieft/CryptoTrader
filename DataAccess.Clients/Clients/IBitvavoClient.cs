using System.Threading.Tasks;

namespace CryptoTrader.DataAccess.Clients.Clients
{
    public interface IBitvavoClient<TModel>
    {
        Task<TModel> Get();
    }
}
