using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // UserProfile
            builder.Entity<UserProfile>()
                .HasKey(pk => pk.UserId);

            builder.Entity<UserProfile>()
                .HasOne(u => u.User)
                .WithOne(p => p.UserProfile)
                .HasForeignKey<UserProfile>(fk => fk.UserId);

            builder.Entity<UserProfile>()
                .HasOne(u => u.City)
                .WithMany(p => p.UserProfiles)
                .HasForeignKey(fk => fk.CityId);

            // City 
            builder.Entity<City>()
                .HasKey(pk => pk.CityId);

            builder.Entity<City>()
                .HasOne(u => u.Country)
                .WithMany(p => p.Cities)
                .HasForeignKey(fk => fk.CountryId);

            // Country
            builder.Entity<Country>()
                .HasKey(pk => pk.CountryId);
            
        }

    
    }
}
