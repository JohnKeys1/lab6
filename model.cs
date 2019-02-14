using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace lab6
{

    public class MovieApp : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = database.db");
        }
        public DbSet<Movie> Movies {get; set;}
        public DbSet<Studio> Studios {get; set;}
    }

    public class Studio
    {
        public int StudioId {get; set;}
        public string Name {get; set;}
        public List<Movie> Movies{get; set;} 
        public override string ToString()
        {
            return $"Studio {StudioId} - {Name}";
        }
    }

   
    public class Movie
    {
        public int StudioId {get; set;}
        public string Title {get; set;}

        public string Genre{get;set;}
        public int MovieId {get; set;} // Foreign key
        public Studio studio {get; set;} // Navigation property.
        public override string ToString()
        {
            return $"Movie {MovieId} - {Title} -{Genre}";
        }
    }

    
}



