using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tortoise2D_v3.Platform
{
    public class Timer
    {
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32")]
        private static extern bool QueryPerformanceFrequency(ref long PerformanceFrequency);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32")]
        private static extern bool QueryPerformanceCounter(ref long PerformanceCount);

        private long _ticksPerSecond = 0;
        private long _previousElapsedTime = 0;

        public Timer()
        {
            QueryPerformanceFrequency(ref _ticksPerSecond);
            GetElapsedTime();
        }

        public double GetElapsedTime()
        {
            long time = 0;
            QueryPerformanceCounter(ref time);

            double elapsedTime = (double)(time - _previousElapsedTime) / (double)_ticksPerSecond;
            _previousElapsedTime = time;

            return elapsedTime;
        }
    }
}
