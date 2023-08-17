namespace MusicBox.Moduls
{
    internal class Music
    {

        private string _name;
        private string _artistName;
        private int _time;
        private int _id;
        private static int _count = 1;
       

        public int Id 
        {
            get=>_id;
            set
            {
                if (value > 0)
                {
                    _id = value;
                }
            }
        }


        public string Name 
        { 
            get=>_name;
            set
            {
                if (value.Trim().Length>0 && value!=null)
                {
                    _name = value.Trim();
                }
            }
        }


        public string ArtistName 
        { 
            get=>_artistName;
            set
            {
                if (value.Trim().Length>0 && value!=null)
                {
                    _artistName = value.Trim();
                }
            }
        }


        public int Time 
        { 
            get=>_time;
            set
            {
                if (value>=30)
                {
                    _time = value;
                }
            }
        }


        public int CurrentTime { get; set; } = 0;


        public Music(string name, string artistName, int time)
        {
            Name = name;
            ArtistName = artistName;
            Time = time;

            Id = _count;
            _count++;
        }


        
    }
}
