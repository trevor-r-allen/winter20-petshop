using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using petshop.db;
using petshop.Models;

namespace petshop.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DogsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Dog>> Get()
    {
      try
      {
        return Ok(FAKEDB.Dogs);
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpGet("{dogId}")]
    public ActionResult<Dog> GetDogById(string dogId)
    {
      try
      {
        Dog dogToReturn = FAKEDB.Dogs.Find(d => d.Id == dogId);
        return Ok(dogToReturn);
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Dog> Create([FromBody] Dog newDog)
    {
      try
      {
        FAKEDB.Dogs.Add(newDog);
        return Ok(newDog);
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpPut("{dogId}")]
    public ActionResult<Dog> EditDog([FromBody] Dog editedDog, string dogId)
    {
      try
      {
        Dog dogToEdit = FAKEDB.Dogs.Find(d => d.Id == dogId);
        FAKEDB.Dogs.Remove(dogToEdit);
        dogToEdit.Name = editedDog.Name != null ? editedDog.Name : dogToEdit.Name;
        dogToEdit.Description = editedDog.Description != null ? editedDog.Description : dogToEdit.Description;
        dogToEdit.IsAGoodBoy = editedDog.IsAGoodBoy;
        FAKEDB.Dogs.Add(dogToEdit);
        return Ok(dogToEdit);
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{dogId}")]
    public ActionResult<string> RemoveDog(string dogId)
    {
      try
      {
        Dog dogToRemove = FAKEDB.Dogs.Find(d => d.Id == dogId);
        FAKEDB.Dogs.Remove(dogToRemove);
        return Ok("Dog Removed");
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }


  }
}