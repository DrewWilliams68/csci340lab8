using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGames.Data;
using RazorPagesGames.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
         
         [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Types { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? GameType { get; set; }

    public async Task OnGetAsync()
    {
    // <snippet_search_linqQuery>
        IQueryable<string> typeQuery = from m in _context.Games
                                        orderby m.Type
                                        select m.Type;
    // </snippet_search_linqQuery>

        var games = from m in _context.Games
                    select m;

        if (!string.IsNullOrEmpty(SearchString))
        {
            games = games.Where(s => s.GameTitle.Contains(SearchString));
        }

        if (!string.IsNullOrEmpty(GameType))
        {
            games = games.Where(x => x.Type == GameType);
        }

        // <snippet_search_selectList>
        Types = new SelectList(await typeQuery.Distinct().ToListAsync());
    // </snippet_search_selectList>
        Games = await games.ToListAsync();
}
    }
}
