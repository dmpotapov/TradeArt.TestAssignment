using GraphQL;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeArt.Lib.Models.GraphQL;

namespace TradeArt.Lib.GraphQL
{
    public class GraphQLService : IGraphQLService
    {
        private readonly IGraphQLClientFactory _graphQLClientFactory;

        public GraphQLService(IGraphQLClientFactory graphQLClientFactory)
        {
            _graphQLClientFactory = graphQLClientFactory;
        }

        /// <summary>
        /// Gets top maxItems available assets with prices in batches of pageSize
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="maxItems"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Asset>> GetAssetsWithPricesAsync(int pageSize = 20, int maxItems = 100)
        {
            var allAssets = new List<Asset>();

            using var graphQlClient = _graphQLClientFactory.GetGraphQLClient();

            for (int i = 0; i < maxItems; i += pageSize)
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<AssetsWithPricesQueryResult>(new GraphQLRequest
                {
                    // In this query, quoteSymbol was hardcoded, as the response size in other case exceeds the maximum amount allowed by API
                    Query = @"
                    query PageAssets($skip: Int, $limit: Int) {
                        assets(sort: [{marketCapRank: ASC}], page: {
                        skip: $skip,
                        limit: $limit
                        }) {
                        assetName
                        assetSymbol
                        marketCap
                        markets(filter: {quoteSymbol: {_eq: ""EUR""}}) {
                            marketSymbol
                            ticker {
                                        lastPrice
                                    }
                                }
                        }
                    }",
                    Variables = new
                    {
                        Skip = i,
                        Limit = pageSize
                    }
                });

                allAssets.AddRange(graphQLResponse.Data.Assets);
            }

            return allAssets;
        }
    }
}
