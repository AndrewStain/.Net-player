using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using TagLib;

namespace mp3_player
{
    public class AudioFile
    {
        private TagLib.File audioFile;
        private Image image;

        public AudioFile( string sFileName )
        {
            audioFile = TagLib.File.Create(sFileName);
            image = Properties.Resources.CoverNotFound;
        }

        public string Path
        {
            get { return audioFile.Name; }
        }

        public string Album
        {
           get { return audioFile.Tag.Album; }
        }

        public string Artist
        {
            get
            {
                if (audioFile.Tag.Artists.Length > 0)
                    return audioFile.Tag.Artists[0];
                return "";
            }
        }

        public string Bitrate
        {
            get { return audioFile.Properties.AudioBitrate.ToString(); }
        }

        public string Name
        {
            get { return audioFile.Name; }
        }

        public string Title
        {
            get { return audioFile.Tag.Title; }
        }

        public string Year
        {
            get { return audioFile.Tag.Year.ToString(); }
        }

        public Image Picture
        {
            get
            {
                if (audioFile.Tag.Pictures.Length >= 1)
                {
                    var bin = (byte[])(audioFile.Tag.Pictures[0].Data.Data);
                    return Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(100, 100, null, IntPtr.Zero);
                }
                return image;
            }
        }

        public TimeSpan Duration
        {
            get { return audioFile.Properties.Duration; }
        }

        public string Genres
        {
            get {
                if( audioFile.Tag.Genres.Length > 0)
                    return audioFile.Tag.Genres[0].ToString();
                return "";
            }
        }
    }
}
