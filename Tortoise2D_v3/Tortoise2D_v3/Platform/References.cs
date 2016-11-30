using System;
using Tortoise2D_v3.Render;
using Tortoise2D_v3.Math;

namespace Tortoise2D_v3.Platform
{
    public class References
    {
        public const string author = "Tortoise2D (v3) is an 2D game engine made by Cody Bloemhard in 2016 with visual studio in C#.NET and OpenGL 4.x. (OpentTK)";
        public static Tortoise2d game;

        public static FPS fps;
        public static Renderer renderer;
        public static PCInput input;
        public static TextureManager textures;
        public static LayerManager layers;
        internal static GameStateManager states;
        public static Grid grid;
        public static Camera camera;
        public static SoundManager sound;

        public static Math.Matrix2 matrix;
        public static Random random;
    }
}
