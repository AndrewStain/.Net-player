using System;
using System.Windows.Forms;

namespace mp3_player
{
    internal partial class Filters : Form
    {
        private Playlist playlist;

        public delegate string ShownStr(PlaylistItem item);

        public class FilterWrapper
        {

            public PlaylistItem Item { get; set; }
            public ShownStr Functor { get; set; }

            public FilterWrapper(PlaylistItem item, ShownStr functor)
            {
                Item = item;
                Functor = functor;
            }

            public override string ToString()
            {
                return Functor( Item );
            }
        }

        public Filters( Form1.Filter filter, Playlist _playlist )
        {
            playlist = _playlist;
            InitializeComponent();
            switch(filter)
            {
                case Form1.Filter.Artist:
                    this.Text = "Filter for Artist";
                    label1.Text = "Select artist:";
                    foreach (var item in playlist)
                    {
                        if (!listBox1.Items.Contains(item.Value.File.Artist))
                            listBox1.Items.Add(item.Value.File.Artist);
                    }
                    break;
                case Form1.Filter.Genre:
                    this.Text = "Filter for Genre";
                    label1.Text = "Select genre:";
                    foreach (var item in playlist)
                    {
                        if (!listBox1.Items.Contains(item.Value.File.Genres))
                            listBox1.Items.Add(item.Value.File.Genres);
                    }
                    break;
                case Form1.Filter.Year:
                    this.Text = "Filter for Year";
                    label1.Text = "Select year:";
                    foreach (var item in playlist)
                    {
                        if (!listBox1.Items.Contains(item.Value.File.Year))
                            listBox1.Items.Add(item.Value.File.Year);
                    }
                    break;
                default:
                    break;
            }
        }
        
        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }
        
        public string getSelectedFilter()
        {
            if (listBox1.SelectedItem != null)
                return listBox1.SelectedItem as string;
            else
                return "";
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }
        
    }
}
