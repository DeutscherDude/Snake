using System;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;

namespace Snake
{
    class MusicPlayer
    {
        private SoundPlayer Player = new SoundPlayer();

        public MusicPlayer()
        {
            this.Player = new SoundPlayer();
        }


        public void readMusic()
        {
            LoadMusicAsync();
        }

        public void pauseMusic(bool isPlaying)
        {
            if (isPlaying == true)
            {
                Player.Stop();
            }
            else
            {
                Player.Play();
            }
        }

        public void dispose()
        {
            Player.Dispose();
        }

        private void LoadMusicAsync()
        {
            try
            {
                this.Player.SoundLocation = "Y2Mate.is - Rick Astley - Never Gonna Give You Up (Video)-dQw4w9WgXcQ-160k-1621724339831.wav";
                this.Player.LoadAsync();
                this.Player.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageConsole.LogMessage("Experienced error whilst loading sounds/music");
            }
        }

        public void LoadDeathSoundAsync()
        {
            this.Player.SoundLocation = "yt1s.com - Lego yoda death sound.wav";
            this.Player.Load();
            this.Player.Play();
        }


    }
}
