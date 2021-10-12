using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageSong.Data;
using RazorPageSong.Models;

namespace RazorPageSong.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageSong.Data.RazorPageSongContext _context;

        public IndexModel(RazorPageSong.Data.RazorPageSongContext context)
        {
            _context = context;
        }

        public IList<Song> Song { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SongGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Song
                                            orderby m.Genre
                                            select m.Genre;

            var songs = from m in _context.Song
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                songs = songs.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SongGenre))
            {
                songs = songs.Where(x => x.Genre == SongGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Song = await songs.ToListAsync();
        }
    }
}
