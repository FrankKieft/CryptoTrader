using System.Threading.Tasks;

namespace CryptoTrader.DataAccess.Clients.Repositories
{
    public interface IRepository<TModel>
    {
        Task<TModel> Get();
    }
}