using GraphQL.Types;
using GraphQLWebApi.Model;

namespace GraphQLWebApi.Type;

public class ProductType:ObjectGraphType<Product>
{
    public ProductType()
    {
        Field(x => x.ProductId);
        Field(x => x.Name);
        Field(x => x.Price);
    }
}