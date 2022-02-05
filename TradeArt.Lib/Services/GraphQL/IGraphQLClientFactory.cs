using GraphQL.Client.Abstractions;

namespace TradeArt.Lib.GraphQL
{
    public interface IGraphQLClientFactory
    {
        IGraphQLClient GetGraphQLClient();
    }
}
