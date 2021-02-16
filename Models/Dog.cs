using System;
using System.ComponentModel.DataAnnotations;

namespace petshop.Models
{
  public class Dog
  {
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string Description { get; set; }
    [Required]
    public bool IsAGoodBoy { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public Dog(string name, string description, bool isAGoodBoy)
    {
      this.Name = name;
      this.Description = description;
      this.IsAGoodBoy = isAGoodBoy;

    }
  }
}