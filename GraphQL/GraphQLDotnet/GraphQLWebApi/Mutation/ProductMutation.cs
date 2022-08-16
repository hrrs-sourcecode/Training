using GraphQL;
using GraphQL.Types;
using GraphQLWebApi.Model;
using GraphQLWebApi.Services.Interfaces;
using GraphQLWebApi.Type;

namespace GraphQLWebApi.Mutation;

public class ProductMutation:ObjectGraphType
{
    public ProductMutation(IProductService productService)
    {
        Field <ProductType>("createproduct", 
            arguments:new QueryArguments(new QueryArgument<ProductInputType>{ Name = "product"}),
            resolve: context => { return productService.AddProduct(context.GetArgument<Product>("product")); });
        
        Field <ProductType>("updateproduct", 
            arguments:new QueryArguments(
                new QueryArgument<ProductInputType>{ Name = "product"},
                new QueryArgument<IntGraphType>{ Name = "id"}),
            resolve: context => { return productService.UpdateProduct(
                context.GetArgument<Product>("product"),context.GetArgument<int>("id")); });
        
        Field <StringGraphType>("deleteproduct", 
            arguments:new QueryArguments(
                new QueryArgument<IntGraphType>{ Name = "id"}),
            resolve: context =>
            {
                int id = context.GetArgument<int>("id");
                productService.DeleteProductById(id);
                return $"The product id {id} been successfully deleted";
            });
    }
}