using MusicBox.Exceptions;
namespace MusicBox.Moduls
{
    internal class Playlist
    {
        public List<Music> _playlist;

        private List<Music> recentlyMusic;

        private Music currentMusic;

        public Playlist()
        {
            _playlist = new List<Music>();
            recentlyMusic = new List<Music>();
        }

        public void AddMusic(Music music)
        {
            if (_playlist.Contains(music))
            {
                Console.WriteLine("This song is already available in the playlist");
            }
            else
            {
                _playlist.Add(music);
                Console.WriteLine("Music added to Playlist");
            }
        }

        public Music Play(Music music)
        {
            if (!_playlist.Contains(music))
            {
                Console.WriteLine("This music isn't in your playlist. Do you want add this music to your playlist ? (H / Y)");
                if (CheckInput())
                {
                    _playlist.Add(music);
                }
            }
            if (currentMusic == null)
            {
                currentMusic = music;
            }
            else if (currentMusic == music)
            {
                return currentMusic;
            }
            else if (currentMusic.CurrentTime < currentMusic.Time)
            {
                Console.WriteLine("This music hasn't finished yet. Do you want change music ? (H / Y)");
                if (CheckInput())
                {
                    currentMusic = music;
                }
            }
            recentlyMusic.Insert(0, currentMusic);
            return currentMusic;
        }

        public bool ShowPlaylist()
        {
            Console.WriteLine("|----------------   Musics On Playlist   ----------------|");
            if (_playlist.Count != 0)
            {
                foreach (Music music in _playlist)
                {
                    Console.WriteLine($"{music.Id}){music.Name}");
                }
                return true;
            }
            else
            {
                Console.WriteLine("Playlist is empty");
                return false;
            }
        }

        public bool RecentlyPlayedMusic()
        {
            Console.WriteLine("|----------------   Recently Played Music   ----------------|");
            if (recentlyMusic.Count != 0)
            {
                foreach (Music music in recentlyMusic)
                {
                    Console.WriteLine($"{music.Id}){music.Name}");
                }
                return true;
            }
            else
            {
                Console.WriteLine("You didn't listen any music");
                return false;
            }
        }

        bool CheckInput()
        {
            bool repeat = true;
            string answer = "";
            while (repeat)
            {
                repeat = false;
                Console.Write("Answer : ");
                answer = Console.ReadLine();
                try
                {
                    if (answer.ToUpper() != "H" && answer.ToUpper() != "Y")
                    {
                        throw new WrongCommandException();
                    }
                }
                catch (WrongCommandException ex)
                {
                    Console.WriteLine(ex.Message);
                    repeat = true;
                }
            }
            if (answer.ToLower() == "h")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}

