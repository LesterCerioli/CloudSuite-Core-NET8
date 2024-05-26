using CloudSuite.Domain.Models;
using CloudSuite.Infrastructure.Mappings.EFCore;
using FluentValidation.Results;

using Microsoft.EntityFrameworkCore;
using NetDevPack.Messaging;

namespace CloudSuite.Infrastructure.Context
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<Media> Medias { get; set; }
               
                     
        public DbSet<Company> Companies {get; set;}

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new AddressEFCoreMapping());

            modelBuilder.ApplyConfiguration(new StateEFCoreMapping());

            modelBuilder.ApplyConfiguration(new CityEFCoreMapping());

            modelBuilder.ApplyConfiguration(new CompanyEFCoreMapping());

            modelBuilder.ApplyConfiguration(new CountryEFCoreMapping());

            modelBuilder.ApplyConfiguration(new DistrictEFCoreMapping());

            
            modelBuilder.ApplyConfiguration(new MediaEFCoreMapping());

            

                       
            modelBuilder.Entity<Address>(c =>
            {
                c.ToTable("Addresses");
            });

            modelBuilder.Entity<State>(c =>
            {
                c.ToTable("States");
            });

            modelBuilder.Entity<City>(c =>
            {
                c.ToTable("Cities");
            });

            modelBuilder.Entity<Country>(c =>
            {
                c.ToTable("Coumtries");
            });

            modelBuilder.Entity<District>(c =>
            {
                c.ToTable("Districts");
            });

            modelBuilder.Entity<Media>(c =>
            {
                c.ToTable("Medias");
            });

            
                        
            modelBuilder.Entity<Company>(c =>
            {
                c.ToTable("Companies");
            });

            


            base.OnModelCreating(modelBuilder);
        }



        

    }
}