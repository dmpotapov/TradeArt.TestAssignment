using System.Threading.Tasks;

namespace TradeArt.Lib.Services
{
    public interface IExternalService
    {
        Task<bool> ProcessAsync(int n);
    }
}
