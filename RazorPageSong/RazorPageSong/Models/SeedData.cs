using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPageSong.Data;
using System;
using System.Linq;

namespace RazorPageSong.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPageSongContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPageSongContext>>()))
            {
                // Look for any movies.
                Console.WriteLine(context.Song.Any());
                if (context.Song.Any())
                {   
                    Console.WriteLine("test");
                    return;   // DB has been seeded
                }

                context.Song.AddRange(
                    new Song
                    {
                    
                        Title = "Perfect",
                        Artist = "Logic",
                        Album = "Bobby Tarantino",
                        Genre = "Rap",
                        Plays = 100000,
                        Rating = "10"
                    },

                    new Song
                    {
                       
                        Title = "Super",
                        Artist = "Cordae",
                        Album = "Super",
                        Genre = "Rap",
                        Plays = 100000,
                        Rating = "9"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}