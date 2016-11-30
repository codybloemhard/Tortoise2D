using System;

namespace Tortoise2D_v3.Platform
{
    public class FPS
    {
        private Timer timer = new Timer();
        private int nFrames = 0;
        private double time = 0;
        private double getFPS = 0;

        public void Update()
        {
            nFrames++;
            time += timer.GetElapsedTime();
            if (time > 1)
            {
                getFPS = (double)nFrames / time;
                time = 0;
                nFrames = 0;
            }
        }

        public double GetFPS()
        {
            return getFPS;
        }
    }
}
