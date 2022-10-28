// using System.ComponentModel.DataAnnotations;
// using System.Collections.Generic;
// using System.Text.Json.Serialization;
// namespace AnimalShelter.Models
// {
//   public class Cat
//   {
//     public int CatId { get; set; }
//     [Required]
//     public string Name { get; set; }
//     //[Required]
//     //[Range(1, 5, ErrorMessage = "Rating must be between a 1 and 5.")]
//     //public int UserRating { get; set; }
//     public int AnimalId { get; set; }
//     [JsonIgnore]
//     public virtual Animal Animal { get; set; }
//   }
// }