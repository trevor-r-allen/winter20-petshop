using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
// using petshop.db;
using petshop.Models;
using petshop.Services;

namespace petshop
{
  [ApiController]
  [Route("api/[controller]")]
  public class DogsController : ControllerBase
  {


    private readonly DogsService _ds;
    public DogsController(DogsService ds)
    {
      _ds = ds;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Dog>> Get()
    {
      try
      {
        return Ok(_ds.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // REVIEW
    [HttpGet("{id}")]
    public ActionResult<Dog> Get(string id)
    {
      try
      {
        Dog dog = _ds.Get(id);
        return Ok(dog);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }


    [HttpPost]
    public ActionResult<Dog> Create([FromBody] Dog newDog)
    {
      try
      {
        Dog dog = _ds.Create(newDog);
        return Ok(dog);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Dog> Edit([FromBody] Dog updated, string id)
    {
      try
      {
        // Dog dog = FAKEDB.Dogs.Find(d => d.Id == id);
        // if (dog == null)
        // {
        //   throw new Exception("invalid Id");
        // }
        // FAKEDB.Dogs.Remove(dog);
        // updated.Id = id;
        // FAKEDB.Dogs.Add(updated);
        updated.Id = id;
        Dog dog = _ds.Edit(updated);
        return Ok(dog);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpDelete("{id}")]
    public ActionResult<String> Delete(string id)
    {

      try
      {
        _ds.Adopt(id);
        return Ok("Adopted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }




  }

}