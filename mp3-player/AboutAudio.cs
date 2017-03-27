using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;

namespace mp3_player
{
    public partial class AboutAudio : System.Windows.Forms.Form
    {

        public AboutAudio( string fileName )    
        {
            InitializeComponent();
            ActiveControl = textBoxTitle;
            AudioFile audio = new AudioFile(fileName);

            textBoxAlbum.Text = audio.Album;
            textBoxArtist.Text = audio.Artist;
            textBoxTitle.Text = audio.Title;
            textBoxYear.Text = audio.Year;
            textBoxGenre.Text = audio.Genres;
            pictureBoxCover.Image = audio.Picture;
        }
    }
}
