using Microsoft.EntityFrameworkCore;
using RazorPagesGames.Data;

namespace RazorPagesGames.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesGamesContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesGamesContext>>()))
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
                    GameTitle = "Game PlaceHolder",
                    Price = 3.99M,
                    Type = "RPG",
                    SoldCopies = "3 mil",
                    SkillLevel = "Hard"
                },

                new Games
                {
                    GameTitle = "Game PlaceHolder",
                    Price = 3.99M,
                    Type = "RPG",
                    SoldCopies = "3 mil",
                    SkillLevel = "Hard"
                },

                new Games
                {
                    GameTitle = "Game PlaceHolder",
                    Price = 3.99M,
                    Type = "RPG",
                    SoldCopies = "3 mil",
                    SkillLevel = "Hard"
                },

                new Games
                {
                    GameTitle = "Game PlaceHolder",
                    Price = 3.99M,
                    Type = "RPG",
                    SoldCopies = "3 mil",
                    SkillLevel = "Hard"
                    
                }
            );
            context.SaveChanges();
        }
    }
}