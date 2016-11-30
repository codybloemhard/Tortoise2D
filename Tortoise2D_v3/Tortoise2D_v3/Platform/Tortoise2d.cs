using System;
using OpenTK;

using Tortoise2D_v3.Math;
using Tortoise2D_v3.Render;

namespace Tortoise2D_v3.Platform
{
    public class Tortoise2d : GameWindow
    {
        public int WWidth = 1920;
        public int WHeight = 1080;
        public string WTitle = "Tortoise2D v3";
        public const string author = "Tortoise2D is a 2d game engine made by Cody Bloemhard";

        public Renderer renderer;
        public PCInput input;
        public TextureManager textures;
        public LayerManager layers;
        internal GameStateManager states;
        public Grid grid;
        public Camera camera;
        public SoundManager sound;
        public FPS fps;

        public Math.Matrix2 matrix;
        public Random random;

        public delegate void VOID();

        public VOID LOAD;
        public VOID UPDATE;
        public VOID RENDER;
        public VOID INIT;

        private int renderSize, stateSize;
        public int CX, CY;

        public Tortoise2d(string windowTitle, int windowWidth, int windowHeight, int unitsOnX, int unitsOnY, int renderSize, int stateSize)
        {
            Console.WriteLine(author);
            WWidth = windowWidth;
            WHeight = windowHeight;
            WTitle = windowTitle;
            this.X = 100;
            this.Y = 100;
            References.game = this;

            Title = WTitle;
            ClientSize = new System.Drawing.Size(WWidth, WHeight);
            Debug.PrintEngine("Window: W:" + ClientSize.Width + ",H:" + ClientSize.Height);
            //this.WindowState = WindowState.Fullscreen;
            
            this.renderSize = renderSize;
            this.stateSize = stateSize;

            grid = new Grid(unitsOnX, unitsOnY, WWidth, WHeight);
            CX = unitsOnX;
            CY = unitsOnY;
            textures = new TextureManager();
            renderer = new Renderer(this, WWidth, WHeight + 44, renderSize, 1000, textures, grid);
            layers = new LayerManager(10);
            input = new PCInput(this);
            states = new GameStateManager(this, stateSize);
            camera = new Camera(this, 0, 0);
            sound = new SoundManager(1000);
            fps = new FPS();

            matrix = new Math.Matrix2();
            matrix.SetAll(0);
            random = new Random();
            
            References.renderer = renderer;
            References.input = input;
            References.textures = textures;
            References.layers = layers;
            References.states = states;
            References.grid = grid;
            References.camera = camera;
            References.sound = sound;
            References.matrix = matrix;
            References.random = random;
            References.fps = fps;

            Debug.DEBUG = true;
            Debug.ENGINE_DEBUG = true;
        }

        public void voiddummy()
        {
        }

        public void SetGameFunctions(VOID load, VOID init, VOID update, VOID render)
        {
            LOAD = load;
            INIT = init;
            UPDATE = update;
            RENDER = render;
        }

        public void LaunchGame(bool framecap = true)
        {
            if (framecap)
                Run(60, 60);
            else
                Run();
        }

        public void EXEC_LOAD() { LOAD(); }
        public void EXEC_INIT() { INIT(); }
        public void EXEC_UPDATE() { UPDATE(); }
        public void EXEC_RENDER() { RENDER(); }

        protected override void OnLoad(EventArgs e)
        {
            layers.AddLayer("GUI", renderer.GenLayer(WWidth, WHeight));
            textures.AddGUI("assets/font.png", "font");
            textures.AddGUI("assets/button.png", "button");
            textures.AddRawTexture("assets/tortoise2D_logo.png", "tortoise2dlogo");
            textures.AddRawTexture("assets/black.png", "black");
            textures.AddRawTexture("assets/white.png", "white");
            
            states.AddState("game", new runGame(this, states));
            states.AddState("logo", new flashScreen(this, states));

            states.Load();
            textures.LoadSprites();
            textures.LoadGUI();
            states.Init();
            states.ActiveState("logo");

            base.OnLoad(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (input.GetKeyDown("c") && input.GetKeyDown("o") && input.GetKeyDown("d") && input.GetKeyDown("y"))
            {
                Console.WriteLine("----WATERMARK=[" + author + "]----");
            }
            input.Update();
            states.Update();
            fps.Update();
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            renderer.START();
            states.Render();
            renderer.NewLayer(true);
            renderer.END(this);
            base.OnRenderFrame(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            this.Dispose();
            base.OnClosed(e);
        }
    }
}