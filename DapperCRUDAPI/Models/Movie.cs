using System;
using System.ComponentModel.DataAnnotations;

namespace DapperCRUDAPI.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string ReleaseDate { get; set; }
        public double IMDbscore { get; set; }
    }
}
