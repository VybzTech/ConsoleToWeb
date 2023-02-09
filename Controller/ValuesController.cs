using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWeb.Controllers
{

  [ApiController]
  //   [Route("[controller]/[action]")]
  public class ValuesController : ControllerBase
  {
    //ROUTES FOR STRING TEMP
    [Route("/api/get-all")]
    [Route("get-all")]
    [Route("~/getall")]
    public string GetAll() => "hello from get all";

    [Route("api/get-all-authors")]
    [Route("getallauthors")]
    public string GetAllAuthors() => "hello from get all authors";


    //ROUTES FOR DYNAMIC ROUTES
    [Route("books/{id}")]
    // [Route("{id}")]  to be used if base route is defined
    public string GetById(int id) => "hello " + id;

    //ROUTES FOR NESTED DYNAMIC ROUTES
    [Route("books/{id}/author/{authorId}")]
    public string GetAuthorAddressById(int id, int authorId) => "hello author of Book address: " + id + ", with addresss: " + authorId;

    //ROUTES FOR METHOD OF QUERY STRING
    [Route("search")]
    public string SearchBooks(int id, int authorId, string name, int rating, int price) => id + ". Hello " + name + ", from Author " + authorId + "; In search of " + rating + " star Rated hotel at " + price + " Naira Price Lol :-)";
  }
}