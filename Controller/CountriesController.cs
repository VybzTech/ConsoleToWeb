using ConsoleToWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWeb.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // [BindProperty(SupportsGet = true)]
  public class CountriesController : ControllerBase
  {
    //BINDS DIFF PROPERTIES FROM COUNTRY MODEL
    // [BindProperty]
    // public CountryModel Country { get; set; }

    // [BindProperty]
    // public string Name { get; set; }
    // public int population { get; set; }

    // FROM QUERY

    // [HttpGet("{name}")]
    // public IActionResult AddCountry([FromQuery]string name)=>Ok($"Name= {name}");

    // Multiple Values 
    // [HttpGet("{name}")]
    // public IActionResult AddCountry([FromQuery]int id, [FromQuery] CountryModel model)=>Ok($"Name= {model.name}");

    // FROM ROUTE
    // [HttpPost("{name}/{population}/{Area}")]
    // public IActionResult AddCountry([FromRoute] CountryModel model, [FromQuery] int id) => Ok($"My Id is {id} and Name = {model.Name}");

    // FROM BODY
    [HttpPost("{id}")]
    public IActionResult AddCountry([FromBody] int id) => Ok($"My Id is {id}.");

    // DEFAULT POST LINK TO RETRIEVE DATA
    // [HttpPost("{name}")]
    // public IActionResult AddCountry(string name)=>Ok($"Name= {name}");

    // public IActionResult AddCountry([FromRoute] int id, [FromHeader] string developer,
    //     [FromHeader] string course)=>
    //  Ok($"Name= {id}");

    // return Ok($"Country {this.Country.Id} is " + $"Name = {this.Country.Name}, " + $"with a population of {this.Country.Population} people, " + $"in Area {this.Country.Area}...");

    /*

    //  CUSTOM BINDER
    [HttpGet("search")]
    public IActionResult SearchCounties([ModelBinder(typeof(CustomBinder))]string[] countries)
    {
        return Ok(countries);
    }

    //  CUSTOM DETAIL BINDER
    [HttpGet("{id}")]
    public IActionResult CountryDetails([ModelBinder(Name ="Id")]CountryModel country)
    {
        return Ok(country);
    }

    */
  }
}