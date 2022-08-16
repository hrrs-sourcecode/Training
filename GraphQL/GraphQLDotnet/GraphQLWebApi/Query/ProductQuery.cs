using GraphQL;
using GraphQL.Types;
using GraphQLWebApi.Services.Interfaces;
using GraphQLWebApi.Type;

namespace GraphQLWebApi.Query;

public class ProductQuery:ObjectGraphType
{
    public ProductQuery(IProductService productService)
    {
        Field <ListGraphType<ProductType>>("getproductlist", resolve: ContextCallback => { return productService.GetProductList(); });
        
        Field <ProductType>("getproductbyid", 
            arguments:new QueryArguments(new QueryArgument<IntGraphType>{ Name = "id"}),
            resolve: context => { return productService.GetProductById(context.GetArgument<int>("id")); });
    }
}