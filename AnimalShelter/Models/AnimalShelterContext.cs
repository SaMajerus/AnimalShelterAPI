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
          builder.Entity<Place>()
              .HasData(
                  new Place { PlaceId = 1, Name = "Venice", Country = "Italy", Rating = 3 },
                  new Place { PlaceId = 2, Name = "Rome", Country = "Italy", Rating = 5 },
                  new Place { PlaceId = 3, Name = "Toronto", Country = "Canada", Rating = 2 },
                  new Place { PlaceId = 4, Name = "Toledo", Country = "United States", Rating = 4 },
                  new Place { PlaceId = 5, Name = "Buffalo", Country = "United States", Rating = 2 }
              );
          builder.Entity<Review>()
              .HasData(
                  new Review { ReviewId = 1, UserName = "Josh", PlaceId = 1}
              );
        }
        public DbSet<Place> Places { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}