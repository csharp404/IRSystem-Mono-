using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
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
