using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
            : base(options)
        {
        } /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Animal>()
              .HasData(
                  new Animal { AnimalId = 1, Name = "Victoria", Type = "Dog", Age = 3 },
                  new Animal { AnimalId = 2, Name = "Zeus", Type = "Dog", Age = 5 },
                  new Animal { AnimalId = 3, Name = "Remmie", Type = "Dog", Age = 4 }, 
                  new Animal { AnimalId = 1, Name = "Todd", Type = "Cat", Age = 1 },
                  new Animal { AnimalId = 2, Name = "Buffy", Type = "Cat", Age = 2 }
              );
        }  */ 
        public DbSet<Animal> Animals { get; set; } 
    }
}