using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesGames.Models;

namespace RazorPagesGames.Data
{
    public class RazorPagesGamesContext : DbContext
    {
        public RazorPagesGamesContext (DbContextOptions<RazorPagesGamesContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesGames.Models.Games> Games { get; set; } = default!;
    }
}
