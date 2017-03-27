using System;
using System.Drawing;
using System.Windows.Media;

namespace mp3_player
{
    public class Player
    {
        
        private MediaPlayer media = new MediaPlayer();

        private AudioFile currentFile;

        public AudioFile CurrentFile
        {
            get { return currentFile; }
            set
            {
                currentFile = value;
                if(currentFile != null)
                    media.Open(new Uri(@currentFile.Path));
            }
        }

        public enum State { Play, Pause, Stop }
        public State PlayState { get; private set; }

        public TimeSpan ConvertTime( double second )
        {
            return new TimeSpan();
        }

        public TimeSpan Position
        {
            get { return media.Position; }
        }

        public double PositionDouble
        {
            get { return media.Position.TotalSeconds; }
            set { media.Position = TimeSpan.FromSeconds(value); }
        }

        public string PositionString
        {
            get { return media.Position.ToString("mm\\:ss"); }
        }


        public TimeSpan Duration
        {
            get
            {
                if (CurrentFile == null)
                    return new TimeSpan();
                return CurrentFile.Duration;
            }
        }

        public bool IsMute { get; private set; }

        public int Volume
        {
            get { return (int)media.Volume * 100; }
            set
            {
                media.Volume = value / 100.0;
                IsMute = (value == 0);
            }
        }

        public Image Image
        {
            get
            {
                switch (PlayState)
                {
                    case State.Play:
                        return Properties.Resources.pause;
                    case State.Pause:
                        return Properties.Resources.play;
                    case State.Stop:
                        break;
                    default:
                        return Properties.Resources.stop;
                }
                return Properties.Resources.play ;
            }
        }

        public Player(AudioFile audioFile = null)
        {
           PlayState = State.Stop;
        }
        
        public void Play()
        {
            media.Play();
            PlayState = State.Play;
        }

        public void Stop()
        {
            media.Stop();
            PlayState = State.Stop;
        }

        public void Pause()
        {
            media.Pause();
            PlayState = State.Pause;
        }

        public void Switch(  )
        {
            if (PlayState == State.Play)
            {
                Pause();
               // position = _position;
            }
            else
            {
              //  media.Position = position;
                Play();
            }
        }
    }
}
    