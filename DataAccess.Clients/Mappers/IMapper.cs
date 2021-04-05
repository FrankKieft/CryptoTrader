namespace CryptoTrader.DataAccess.Clients.Mappers
{
    public interface IMapper<TModelIn, TModelOut>
    {
        TModelOut Map(TModelIn input);
    }
}
