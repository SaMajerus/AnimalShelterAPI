using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace AnimalShelter.Models
{
  public class Animal
  {
    public Animal()
    {
      this.Animals = new HashSet<Animal>();
    }
    public int AnimalId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Type { get; set; }  //i.e. 'Dog' or 'Cat'  
    [Required]
    [Range(0, 5, ErrorMessage = "Age must be between 0 and 25 years.")]
    public int Age { get; set; }
    public string Description { get; set; } 
    public ICollection<Animal> Animals { get; set; }
  }
}