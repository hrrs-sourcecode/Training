using GraphQLWebApi.Model;
using GraphQLWebApi.Services;
using GraphQLWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLWebApi.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    // GET
    [Route("api/[controller]/getproductlist")]
    [HttpGet]
    public IEnumerable<Product> GetProductList()
    {
        return _productService.GetProductList();
    }
    
    [Route("api/[controller]/getproductbyid")]
    [HttpGet]
    public Product GetProductById([FromBody] int id )
    {
        return _productService.GetProductById(id);
    }
    
    [Route("api/[controller]/createproduct")]
    [HttpPost]
    public void CreateProduct([FromBody] Product product )
    {
         _productService.AddProduct(product);
    }
    
    [Route("api/[controller]/updateproduct")]
    [HttpPut]
    public void UpdateProduct([FromBody] Product product)
    {
        _productService.UpdateProduct(product, product.ProductId);
    }
    
    [Route("api/[controller]/deleteproduct")]
    [HttpDelete]
    public void DeleteProduct([FromBody] int id)
    {
        _productService.DeleteProductById(id);
    }
    
}