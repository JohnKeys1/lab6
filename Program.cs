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

            using (var db = new MovieApp())
            {
                Movie movie = new Movie { Title = "Jurassic Park",Genre="Action"};
                Studio StudioToUpdate = db.Studios.Include(b => b.Movies).Where(b => b.Name == "universal pictures").First();
                StudioToUpdate.Movies.Add(movie);
                db.SaveChanges();
            }
             using (var db = new MovieApp())
            {
                Movie movie = db.Movies.Where(m => m.Title == "Apollo3").First();
                movie.studio = db.Studios.Where(b => b.Name == "universal pictures").First();
                db.SaveChanges();
            }
             using (var db = new MovieApp())
            {
                Movie movie = db.Movies.Where(m => m.Title == "Deadpool").First();
                Studio StudioToUpdate = db.Studios.Include(b => b.Movies).Where(b => b.Name == "20th century FOX").First();
                StudioToUpdate.Movies.Remove(movie);
                db.SaveChanges();
            }
        /* using (var db = new MovieApp()){
            foreach (var b in Movies )
                {
                    Console.WriteLine($"StudioID: {b.studioId} {b.Studio}");
                    foreach (var m in m.Movies)
                    {
                        Console.WriteLine($"\t{m.Title}");
                    }
                }
                }*/ 
                //Console.WriteLine("{0}",Movies,Studios);
                using (var db = new MovieApp())
            {
                var studios = db.Studios.Include(b => b.Movies);
                foreach (var b in studios)
                {
                    Console.WriteLine(b);
                    foreach (var m in b.Movies)
                    {
                       Console.WriteLine("\t" + m);
                    }
                }
            }
         }   
    }
}       