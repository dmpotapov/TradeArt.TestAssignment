using GraphQL;
using GraphQL.Client.Abstractions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TradeArt.Lib.GraphQL;
using TradeArt.Lib.Models.GraphQL;

namespace TradeArt.Lib.Tests.Services
{
    
    public class GraphQLServiceTests
    {
        private IGraphQLService _graphQLService;
        private Mock<IGraphQLClientFactory> _graphQlClientFactory;
        private Mock<IGraphQLClient> _graphQlClient;

        [SetUp]
        public void SetUp()
        {
            _graphQlClient = new Mock<IGraphQLClient>();
            _graphQlClientFactory = new Mock<IGraphQLClientFactory>();
            _graphQlClientFactory.Setup(g => g.GetGraphQLClient()).Returns(_graphQlClient.Object);

            _graphQLService = new GraphQLService(_graphQlClientFactory.Object);
        }

        [Test]
        public async Task Should_Call_Client_Five_Times_And_Return_One_Hundred_Items()
        {
            // Arrange
            var pageSize = 20;
            var maxItems = 100;
            _graphQlClient.Setup(c => c.SendQueryAsync<AssetsWithPricesQueryResult>(It.IsAny<GraphQLRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GraphQLResponse<AssetsWithPricesQueryResult>() 
                { 
                    Data = new AssetsWithPricesQueryResult()
                    {
                        Assets = Enumerable.Repeat(new Asset(), pageSize).ToList()
                    }
                });

            // Act
            var res = await _graphQLService.GetAssetsWithPricesAsync(pageSize, maxItems);

            // Assert
            _graphQlClient.Verify(c => c.SendQueryAsync<AssetsWithPricesQueryResult>(It.IsAny<GraphQLRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(5));
            Assert.AreEqual(res.Count(), 100);
        }
    }
}
