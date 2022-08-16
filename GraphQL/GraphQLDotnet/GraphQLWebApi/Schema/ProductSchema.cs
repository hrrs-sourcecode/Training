using GraphQLWebApi.Mutation;
using GraphQLWebApi.Query;

namespace GraphQLWebApi.Schema;

public class ProductSchema : GraphQL.Types.Schema
{
    public ProductSchema(ProductQuery productQuery, ProductMutation productMutation)
    {
        Query = productQuery;
        Mutation = productMutation;
    }
}