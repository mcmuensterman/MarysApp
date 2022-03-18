using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarysApp.Repository
{
    public class Song
    {
        //Properties
        public string Title { get; set; }
        public string Artist { get; set; }
        public Genre Genre { get; set; }
        public bool IsHappy { get; set; }
        public int ReleaseYear { get; set; }


        public Song()
        {

        }

        public Song(string title, string artist, Genre genre, bool isHappy, int releaseYear)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
            IsHappy = isHappy;
            ReleaseYear = releaseYear;
        }
    }



    public enum Genre { Pop, Hip_Hop, Country, Electronica, Oldies, Rock }
}