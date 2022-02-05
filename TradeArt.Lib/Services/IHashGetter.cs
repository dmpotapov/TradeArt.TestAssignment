using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeArt.Lib.Services
{
    public interface IHashGetter
    {
        public Task<string> GetByFileAsync(string path);
    }
}
