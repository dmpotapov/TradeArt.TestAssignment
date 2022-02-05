using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeArt.Lib.Services
{
    public class DataGetter : IDataGetter
    {
        private readonly IExternalService _externalService;
        private readonly Random _random = new Random();

        public DataGetter(IExternalService externalService)
        {
            _externalService = externalService;
        }

        /// <summary>
        /// Runs a loop of 1...1000 and emits random numbers in range from 1 to 1000
        /// Makes a request to the external service, and, if it was successful, random number is emitted, otherwise it's -1
        /// </summary>
        /// <returns>IEnumerable with the list of generated numbers (where unsuccessful external service requests are marked as -1)</returns>
        public async Task<IEnumerable<int>> GetAsync()
        {
            var numbers = await Task.WhenAll(Enumerable.Range(1, 1000).AsParallel().Select(async n =>
            {
                var num = GetNumber();

                var res = await _externalService.ProcessAsync(num);

                if (!res) return -1;

                return num;

            }).ToList());

            return numbers;
        }

        private int GetNumber() => _random.Next(1, 1000);
    }
}
