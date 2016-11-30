using System;
using Tortoise2D_v3.Render;
using Tortoise2D_v3.Platform;
using Tortoise2D_v3.Math;

namespace Tortoise2D_v3
{
    public class Program
    {
        private Tortoise2d g;
        private Renderable spr;
        private int i = 0;

        public Program()
        {
            g = new Tortoise2d("Test", 1920, 1080, 16, 9, 1000, 10);
            g.SetGameFunctions(Load, Init, Update, Render);
            g.Run(60, 60);
        }

        static void Main(string[] args)
        {
            Program p = new Program();
        }

        public void Load()
        {
            g.layers.AddLayer("canvas", g.renderer.GenLayer(1920 / 1, 1080 / 1));
            g.textures.AddSprite("assets/smile_red.png", "smilered");
        }
        public void Init()
        {
            spr = new Renderable(g, "smilered");
            spr.SetTransform(3, 3, 1, 1);
            spr.EnableMatrix(true);
            spr.SetRotation(45);
        }
        public void Update()
        {
            i++;
            spr.Rotate(1);
            spr.SetTransform(g.input.GetMouseXGrid(), g.input.GetMouseYGrid(), 1, 1);
            //g.camera.SetPositionCenter(1.5f, 1.5f);
            g.input.lockMouse(false);
            if (i > 60)
            {
                Debug.Print("FPS: " + References.fps.GetFPS());
                i = 0;
            }
        }
        public void Render()
        {
            g.renderer.NewLayer(true);
            g.renderer.BindTexture(g.textures.GetRawTexture("sprites"));

            spr.Render();

            g.renderer.Render_SceneToLayer(g.layers.GetLayer("canvas"));
            g.renderer.RenderLayer(g.layers.GetLayer("canvas"));
        }
    }
}