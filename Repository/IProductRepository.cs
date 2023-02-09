using System.Collections.Generic;
using ConsoleToWeb.Models;

namespace ConsoleToWeb.Repository
{
  public interface IProductRepository
  {

    int AddProduct(ProductModel product);

    List<ProductModel> GetAllProducts();
    string GetName();
  }
}