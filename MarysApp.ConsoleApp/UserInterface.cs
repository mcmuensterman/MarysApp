using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarysApp.Repository;

namespace MarysApp.ConsoleApp
{
    public class UserInterface
    {
    //design a CREATE, READ ALL, and READ method
        MarysAppRepository _marysRepo = new MarysAppRepository();
        bool isRunning = true;

        public void Run()
        {
            _marysRepo.SeedSongData();

            while (isRunning)
            {
                PrintMenu();

                string input = GetUserInput();

                UserInputSwitchCase(input);
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("\n1. Add Song to Playlist\n" +
                    "2. View All Songs\n" +
                    "3. Get One Song\n" +
                    "4. Exit\n"
                    );

            Console.WriteLine("Enter Your Choice: ");
        }

        private string GetUserInput()
        {
            return Console.ReadLine();
        }

        private void UserInputSwitchCase(string input)
        {
            switch(input)
            {
                case "1":
                CreateSong();
                    break;
                case "2":
                ViewAllSongs();
                    break;
                case "3":
                ViewOneSong();
                    break;
                case "4":
                    isRunning = false;
                Exit();
                    break;

                default:
                    break;
            }
        }

        private void CreateSong()
        {
            Console.WriteLine("Add a new song");

            Console.Write("\nTitle: ");
            string title = GetUserInput();

            Console.Write("\nArtist: ");
            string artist = GetUserInput();

            Console.Write("\nGenre:\n" + 
                    "1. Pop\n" +
                    "2. Hip Hop\n" +
                    "2. Country\n" +
                    "4. Electronica\n" +
                    "5. Oldies\n" +
                    "6. Rock\n"
            );

            Console.Write("\nSelect Genre: ");
            string genreSelection = GetUserInput();

            Genre genre = Genre.Pop;

            switch (genreSelection)
            {
                case "1":
                    genre = Genre.Pop;
                    break;
                case "2":
                    genre = Genre.Hip_Hop;
                    break;
                case "3":
                    genre = Genre.Country;
                    break;
                case "4":
                    genre = Genre.Electronica;
                    break;
                case "5":
                    genre = Genre.Oldies;
                    break;
                case "6":
                    genre = Genre.Rock;
                    break;
                default:
                    break;
            }

            Console.Write("\nIs This is a Happy Song? Select one: \n" +
                    "1. yes\n" +
                    "2. no\n" 
                    );

            string happySong = GetUserInput();
            
            bool isHappy = false;

            switch(happySong)
            {
                case "1":
                    isHappy = true;
                    break;
                case "2":
                    isHappy = false;
                    break;
                default:
                    break;
            }

            Console.Write("Year Released: ");
            int releaseYear = Convert.ToInt32(Console.ReadLine());

            Song newSong = new Song(title, artist, genre, isHappy, releaseYear);

            _marysRepo.AddSongToList(newSong);
        }

        private void GetASong(Song song)
        {
            Console.WriteLine($"\n{song.Title}\n" + 
                    $"Artist: {song.Artist}\n" +
                    $"Year: {song.ReleaseYear}\n" +
                    $"Genre: {song.Genre}\n" +
                    $"Recommended for a rainy day: {song.IsHappy}\n"
                    );
        }

        private void ViewAllSongs()
        {
            List<Song> allSongs = _marysRepo.GetAllSongs();

            foreach (Song song in allSongs)
            {
                GetASong(song);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void ViewOneSong()
        {
            Console.Write("Enter a song title: ");
            string title = GetUserInput();

            Song song = _marysRepo.GetSongByTitle(title);

            if (song != null)
            {
                GetASong(song);
                Console.WriteLine("\nPress any key to continue.");
            }
            else
            {
                Console.WriteLine("We couldn't find that song. Press any key to continue.");
            }

            Console.ReadKey();
        }

        public void Exit()
        {
            Console.WriteLine("Later Gator :)");
        }



    }
    
}