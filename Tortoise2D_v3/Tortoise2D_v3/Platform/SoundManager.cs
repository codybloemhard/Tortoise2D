using System;
using System.Collections.Generic;

namespace Tortoise2D_v3.Platform
{
    public class SoundManager
    {
        public readonly int size;
        private int count;
        private Sound[] sounds;
        private string[] names;
        private Sound empty;

        public SoundManager(int size)
        {
            this.size = size;
            sounds = new Sound[size];
            names = new string[size];
            empty = new Sound("assets/Load.wav");
        }

        public int GetCount()
        {
            return count;
        }

        public void AddSound(string name, Sound s)
        {
            sounds[count] = s;
            names[count++] = name;
        }
        public void SetSound(int index, string name, Sound s)
        {
            sounds[index] = s;
            names[index] = name;
        }
        public void AddSound(string path, string name)
        {
            sounds[count] = new Sound(path);
            names[count++] = name;
        }
        public void SetSound(int index, string path, string name)
        {
            sounds[index] = new Sound(path);
            names[index] = name;
        }

        public Sound GetSound(int index)
        {
            return sounds[index];
        }
        public Sound GetSound(string name)
        {
            for(int i = 0; i < count; i++)
            {
                if (name == names[i])
                    return sounds[i];
            }
            return empty;
        }

        public void PlaySound(int index)
        {
            sounds[index].Play();
        }
        public void PlayLoopSound(int index)
        {
            sounds[index].PlayLoop();
        }
        public void StopSound(int index)
        {
            sounds[index].Stop();
        }
        public void PlaySound(string name)
        {
            for (int i = 0; i < count; i++)
            {
                if (name == names[i])
                {
                    sounds[i].Play();
                    return;
                }
            }
        }
        public void PlayLoopSound(string name)
        {
            for (int i = 0; i < count; i++)
            {
                if (name == names[i])
                {
                    sounds[i].PlayLoop();
                    return;
                }
            }
        }
        public void StopSound(string name)
        {
            for (int i = 0; i < count; i++)
            {
                if (name == names[i])
                {
                    sounds[i].Stop();
                    return;
                }
            }
        }
    }
}