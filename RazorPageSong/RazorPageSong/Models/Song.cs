using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPageSong.Models
{
    public class Song
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string Album { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        public string Genre { get; set; }
        [Range(1, (1*10^30))]
        [Required]
        public int Plays { get; set; }
        [RegularExpression(@"^[0-9]")]
        [Required]
        public string Rating { get; set; }
    }
}
