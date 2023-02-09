using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWeb.Controller
{
  //Add the Api attribute
  [ApiController]
  //Add the Routing attributeP
  [Route("test/[action]")]
  public class AppTestController : ControllerBase
  {
    public string Get() => "Some content from Get...";
    public string GetPath() => "Some New content from GetPath...";
    public string GetName() => "Some New content from GetName...";
  }
}
