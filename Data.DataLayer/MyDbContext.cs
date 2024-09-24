using System;

using Data.EntityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.DataLayer
{
    public class MyDbContext : IdentityDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Hood> Hoods { get; set; }
        public DbSet<RealEs> RealEs { get; set; }
        public DbSet<RealEsFeature> RealEsFeatures { get; set; }
        public DbSet<RealEsService> RealEsServices { get; set; }
        public DbSet<RealEsImages> RealEsImages { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           

            // Seed data for Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = "1", Name = "United States" },
                new Country { Id = "2", Name = "Canada" },
                new Country { Id = "3", Name = "United Kingdom" },
                new Country { Id = "4", Name = "Germany" },
                new Country { Id = "5", Name = "France" },
                new Country { Id = "6", Name = "Spain" },
                new Country { Id = "7", Name = "Australia" },
                new Country { Id = "8", Name = "Italy" },
                new Country { Id = "9", Name = "Japan" },
                new Country { Id = "10", Name = "Brazil" }
            );

            // Seed data for Cities
            modelBuilder.Entity<City>().HasData(
                new City { Id = "1", Name = "New York", CountryId = "1" },
                new City { Id = "2", Name = "Los Angeles", CountryId = "1" },
                new City { Id = "3", Name = "Chicago", CountryId = "1" },
                new City { Id = "4", Name = "Toronto", CountryId = "2" },
                new City { Id = "5", Name = "Vancouver", CountryId = "2" },
                new City { Id = "6", Name = "London", CountryId = "3" },
                new City { Id = "7", Name = "Manchester", CountryId = "3" },
                new City { Id = "8", Name = "Berlin", CountryId = "4" },
                new City { Id = "9", Name = "Munich", CountryId = "4" },
                new City { Id = "10", Name = "Paris", CountryId = "5" },
                new City { Id = "11", Name = "Lyon", CountryId = "5" },
                new City { Id = "12", Name = "Madrid", CountryId = "6" },
                new City { Id = "13", Name = "Barcelona", CountryId = "6" },
                new City { Id = "14", Name = "Sydney", CountryId = "7" },
                new City { Id = "15", Name = "Melbourne", CountryId = "7" },
                new City { Id = "16", Name = "Rome", CountryId = "8" },
                new City { Id = "17", Name = "Milan", CountryId = "8" },
                new City { Id = "18", Name = "Tokyo", CountryId = "9" },
                new City { Id = "19", Name = "Osaka", CountryId = "9" },
                new City { Id = "20", Name = "Rio de Janeiro", CountryId = "10" }
            );

            // Seed data for Hoods (Neighborhoods)
            modelBuilder.Entity<Hood>().HasData(
                new Hood { Id = "1", Name = "Manhattan", CityId = "1" },
                new Hood { Id = "2", Name = "Brooklyn", CityId = "1" },
                new Hood { Id = "3", Name = "Beverly Hills", CityId = "2" },
                new Hood { Id = "4", Name = "Hollywood", CityId = "2" },
                new Hood { Id = "5", Name = "Lincoln Park", CityId = "3" },
                new Hood { Id = "6", Name = "Scarborough", CityId = "4" },
                new Hood { Id = "7", Name = "West End", CityId = "5" },
                new Hood { Id = "8", Name = "Soho", CityId = "6" },
                new Hood { Id = "9", Name = "Camden", CityId = "6" },
                new Hood { Id = "10", Name = "Kreuzberg", CityId = "8" },
                new Hood { Id = "11", Name = "Charlottenburg", CityId = "8" },
                new Hood { Id = "12", Name = "Montmartre", CityId = "10" },
                new Hood { Id = "13", Name = "Le Marais", CityId = "10" },
                new Hood { Id = "14", Name = "Gothic Quarter", CityId = "13" },
                new Hood { Id = "15", Name = "Chamberí", CityId = "12" },
                new Hood { Id = "16", Name = "Surry Hills", CityId = "14" },
                new Hood { Id = "17", Name = "Bondi", CityId = "14" },
                new Hood { Id = "18", Name = "Trastevere", CityId = "16" },
                new Hood { Id = "19", Name = "Navigli", CityId = "17" },
                new Hood { Id = "20", Name = "Shibuya", CityId = "18" },
                new Hood { Id = "21", Name = "Shinjuku", CityId = "18" },
                new Hood { Id = "22", Name = "Umeda", CityId = "19" },
                new Hood { Id = "23", Name = "Liberdade", CityId = "20" },
                new Hood { Id = "24", Name = "Ipanema", CityId = "20" },
                new Hood { Id = "25", Name = "Copacabana", CityId = "20" },
                new Hood { Id = "26", Name = "West Village", CityId = "1" },
                new Hood { Id = "27", Name = "Chinatown", CityId = "4" },
                new Hood { Id = "28", Name = "Gastown", CityId = "5" },
                new Hood { Id = "29", Name = "Financial District", CityId = "1" },
                new Hood { Id = "30", Name = "Harlem", CityId = "1" }
            );

            // Seed data for Features
            modelBuilder.Entity<Feature>().HasData(
                new Feature { Id = "1", Name = "Swimming Pool" },
                new Feature { Id = "2", Name = "Gym" },
                new Feature { Id = "3", Name = "Balcony" },
                new Feature { Id = "4", Name = "Garden" },
                new Feature { Id = "5", Name = "Garage" },
                new Feature { Id = "6", Name = "Fireplace" },
                new Feature { Id = "7", Name = "Security System" },
                new Feature { Id = "8", Name = "Air Conditioning" },
                new Feature { Id = "9", Name = "Elevator" },
                new Feature { Id = "10", Name = "Jacuzzi" },
                new Feature { Id = "11", Name = "Sauna" },
                new Feature { Id = "12", Name = "Home Office" },
                new Feature { Id = "13", Name = "Roof Deck" },
                new Feature { Id = "14", Name = "Private Parking" },
                new Feature { Id = "15", Name = "Hardwood Floors" },
                new Feature { Id = "16", Name = "In-Unit Laundry" },
                new Feature { Id = "17", Name = "Smart Home Technology" },
                new Feature { Id = "18", Name = "Walk-In Closet" },
                new Feature { Id = "19", Name = "Barbecue Area" },
                new Feature { Id = "20", Name = "Wine Cellar" },
                new Feature { Id = "21", Name = "High Ceilings" },
                new Feature { Id = "22", Name = "Waterfront" },
                new Feature { Id = "23", Name = "Mountain View" },
                new Feature { Id = "24", Name = "City View" },
                new Feature { Id = "25", Name = "Skylights" }
            );

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = "1", Name = "Residential" },
                new Category { Id = "2", Name = "Commercial" },
                new Category { Id = "3", Name = "Industrial" },
                new Category { Id = "4", Name = "Land" },
                new Category { Id = "5", Name = "Multi-Family" },
                new Category { Id = "6", Name = "Retail" },
                new Category { Id = "7", Name = "Office" },
                new Category { Id = "8", Name = "Mixed-Use" },
                new Category { Id = "9", Name = "Agricultural" },
                new Category { Id = "10", Name = "Hospitality" }
            );
        

        modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            modelBuilder.Entity<RealEsFeature>().HasKey(x => new { FeatureID = x.FeatureId, RealESID = x.RealEsid });
            modelBuilder.Entity<RealEsService>().HasKey(x => new { ServiceID = x.ServiceId, RealESId = x.RealEsId }); // corrected RealESId to RealESID
            modelBuilder.Entity<Favorite>().HasKey(x => new { RealESID = x.RealEsid, UserID = x.UserId });

            modelBuilder.Entity<RealEsFeature>()
                .HasOne(rf => rf.RealEs)  // Assuming RealES is the navigation property
                .WithMany(r => r.RealEsFeatures)  // Assuming RealESFeatures is the collection in the RealES entity
                .HasForeignKey(rf => rf.RealEsid)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Favorite>()
      .HasOne(f => f.RealEs)
      .WithMany(r => r.Favorites)
      .HasForeignKey(f => f.RealEsid)
      .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comments>()
      .HasOne(c => c.RealEs)
      .WithMany(re => re.Comments)
      .HasForeignKey(c => c.RealEsid)
      .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comments>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Address>()
                .HasOne(x => x.Country).WithMany(x => x.Addresses).HasForeignKey(x => x.CountryId);
            modelBuilder.Entity<Address>()
                    .HasOne(x => x.City).WithMany(x => x.Addresses).HasForeignKey(x => x.CityId);
            modelBuilder.Entity<Address>()
                    .HasOne(x => x.Hood).WithMany(x => x.Addresses).HasForeignKey(x => x.HoodId);
            modelBuilder.Entity<Address>()
                   .HasOne(a => a.RealEs)
                   .WithOne(r => r.Address)
                   .HasForeignKey<RealEs>(r => r.AddressId).OnDelete(DeleteBehavior.Cascade);







            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(x => x.Cities)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hood>()
                .HasOne(c => c.City)
               .WithMany(x => x.Hoods)
               .HasForeignKey(x => x.CityId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Room>()
               .HasOne(c => c.RealEs)
              .WithOne(x => x.Room)
              .HasForeignKey<RealEs>(x => x.RoomId)
              .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
