using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarysApp.Repository;
public class MarysAppRepository
{

    //your app should support a CREATE object, READ ALL objects, READ one object
    //The class should have properties of at least one (1) of each of the following data types: string, enum, bool, int

        private List<Song> _songList = new List<Song>();

    

        //create
        public void AddSongToList(Song song)
        {
            _songList.Add(song);
        }

        //read all
        public List<Song>
        GetAllSongs()
        {
            return _songList;
        }

        //read one
        public Song GetSongByTitle(string userInput)
        {
            foreach (Song song in _songList)
            {
                if (song.Title.ToUpper() == userInput.ToUpper())
                {
                    return song;
                }
            }

            return null;
        }

        

        //seed data
        public void SeedSongData()
        {
            Song nyState = new Song("NY State of Mind", "Nas", Genre.Hip_Hop, false, 1994);
            Song aHouse = new Song("A House is Not a Motel", "Love", Genre.Pop, true, 1967);
            Song onceInALifeTime = new Song ("Once in a Lifetime", "Talking Heads", Genre.Electronica, true, 1981);
            Song iCouldHave = new Song("I Could Have Danced All Night", "Marni Nixon", Genre.Oldies, true, 1956);
            Song idiotWind = new Song("Idiot Wind", "Nas", Genre.Rock, false, 1975);
            Song pourOut = new Song("Pour Out a Little Liquor", "2Pac", Genre.Hip_Hop, false, 1994);
            Song lucky = new Song("Lucky", "Britney Spears", Genre.Pop, true, 2000);
            Song virginia = new Song("Virginia", "Clipse", Genre.Hip_Hop, false, 2002);
            Song gimmeShelter = new Song("Gimme Shelter", "Rolling Stones", Genre.Rock, false, 1969);

            Song[] songArr = { nyState, aHouse, onceInALifeTime, iCouldHave, idiotWind, pourOut, lucky, virginia, gimmeShelter };

            foreach(Song song in songArr)
            {
                AddSongToList(song);
            }

        }

}
