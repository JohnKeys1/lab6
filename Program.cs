using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace lab6
{
 class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MovieApp())
            {
                // Useful tactic ONLY in development.
                // At start of your program, always delete the database and then re-create it
                // This ensures a fresh database everytime you run your program.
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            // Add a blog with posts right away
            using (var db = new MovieApp())
            {
                Studio studio1 = new Studio 
                {
                    Name = "20th century FOX",
                    Movies = new List<Movie>
                    {
                        new Movie { Title = "Avatar",Genre="Action" },
                        new Movie { Title = "Deadpool",Genre="Action"  },
                        new Movie { Title = "Apollo3",Genre="Drama" },
                        new Movie { Title = "The martian",Genre="Sci-FI" }
                    }
                };

              Studio studio2 = new Studio 
                {
                    Name = "universal pictures",
                };

                db.Add(studio1);
                db.Add(studio2);
                db.SaveChanges();
            }

         }   // Add posts to an existing blog by updating post.Blog object
    }
}       