using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGames.Data;
using RazorPagesGames.Models;

namespace RazorPagesGames.Pages_Games
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesGames.Data.RazorPagesGamesContext _context;

        public IndexModel(RazorPagesGames.Data.RazorPagesGamesContext context)
        {
            _context = context;
        }

        public IList<Games> Games { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Games = await _context.Games.ToListAsync();
        }
    }
}
