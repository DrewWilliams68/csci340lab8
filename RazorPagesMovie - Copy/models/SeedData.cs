using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()))
            {
                if (context == null || context.Games == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Games.Any())
                {
                    return;   // DB has been seeded
                }

                context.Games.AddRange(
                    new Games
                    {
                        GameTitle = "MineCraft",
                        Price = 29.99M,
                        Type = "Adventure",
                        SoldCopies = "239 million",
                        SkillLevel = "Easy"
                    },

                    new Games
                    {
                        GameTitle = "MineCraft",
                        Price = 29.99M,
                        Type = "Adventure",
                        SoldCopies = "239 million",
                        SkillLevel = "Easy"
                    },

                    new Games
                    {
                        GameTitle = "MineCraft",
                        Price = 29.99M,
                        Type = "Adventure",
                        SoldCopies = "239 million",
                        SkillLevel = "Easy"
                    },

                    new Games
                    {
                        GameTitle = "MineCraft",
                        Price = 29.99M,
                        Type = "Adventure",
                        SoldCopies = "239 million",
                        SkillLevel = "Easy"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}