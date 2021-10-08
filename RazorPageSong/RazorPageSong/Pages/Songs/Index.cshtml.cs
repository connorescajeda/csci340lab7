using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task OnGetAsync()
        {
            Song = await _context.Song.ToListAsync();
        }
    }
}
