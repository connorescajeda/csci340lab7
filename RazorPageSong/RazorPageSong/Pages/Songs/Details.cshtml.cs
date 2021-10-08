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
    public class DetailsModel : PageModel
    {
        private readonly RazorPageSong.Data.RazorPageSongContext _context;

        public DetailsModel(RazorPageSong.Data.RazorPageSongContext context)
        {
            _context = context;
        }

        public Song Song { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Song = await _context.Song.FirstOrDefaultAsync(m => m.ID == id);

            if (Song == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
