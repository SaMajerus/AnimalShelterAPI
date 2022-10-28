using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Dog>()
              .HasData(
                  new Dog { DogId = 1, Name = "Victoria", Country = "Italy", Rating = 3 },
                  new Dog { DogId = 2, Name = "Zeus", Country = "Italy", Rating = 5 },
                  new Dog { DogId = 3, Name = "Remmie", Country = "United States", Rating = 4 }
              );
          builder.Entity<Cat>()
              .HasData(
                  new Cat { CatId = 1, Name = "Todd", Country = "Canada", Rating = 2 },
                  new Cat { CatId = 2, Name = "Buffy", Country = "United States", Rating = 2 }
              );
        }
        // public DbSet<Animal> Animals { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
    }
}