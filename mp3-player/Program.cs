using System;
using System.Windows.Forms;


namespace mp3_player
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            #region Check Settings
            //Settings settings = new Settings();
            //settings.CurrentSong = 3;
            //settings.FolderPath = "D:\\test";
            //settings.Position = 20;
            //settings.Volume = 30;
            //settings.Save("test.xml");

            //Settings restoredSettings = Settings.FromFile("test.xml");
            //Console.Write("Check current song: ");
            //Check(settings.CurrentSong == restoredSettings.CurrentSong);
            //Console.Write("Check folder path: ");
            //Check(settings.FolderPath == restoredSettings.FolderPath);
            //Console.Write("Check position: ");
            //Check(settings.Position == settings.Position);
            //Console.Write("Check volume: ");
            //Check(settings.Volume == settings.Volume);
            #endregion
        }

        static void Check( bool ext )
        {
            if (!ext)
                Console.WriteLine("error");
            else
                Console.WriteLine("true");
        }
    }
}
