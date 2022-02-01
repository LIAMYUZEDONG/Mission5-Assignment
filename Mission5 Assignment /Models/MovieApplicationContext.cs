using System;
using Microsoft.EntityFrameworkCore;

namespace Movie.Models
{
    public class MovieApplicationContext : DbContext
    {
        // constructor
      public MovieApplicationContext (DbContextOptions<MovieApplicationContext> options) : base (options)
        {  // Blank
         
        }

      //Seed Data
      public DbSet<ApplicationResponse> NewResponses { get; set; }
      public DbSet<Category> Category { get; set; }


      protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Action/Adventure"},
                new Category { CategoryID = 2, CategoryName = "Comedy" },
                new Category { CategoryID = 3, CategoryName = "Drama" },
                new Category { CategoryID = 4, CategoryName = "Family" },
                new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 7, CategoryName = "Television" },
                new Category { CategoryID = 8, CategoryName = "VHS" }
                );


            mb.Entity<ApplicationResponse>().HasData(


                new ApplicationResponse
                {
                    ApplicationId = 1,
                    CategoryID = 1,
                    Title = "Enter the Dragon",
                    Year = 1973,
                    Director = "Robert Clouse",
                    Rating = "R",
                    Edited = "Yes",
                    LentTo = "Holywood",
                    Notes = "Bruce is the best!"
                },
                new ApplicationResponse
                {
                    ApplicationId = 2,
                    CategoryID = 1,
                    Title = "The Way of the Dragon",
                    Year = 1970,
                    Director = "Bruce Lee",
                    Rating = "R",
                    Edited = "Yes",
                    LentTo = "Holywood",
                    Notes = "JDK"
                },
                new ApplicationResponse
                {
                    ApplicationId = 3,
                    CategoryID = 1,
                    Title = "ShangChi",
                    Year = 2021,
                    Director = "Daneil Creton",
                    Rating = "PG-13",
                    Edited = "Yes",
                    LentTo = "Holywood",
                    Notes = "Simu Liu"
                }



                );
        }
    }
}
