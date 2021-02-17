using System;
using System.ComponentModel.DataAnnotations;

namespace petshop.Models
{



  public class Dog
  {
    [Required]
    public string Name { get; set; }
    [Range(0, 100)]
    public int Age { get; set; }
    public bool Hungry { get; set; } = true;

    public string Id { get; set; } = Guid.NewGuid().ToString();

  }


}