using GraphQL.Types;

namespace GraphQLWebApi.Type;

public class ProductInputType : InputObjectGraphType
{
    public ProductInputType()
    {
        Field<IntGraphType>("productid");
        Field<StringGraphType>("name");
        Field<DecimalGraphType>("price");
    }
}