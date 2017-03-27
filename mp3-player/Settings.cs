using System;
using System.IO;
using System.Xml.Serialization;

namespace mp3_player
{
    [Serializable]
    public class Settings
    {
        public string FolderPath { get; set; }
        public int Volume { get; set; }
        public double Position { get; set; }
        public int CurrentSong { get; set; }

        public Settings()
        {
            FolderPath = string.Empty;
            Volume = 50;
            Position = 0;
            CurrentSong = 0;
        }

        public Settings( string _path, int _volume, double _position, int _currentSong)
        {
            FolderPath = _path;
            Volume = _volume;
            Position = _position;
            CurrentSong = _currentSong;
        }

        #region XML
        public void Save(string sFileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Settings));
            
            using (FileStream fs = new FileStream(sFileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
            
        }

        public static Settings FromFile(string sFileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Settings));

            using (FileStream fs = new FileStream(sFileName, FileMode.Open))
            {
                return (Settings)formatter.Deserialize(fs);
            }

        }
        #endregion
    }


}
