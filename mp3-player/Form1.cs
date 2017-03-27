using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace mp3_player
{
    public partial class Form1 : Form
    {
        public enum Filter { Artist, Genre, Year };

        private Player player = new Player();
        private Timer timer = new Timer();
        private Timer timerUpdatePlaylist = new Timer();
        private string selectFolder;
        private bool Random { get; set; }
        private Playlist fullPlaylist = new Playlist();
        

        public Form1()
        {
            InitializeComponent();

            if ( !File.Exists("config.xml"))
            {
                Settings settings;
                try
                {
                    settings = Settings.FromFile("config.xml");
                    selectFolder = settings.FolderPath;
                    LoadList(settings.FolderPath);
                    player.Volume = settings.Volume;
                    trackBarVolume.Value = settings.Volume;
                    listBoxPlaylist.SelectedIndex = settings.CurrentSong;
                    PlaySelectedItem();
                    player.PositionDouble = settings.Position;
                    player.Pause();
                }
                catch
                {}
            }

            buttonPlayPause.Image = player.Image;
            buttonStop.Image = Properties.Resources.stop;
            buttonPrewSound.Image = Properties.Resources.prew;
            buttonNextSound.Image = Properties.Resources.next;
            buttonBrowse.Image = Properties.Resources.browse;
            buttonSave.Image = Properties.Resources.save;
            buttonLoad.Image = Properties.Resources.load;
            buttonRandom.Image = Properties.Resources.randOff;
            buttonMute.Image = Properties.Resources.soundOn;

            toolTip.SetToolTip(labelSelectedFilters, "Not selected");
            
            timer.Interval = 1000;
            timerUpdatePlaylist.Interval = 300000;
            timerUpdatePlaylist.Tick += UpdatePlaylist;
            timer.Tick += UpdateContext;
        }

        private void UpdatePlaylist(object sender, EventArgs args)
        {
            string[] files = Directory.GetFiles(selectFolder, "*.mp3", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                if (!fullPlaylist.ContainsKey(file))
                {
                    fullPlaylist.Add(file, new PlaylistItem(file, fullPlaylist.Count + 1));
                    listBoxPlaylist.Items.Add(fullPlaylist[file]);
                }
            }
               
        }

        private void UpdateContext(object sender, EventArgs args)
        {
            labelDuration.Text = player.PositionString + " / " + player.Duration.ToString("mm\\:ss");
            if ( player.Volume != 0 )
                buttonMute.Image = Properties.Resources.soundOff;
           if ( trackBarSound.Value == trackBarSound.Maximum )
                NextTrack();

            trackBarSound.Value = (int)Math.Ceiling( trackBarSound.Maximum * player.PositionDouble / player.Duration.TotalSeconds );
        }

        void LoadList(string path)
        {
            if ( !Directory.Exists(path) )
            {
                MessageBox.Show("Path not exist");
                return;
            }

            string[] files = Directory.GetFiles(@path, "*.mp3",SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                MessageBox.Show("Folder not select!");
                return;
            }

            try
            {
                foreach (string file in files)
                    fullPlaylist.Add(file, new PlaylistItem(file, fullPlaylist.Count + 1));
            }
            catch { }

            PlaylistItem[] items = new PlaylistItem[fullPlaylist.Values.Count];
            fullPlaylist.Values.CopyTo(items, 0);
            
            listBoxPlaylist.Items.AddRange(items);
        }

        void PlaySelectedItem()
        {
            try
            {
                if (listBoxPlaylist.SelectedItem == null)
                    listBoxPlaylist.SelectedIndex = 0;
            }
            catch { }

            PlaylistItem item = (PlaylistItem)listBoxPlaylist.SelectedItem;
            if (item == null)
                return;
            
            if (player.CurrentFile != item.File)
                player.CurrentFile = item.File;

            player.Switch();

            if (player.PlayState == Player.State.Play)
                timer.Start();
            else
                timer.Stop();

            if (player.PlayState != Player.State.Stop)
                buttonPlayPause.Image = player.Image;
        }


        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            PlaySelectedItem();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                LoadList(fbd.SelectedPath);
                selectFolder = fbd.SelectedPath;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            player.Stop();
            timer.Stop();
            trackBarSound.Value = 0;
            labelDuration.Text = "00:00 / " + player.Duration.ToString("mm\\:ss");
            buttonPlayPause.Image = player.Image;
        }

        private void buttonPrewSound_Click(object sender, EventArgs e)
        {
            if (listBoxPlaylist.SelectedIndex != 0)
            {
                player.Stop();
                listBoxPlaylist.SelectedIndex--;
                PlaySelectedItem();
            }
        }

        private void RandomTrack()
        {
            System.Random random = new Random();
            listBoxPlaylist.SelectedIndex = random.Next(listBoxPlaylist.Items.Count);
            player.Stop();
            PlaySelectedItem();
            return;
        }

        private void NextTrack()
        {
            if (Random)
                RandomTrack();

            if (listBoxPlaylist.SelectedIndex < (listBoxPlaylist.Items.Count - 1))
                listBoxPlaylist.SelectedIndex++;
            else
                listBoxPlaylist.SelectedIndex = 0;
            player.Stop();
            PlaySelectedItem();
        }

        private void buttonNextSound_Click(object sender, EventArgs e)
        {
            NextTrack();
        }

        private void DeleteSelectedItem()
        {
            if (listBoxPlaylist.SelectedIndex == -1)
                return;
            try
            {
                listBoxPlaylist.Items.RemoveAt(listBoxPlaylist.SelectedIndex);
                for (int i = 0; i < listBoxPlaylist.Items.Count; ++i)
                {
                    ((PlaylistItem)listBoxPlaylist.Items[i]).Number = i + 1;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonMute_Click(object sender, EventArgs e)
        {
            if (player.IsMute)
            {
                player.Volume = trackBarVolume.Value;
                buttonMute.Image = Properties.Resources.soundOn;
            }
            else
            {
                player.Volume = 0;
                buttonMute.Image = Properties.Resources.soundOff;
            }

        }

        private void buttonFilters_Click(object sender, EventArgs e)
        {
            MenuItem artist = new MenuItem("Artist");
            MenuItem genre = new MenuItem("Genre");
            MenuItem year = new MenuItem("Year");
            MenuItem reset = new MenuItem("Reset");

            reset.Click += (object s, EventArgs ev) =>
            {
                listBoxPlaylist.Items.Clear();
                PlaylistItem[] items = new PlaylistItem[fullPlaylist.Values.Count];
                fullPlaylist.Values.CopyTo(items, 0);
                listBoxPlaylist.Items.AddRange(items);
                labelSelectedFilters.Text = "Selected Filters: not selected";
                toolTip.SetToolTip(labelSelectedFilters, "Not selected");
            };

            genre.Click += (object s, EventArgs ev) => 
            {
                if (fullPlaylist.Count != 0)
                {
                    Playlist pl = new Playlist();
                    for (int i = 0; i < listBoxPlaylist.Items.Count; ++i)
                    {
                        PlaylistItem item = (PlaylistItem)listBoxPlaylist.Items[i];
                        pl.Add(item.FilePath, item);
                    }

                    Filters f = new Filters(Filter.Genre, pl);
                    f.ShowDialog();
                    if (f.DialogResult == DialogResult.OK)
                    {
                        string filter = f.getSelectedFilter();
                        if (filter == " ")
                            return;
                        for (int i = 0; i < listBoxPlaylist.Items.Count; ++i)
                        {
                            PlaylistItem item = (PlaylistItem)listBoxPlaylist.Items[i];
                            if (item.File.Genres != filter)
                            {
                                listBoxPlaylist.Items.RemoveAt(i);
                                --i;
                            }
                        }

                        if (labelSelectedFilters.Text == "Selected Filters: not selected")
                            labelSelectedFilters.Text = "Selected Filters: Genre";
                        else
                            labelSelectedFilters.Text += ", Genre";

                        if (toolTip.GetToolTip(labelSelectedFilters) == "Not selected")
                            toolTip.SetToolTip(labelSelectedFilters, "Genre: " + filter);
                        else
                        {
                            string str = toolTip.GetToolTip(labelSelectedFilters);
                            toolTip.SetToolTip(labelSelectedFilters, str + ", Genre: " + filter );
                        }
                    }
                }
                else
                    MessageBox.Show("Playlist is empty!", "Warning");
            };

            artist.Click += (object s, EventArgs ev) =>
            {
                if (fullPlaylist.Count != 0)
                {
                    Playlist pl = new Playlist();
                    for (int i = 0; i < listBoxPlaylist.Items.Count; ++i)
                    {
                        PlaylistItem item = (PlaylistItem)listBoxPlaylist.Items[i];
                        pl.Add(item.FilePath, item);
                    }

                    Filters f = new Filters(Filter.Artist, pl);
                    f.ShowDialog();
                    if (f.DialogResult == DialogResult.OK)
                    {
                        string filter = f.getSelectedFilter();
                        if (filter == " ")
                            return;
                        for ( int i = 0; i < listBoxPlaylist.Items.Count; ++i )
                        {
                            PlaylistItem item = (PlaylistItem)listBoxPlaylist.Items[i];
                            if (item.File.Artist != filter)
                            {
                                listBoxPlaylist.Items.RemoveAt(i);
                                --i;
                            }
                        }

                        if (labelSelectedFilters.Text == "Selected Filters: not selected")
                            labelSelectedFilters.Text = "Selected Filters: Artist";
                        else
                            labelSelectedFilters.Text += ", Artist";

                        if (toolTip.GetToolTip(labelSelectedFilters) == "Not selected")
                            toolTip.SetToolTip(labelSelectedFilters, "Artist: " + filter);
                        else
                        {
                            string str = toolTip.GetToolTip(labelSelectedFilters);
                            toolTip.SetToolTip(labelSelectedFilters, str + ", Artist: " + filter);
                        }
                    }
                }
                else
                    MessageBox.Show("Playlist is empty!", "Warning");
            };

            year.Click += (object s, EventArgs ev) =>
            {
                if (fullPlaylist.Count != 0)
                {
                    Playlist pl = new Playlist();
                    for (int i = 0; i < listBoxPlaylist.Items.Count; ++i)
                    {
                        PlaylistItem item = (PlaylistItem)listBoxPlaylist.Items[i];
                        pl.Add(item.FilePath, item);
                    }

                    Filters f = new Filters(Filter.Year, pl);
                    f.ShowDialog();
                    if (f.DialogResult == DialogResult.OK)
                    {
                        string filter = f.getSelectedFilter();
                        if (filter == " ")
                            return;
                        for (int i = 0; i < listBoxPlaylist.Items.Count; ++i)
                        {
                            PlaylistItem item = (PlaylistItem)listBoxPlaylist.Items[i];
                            if (item.File.Year != filter)
                            {
                                listBoxPlaylist.Items.RemoveAt(i);
                                --i;
                            }
                        }

                        if (labelSelectedFilters.Text == "Selected Filters: not selected")
                            labelSelectedFilters.Text = "Selected Filters: Year";
                        else
                            labelSelectedFilters.Text += ", Year";

                        if (toolTip.GetToolTip(labelSelectedFilters) == "Not selected")
                            toolTip.SetToolTip(labelSelectedFilters, "Year: " + filter);
                        else
                        {
                            string str = toolTip.GetToolTip(labelSelectedFilters);
                            toolTip.SetToolTip(labelSelectedFilters, str + ", Year: " + filter);
                        }
                    }
                }
                else
                    MessageBox.Show("Playlist is empty!", "Warning");
            };
            ContextMenu contextMenu = new ContextMenu(new MenuItem[] { artist, genre, year, reset });
            contextMenu.Show(buttonFilters, new Point());
        }

        private void listBoxPlaylist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteSelectedItem();
        }

        private void listBoxPlaylist_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                listBoxPlaylist.SelectedIndex = listBoxPlaylist.IndexFromPoint(e.Location);

                MenuItem play = new MenuItem("Play");
                MenuItem delete = new MenuItem("Delete");
                MenuItem info = new MenuItem("Info");

                info.Click += (object s, EventArgs ev) => {
                    PlaylistItem item = (PlaylistItem)listBoxPlaylist.SelectedItem;
                    if (item == null)
                        return;
                    new AboutAudio(item.FilePath).Show();
                };

                play.Click += (object s, EventArgs ev) =>
                {
                    PlaySelectedItem();
                };

                delete.Click += (object s, EventArgs ev) =>
                {
                    DeleteSelectedItem();
                };

                ContextMenu contextMenu = new ContextMenu(new MenuItem[] { play, delete, info });
                contextMenu.Show(listBoxPlaylist, e.Location);
            }

        }
        

        private void listBoxPlaylist_DoubleClick(object sender, EventArgs e)
        {
            PlaylistItem item = (PlaylistItem)listBoxPlaylist.SelectedItem;
            if (item == null)
                return;

            player.CurrentFile = item.File;
            player.Play();
            timer.Start();

            if (player.PlayState != Player.State.Stop)
                buttonPlayPause.Image = player.Image;
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            Random = !Random;
            if (Random)
                buttonRandom.Image = Properties.Resources.randOn;
            else
                buttonRandom.Image = Properties.Resources.randOff;
        }

        private void trackBarSound_MouseUp(object sender, MouseEventArgs e)
        {
            try
            { player.PositionDouble = player.Duration.TotalSeconds * trackBarSound.Value / trackBarSound.Maximum; }
            catch { }
            
        }

        private void trackBarVolume_ValueChanged(object sender, EventArgs e)
        {
            player.Volume = trackBarVolume.Value;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Playlist Files (.pl)|*.pl|All Files (*.*)|*.*";
            dialog.FilterIndex = 0;
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                if (!fullPlaylist.Save(dialog.FileName))
                    MessageBox.Show("Save playlist error");
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Playlist Files (.pl)|*.pl|All Files (*.*)|*.*";
            dialog.FilterIndex = 0;
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                Playlist pl = Playlist.FromFile(dialog.FileName);
                if ( pl != null )
                {
                    foreach (var item in pl)
                    {
                        if( !fullPlaylist.ContainsKey(item.Key) )
                            fullPlaylist.Add(item.Key, item.Value);
                    }
                    
                    PlaylistItem[] items = new PlaylistItem[fullPlaylist.Values.Count];
                    fullPlaylist.Values.CopyTo(items, 0);
                    listBoxPlaylist.Items.AddRange(items);
                }
                else
                    MessageBox.Show("Load playlist error");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("config.xml");
            new Settings(selectFolder, trackBarVolume.Value,
                player.PositionDouble, listBoxPlaylist.SelectedIndex).Save("config.xml");
        }
    }
}


