using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradeArt.Lib.GraphQL;
using TradeArt.Lib.Services;

namespace TradeArt.TestAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestAssignmentController : ControllerBase
    {
        private readonly IStringInvertor _stringInvertor;
        private readonly IDataGetter _dataGenerator;
        private readonly IHashGetter _hashGetter;
        private readonly IGraphQLService _graphQLService;

        public TestAssignmentController(
            IDataGetter dataGenerator,
            IStringInvertor stringInvertor,
            IHashGetter hashGetter, 
            IGraphQLService graphQLService)
        {
            _dataGenerator = dataGenerator;
            _stringInvertor = stringInvertor;
            _hashGetter = hashGetter;
            _graphQLService = graphQLService;
        }

        /// <summary>
        /// Task 1 - Invert the text given in the task description
        /// </summary>
        [HttpGet("first")]
        public ActionResult InvertString()
        {
            var result = _stringInvertor.Invert(@"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et
dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip
ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore
eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
deserunt mollit anim id est laborum.");

            return new JsonResult(result);
        }

        /// <summary>
        /// Task 2 - Run a loop of 1...1000 and emit random numbers; for every number, make a call to the external service 
        /// Returns the array of numbers; if the external service call was successful, the number in range from 1 to 1000 is being returned;
        /// Otherwise, it returns -1
        /// </summary>
        [HttpGet("second")]
        public async Task<ActionResult> GetNumbers()
        {
            var res = await _dataGenerator.GetAsync();

            return new JsonResult(res);
        }

        /// <summary>
        /// Task 3 - Returns SHA512 hash of the file 100MB-sized file that is the part of the project
        /// </summary>
        [HttpGet("third")]
        public async Task<ActionResult> GetFileHash()
        {
            var hash = await _hashGetter.GetByFileAsync("100MB.bin");

            return new JsonResult(hash);
        }

        /// <summary>
        /// Task - 4 - Make a call to the GraphQL API with assets list and prices for every asset;
        /// The call is being executed for top 100 items in the batches of 20 items;
        /// Return value is the list of assets with prices
        /// </summary>
        [HttpGet("fourth")]
        public async Task<ActionResult> FetchDataFromGraphQl()
        {
            int pageSize = 20, maxItems = 100;

            var allAssets = await _graphQLService.GetAssetsWithPricesAsync(pageSize, maxItems);

            return new JsonResult(allAssets);
        }
    }
}
