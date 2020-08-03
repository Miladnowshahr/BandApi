using BandApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandApi.DataLayer
{
    public class BandDbContext:DbContext
    {
        public BandDbContext(DbContextOptions<BandDbContext> options):base(options) { }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }

        public IConfiguration Configuration { get; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
            base.OnConfiguring(optionsBuilder);
        }


        public static async Task CreateSeedData(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
              var service=  serviceScope.ServiceProvider.GetService<BandDbContext>();
                Seed(service);
            }
        }

        public static void Seed(BandDbContext context)
        {
            context.Bands.Add(new Band
            {
                BandId = Guid.Parse("DAFD8BA4-12D0-B692-49DF-876E317246FB"),
                            Name = "Metallica",
                            Founded = new DateTime(1980, 1, 1),
                            MainGenre = "Heavy Metal",

            });
            context.SaveChanges();
        }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Band>(b =>
        //    {
        //        b.HasData(new Band
        //        {
        //            Id = Guid.Parse("DAFD8BA4-12D0-B692-49DF-876E317246FB"),
        //            Name = "Metallica",
        //            Founded = new DateTime(1980, 1, 1),
        //            MainGenre = "Heavy Metal",
                 
        //        }) ;
        //        b.HasData(new Band
        //        {
        //            Id = Guid.Parse("E7253167-2547-4F9B-E79F-6A903A558BEC"),
        //            Name = "Abba",
        //            Founded = new DateTime(1965, 7, 1),
        //            MainGenre = "Disco"
        //        });
        //        b.HasData(new Band {
        //            Id = Guid.Parse("EB265F32-268C-54B8-76EA-CA3689741EAE"),
        //            Name = "A-ha",
        //            Founded = new DateTime(1981, 6, 5),
        //            MainGenre = "pop"
        //        });
               
        //    });

        //    modelBuilder.Entity<Album>(a =>
        //    {
        //        a.HasData(new Album
        //        {
        //            BandId = Guid.Parse("DAFD8BA4-12D0-B692-49DF-876E317246FB"),
        //            Id = Guid.NewGuid(),
        //            Title = "Master of Puppets",
        //            Description = "One of the best heavy Metal album ever",
        //        }) ;
        //        a.HasData(new Album
        //        {
        //            BandId = Guid.Parse("E7253167-2547-4F9B-E79F-6A903A558BEC"),
        //            Title = "Hunting Hight and Low",
        //            Description = "Awesome Debut album by A-Ha",
        //            Id = Guid.NewGuid()
        //        });
        //    });

        //    //has data like seed    
        //    //modelBuilder.Entity<Band>().HasData(new Band()
        //    //{
                
        //    //     new Band
        //    //{
                
        //    //},
        //    //new Band
        //    //{
               
        //    //},
        //    //new Band
        //    //{
        //    //    Id = Guid.Parse("3B82E4F7-E846-6548-468C-A949A2A95BCB"),
        //    //    Name = "Black Cat",
        //    //    Founded = new DateTime(1981, 5, 1),
        //    //    MainGenre = "Pop"

        //    //}});

        //    //    Id = Guid.NewGuid(),
        //    //    Name = "Metallica",
        //    //    Founded = new DateTime(1980, 1, 1),
        //    //    MainGenre = "Heavy Metal",
        //    //    Albums=new List<Album>() 
        //    //    { new Album{

        //    //         Id = Guid.NewGuid(),
        //    //        Title = "Master of Puppets",
        //    //        Description = "One of the best heavy Metal album ever",
        //    //    }}

        //    //},
        //    //new Band
        //    //{
        //    //    Id = Guid.NewGuid(),
        //    //    Name = "Guns N Roses",
        //    //    Founded = new DateTime(1985, 2, 1),
        //    //    MainGenre = "Rock",
        //    //    Albums=new List<Album>() { new Album { 
        //    //        Title="Hunting Hight and Low",
        //    //        Description="Awesome Debut album by A-Ha",
        //    //        Id=Guid.NewGuid()
        //    //    } }
        //    //},

        //    base.OnModelCreating(modelBuilder); 
        //}

    }
}

