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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesGames.Data.RazorPagesGamesContext _context;

        public DeleteModel(RazorPagesGames.Data.RazorPagesGamesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Games Games { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games.FirstOrDefaultAsync(m => m.Id == id);

            if (games is not null)
            {
                Games = games;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games.FindAsync(id);
            if (games != null)
            {
                Games = games;
                _context.Games.Remove(Games);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
