using System;
using System.Collections.Generic;
using petshop.db;
using petshop.Models;

namespace petshop.Services
{
  public class DogsService
  {
    // GetAll
    public IEnumerable<Dog> Get()
    {
      return FAKEDB.Dogs;
    }

    // GetById
    public Dog Get(string id)
    {
      Dog dog = FAKEDB.Dogs.Find(d => d.Id == id);
      if (dog == null)
      {
        throw new Exception("invalid Id");
      }
      return dog;
    }

    // Create
    public Dog Create(Dog newDog)
    {
      FAKEDB.Dogs.Add(newDog);
      return newDog;
    }

    // Edit
    public Dog Edit(Dog updated)
    {
      Dog dog = FAKEDB.Dogs.Find(d => d.Id == updated.Id);
      if (dog == null)
      {
        throw new Exception("invalid Id");
      }
      FAKEDB.Dogs.Remove(dog);
      FAKEDB.Dogs.Add(updated);
      return updated;
    }

    // Adopt
    public string Adopt(string id)
    {
      Dog dog = FAKEDB.Dogs.Find(d => d.Id == id);
      if (dog == null)
      {
        throw new Exception("invalid Id");
      }
      FAKEDB.Dogs.Remove(dog);
      return "Adopted";
    }
  }

}