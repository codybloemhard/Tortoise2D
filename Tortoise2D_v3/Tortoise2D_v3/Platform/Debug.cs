using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tortoise2D_v3.Platform
{
    public class Debug
    {
        public static bool DEBUG = false;
        internal static bool ENGINE_DEBUG = false;

        public static void Print(string s)
        {
            if (!DEBUG)
                return;
            Console.WriteLine(s);
        }

        internal static void PrintEngine(string s)
        {
            if (!ENGINE_DEBUG)
                return;
            Console.WriteLine("#T2D-- " + s);
        }
    }
}
