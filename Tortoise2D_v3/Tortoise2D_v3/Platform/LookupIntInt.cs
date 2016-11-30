using System;

namespace Tortoise2D_v3.Platform
{
    public class LookupIntInt
    {
        private int[] ids;
        private int[] vals;

        private int size = 0, count = 0;
        public LookupIntInt(int size)
        {
            this.size = size;
            ids = new int[size];
            vals = new int[size];
        }

        public void AddEntry(int name, int value)
        {
            if (count <= size)
            {
                ids[count] = name;
                vals[count] = value;
                count++;
            }
        }

        public int GetEntry(int name)
        {
            int found = -1;

            for (int i = 0; i < count; i++)
            {
                if (ids[i] == name)
                {
                    found = vals[i];
                    break;
                }
            }
            return found;
        }

        public bool HasEntry(int name)
        {
            bool found = false;

            for (int i = 0; i < count; i++)
            {
                if (ids[i] == name)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
    }
}
