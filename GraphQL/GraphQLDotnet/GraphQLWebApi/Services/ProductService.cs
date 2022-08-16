using GraphQLWebApi.Data;
using GraphQLWebApi.Model;
using GraphQLWebApi.Services.Interfaces;

namespace GraphQLWebApi.Services;

public class ProductService : IProductService
{
    private readonly GraphQLDbContext _dbContext;
    public ProductService(GraphQLDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    private static IList<Product> _productList = new List<Product>
    {
        new Product { ProductId = 1, Name = "Tea", Price = 20000 },
        new Product { ProductId = 2, Name = "Coffee", Price = 25000 },
        new Product { ProductId = 3, Name = "Kencur", Price = 2000 },
    };

    public IList<Product> GetProductList()
    {
        //return _dbContext.Products.ToList();
        return _productList;
    }

    public Product GetProductById(int productId)
    {
        //return _dbContext.Products.Find(productId);
        return  _productList.FirstOrDefault(x => x.ProductId == productId);
    }

    public Product AddProduct(Product product)
    {
        // _dbContext.Products.Add(product);
        // _dbContext.SaveChanges();
        
        _productList.Add(product);
        return product;
    }

    public Product UpdateProduct(Product product, int productId)
    {
        Product productToEdit = _productList.FirstOrDefault(x => x.ProductId == productId);
        
        if (productToEdit == null)
        {
            return new Product();
        }
        
        int idx = _productList.IndexOf(productToEdit);
        _productList[idx] = product;
        // Product productToEdit = _dbContext.Products.Find(productId);
        // productToEdit.Name = product.Name;
        // productToEdit.Price = product.Price;
        // _dbContext.SaveChanges();

        return product;
    }

    public void DeleteProductById(int productId)
    {
        // Product productToDelete = _dbContext.Products.Find(productId);
        // _dbContext.Products.Remove(productToDelete);
        // _dbContext.SaveChanges();

         int idx = _productList.IndexOf(_productList.FirstOrDefault(x => x.ProductId == productId));
        _productList.RemoveAt(idx);
    }
}