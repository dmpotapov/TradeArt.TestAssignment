using System.Threading.Tasks;

namespace TradeArt.Lib.Services
{
    public class ExternalService : IExternalService
    {
        public async Task<bool> ProcessAsync(int n)
        {
            await Task.Delay(100);

            return true;
        }
    }
}
