using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace mp3_player
{
    [Serializable]
    public class Playlist : Dictionary<string, PlaylistItem>//, ISerializable
    {

        public Playlist() : base() { }

        public Playlist(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo, contextArg) {}

        public bool Save( string fileName )
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                try
                {
                    binFormat.Serialize(fs, this);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static Playlist FromFile(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = File.OpenRead(fileName))
            {
                return (Playlist)new BinaryFormatter().Deserialize(fStream);
            }
        }
    }
}
