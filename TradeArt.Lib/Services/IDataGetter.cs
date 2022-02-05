using System.Collections.Generic;
using System.Threading.Tasks;

namespace TradeArt.Lib.Services
{
    public interface IDataGetter
    {
        Task<IEnumerable<int>> GetAsync();
    }
}
