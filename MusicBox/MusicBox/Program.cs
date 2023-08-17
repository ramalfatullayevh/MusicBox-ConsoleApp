using MusicBox.Extensions;
using MusicBox.Moduls;

namespace MusicBox
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AllMusic = new List<Music>
        {
            new Music("Fallen Star","The Neighbourhood",223),
            new Music("Star Shopping","Lil Peep",150),
            new Music("You","Radiohead",217),
            new Music("About A Girl","Nirvana",165),
            new Music("Sextape","Deftones",241),
            new Music("Dreaming of You","Cigarettes After Sex",320),
            new Music("23","Chase Atlantic",276),
            new Music("A Little Death","The Neighbourhood",209),
            new Music("Consume","Chase Atlantic",277),
            new Music("Code Red","AC/DC",210),
        };
            Playlist playlist = new Playlist();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|----------------   User Menu   ----------------|");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" 1)Create Music \n 2)Musics on Playlist \n 3)Add Music to Playlist \n 4)Play Music from Playlist \n 5)Recently played Music \n 6)Exit");
            bool repeat = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|-----------------------------------------------|");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Your Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddMusic();
                        break;
                    case 2:
                        playlist.ShowPlaylist();
                        break;
                    case 3:
                        AddMusicToPlaylist(playlist);
                        break;
                    case 4:
                        PlayMusic(playlist);
                        break;
                    case 5:
                        playlist.RecentlyPlayedMusic();
                        break;
                    case 6:
                        repeat = true;
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;
                }
            } while (!repeat);


        }

        static List<Music> AllMusic { get; set; }

        public static void AddMusic()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Music Name : ");
            string musicName = Console.ReadLine();

            Console.Write("Artist Name : ");
            string artistName = Console.ReadLine();

            Console.Write("Music Time in Seconds : ");
            int time = Convert.ToInt32(Console.ReadLine());

            Music music = new Music(musicName, artistName, time);
            AllMusic.Add(music);
            Console.WriteLine("Music created");
        }

        public static void AddMusicToPlaylist(Playlist playlist)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|----------------   All Musics   ----------------|");
            foreach (Music msc in AllMusic)
            {
                Console.WriteLine($"{msc.Id}){msc.Name}");
            }
            Console.WriteLine("|------------------------------------------------|");
            int id = 0;
            while (id < 1 || id > AllMusic.Count)
            {
                Console.Write($"Choose music between 1 - {AllMusic.Count} : ");
                id = Convert.ToInt32(Console.ReadLine());
            }
            Music music = AllMusic[id - 1];
            playlist.AddMusic(music);
        }

        public static void PlayMusic(Playlist playlist)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (playlist.ShowPlaylist())
            {
                int id = 0;
                while (id < 1 || id > playlist._playlist.Count)
                {
                    Console.Write($"Choose music between 1 - {playlist._playlist.Count} : ");
                    id = Convert.ToInt32(Console.ReadLine());
                }
                Music currentMusic = playlist.Play(playlist._playlist[id - 1]);
                Console.WriteLine(CapitalizeExtension.Capitalize($"You are listening {currentMusic.Name} - {currentMusic.ArtistName}"));
            }
        }
    }
}
