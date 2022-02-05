using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace TradeArt.Lib.GraphQL
{
    public class GraphQLClientSimpleFactory : IGraphQLClientFactory
    {
        private readonly string _apiUrl;

        public GraphQLClientSimpleFactory(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        public IGraphQLClient GetGraphQLClient()
        {
            return new GraphQLHttpClient(_apiUrl, new NewtonsoftJsonSerializer());
        }
    }
}
