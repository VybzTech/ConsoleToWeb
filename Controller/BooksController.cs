using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWeb.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    //ROUTE CONSTRAINTS
    [Route("{id:int:min(10):max(100)}")]
    public string GetById(int id)
    {
      return "hello int " + id;
    }

    // [Route("{id:range(5,50)}")]
    // [Route("{id:minlength(5):maxlength(20)}")]
    [Route("{id:length(5):alpha}")]
    public string GetByIdString(string id)
    {
      return "hello string " + id;
    }

    [Route("{id:regex(a(b|c))}")]
    public string GetByIdRegex(string id)
    {
      return "hello regex " + id;
    }
  }
}