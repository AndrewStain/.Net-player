using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;
using System.Windows.Media;

namespace mp3_player
{
    [Serializable]
    public class PlaylistItem
    {
        public string FilePath { get; private set; }
        [NonSerialized]
        private AudioFile file;
        public AudioFile File
        {
            get
            {
                if (file == null)
                    file = new AudioFile(FilePath);
                return file;
            }
        }
        public int Number { get; set; }

        public PlaylistItem()
        {
            FilePath = string.Empty;
            Number = -1;
        }
        public PlaylistItem( string filePath, int number )
        {
            FilePath = filePath;
            Number = number;
        }
        
        public override string ToString()
        {
            return Number.ToString() + ". " + File.Artist + " - " + File.Title;
        }
    }
}
