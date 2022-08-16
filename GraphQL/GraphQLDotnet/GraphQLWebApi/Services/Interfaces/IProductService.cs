using GraphQLWebApi.Model;

namespace GraphQLWebApi.Services.Interfaces;

public interface IProductService
{
    IList<Product> GetProductList();

    Product GetProductById(int productId);
    
    Product AddProduct(Product product);
    
    Product UpdateProduct(Product product, int productId);

    void DeleteProductById(int productId);
}