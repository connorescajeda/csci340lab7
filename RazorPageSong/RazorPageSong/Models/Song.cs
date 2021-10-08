using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageSong.Models
{
    public class Song
    {
        public int ID { get; set; }
   
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public int Plays { get; set; }
    }
}
