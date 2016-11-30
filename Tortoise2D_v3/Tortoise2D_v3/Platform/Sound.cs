using System;
using System.Media;

namespace Tortoise2D_v3.Platform
{
    public class Sound
    {
        private SoundPlayer thissound;
        private string file;

        public Sound(string file)
        {
            thissound = new SoundPlayer(file);
            thissound.Load();
            this.file = file;
        }

        public void Play()
        {
            thissound.Play();
        }
        public void PlayLoop()
        {
            thissound.PlayLooping();
        }
        public void Stop()
        {
            thissound.Stop();
        }
    }
}
