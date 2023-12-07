using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleToWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWeb.Controller
{

  //   private List<AnimalModel>(){
  //   }
  // var animalist = new List<AnimalModel>() {

  [ApiController]
  [Route("api/[controller]")]
  public class AnimalController : ControllerBase
  {
    private List<AnimalModel> animals = null;
    // MOVE ANIMALS OBJECT TO A CONSTRUCTOR
    public AnimalController()
    {
      animals = new List<AnimalModel>() {
        new AnimalModel() {id=1,animalName="Dog" },
        new AnimalModel() {id=2,animalName="Pig" },
        new AnimalModel() {id=3,animalName="Rat" },
      new AnimalModel() {id=4,animalName="Hen" },
      new AnimalModel() {id=5,animalName="Cat" },
      new AnimalModel() {id=6, animalName="Goat"},
      new AnimalModel() {id=7, animalName="Lion"},
      new AnimalModel() {id=8, animalName="Cow"},
      };
    }

    //RETURNING STATUS 200  (OK STATUS TYPE)
    [Route("", Name = "All")]
    public IActionResult GetAnimals()
    {
      return Ok(animals);
    }

    //RETURNING STATUS 202
    [Route("test")]
    public IActionResult GetAnimalsTest()
    {
      // ACCEPTED STATUS TYPE
      // return Accepted("~/api/animals");

      // GETTING RESOLVED 202 STATUS TO ALREADY DEVELOPED ACTION METHOD
      // return AcceptedAtAction("GetAnimals");

      // GETTING RESOLVED 202 STATUS TO ALREADY DEVELOPED ACTION METHOD
      // return AcceptedAtRoute("All");

      //GETTING 301, 302 & REDIRECTING LINK
      // return LocalRedirect("~/api/animals"); //301 
      return LocalRedirectPermanent("~/api/animals"); //302
    }

    // RETRIEVING ANIMALS BY NAME
    [Route("{name}")]
    public IActionResult GetAnimalsByName(string name)
    {
      if (!name.Contains("ABC"))
      {
        return BadRequest();
      }
      return Ok(animals);
    }

    // RETRIEVING ANIMALS BY ID
    [Route("{id:int}")]
    public IActionResult GetAnimalsById(int id)
    {
      // RETURNING A NOT FOUND PAGE 404
      // NoContent();
      // NotFound(Object value);
      // NotFound();

      if (id == 0)
      {
        // RETURNING A BAD REQUEST
        return BadRequest();
      }
      var animal = animals.FirstOrDefault(x => x.id == id);
      if (animal == null)
      {
        return NotFound();
      }
      return Ok(animal);
    }

    //RETURNING STATUS 201
    [HttpPost("")]
    public IActionResult GetAnimals(AnimalModel animal)
    {
      animals.Add(animal);
      // return Created("~/api/animals/"+animal.id, animal); 
      return CreatedAtAction("GetAnimalsById",
      new { id = animal.id }, animal);
    }
  }
}