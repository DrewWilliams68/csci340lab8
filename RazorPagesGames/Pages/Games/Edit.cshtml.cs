using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesGames.Data;
using RazorPagesGames.Models;

namespace RazorPagesGames.Pages_Games
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesGames.Data.RazorPagesGamesContext _context;

        public EditModel(RazorPagesGames.Data.RazorPagesGamesContext context)
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

            var games =  await _context.Games.FirstOrDefaultAsync(m => m.Id == id);
            if (games == null)
            {
                return NotFound();
            }
            Games = games;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Games).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesExists(Games.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GamesExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
