using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assignment5_Voglewede_Woods.Models
{
    [Keyless]
    public class GenreViewModel
    {
        public List<Music_Inventory>? Music { get; set; }
        public SelectList? Genres { get; set; }
        public string? MusicGenre { get; set; }
        public string? SearchString { get; set; }
        public List<Music_Inventory>? Songs { get; set; }
        public SelectList? Performers { get; set; }
        public string? MusicPerformer { get; set; }
        //public string? SearchString { get; set; }
    }
}
