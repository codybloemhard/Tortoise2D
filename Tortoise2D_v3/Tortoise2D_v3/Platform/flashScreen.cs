using System;

namespace Tortoise2D_v3.Platform
{
    internal class flashScreen : GameState
    {
        int index = 0;

        public flashScreen(Tortoise2d game, GameStateManager states) : base(game, states)
        {

        }
        public override void Load()
        {
            game.layers.AddLayer("flash_logo", game.renderer.GenLayer(game.WWidth, game.WHeight));
            //game.layers.AddLayer("flash_light", game.renderer.GenLayer(game.WWidth, game.WHeight));
        }
        public override void Init()
        {
            //nothing here
            Debug.PrintEngine("Splashscreen loaded");
        }
        public override void Update()
        {
            game.input.lockMouse(false);
            game.camera.SetPositionLeftTop(0, 0);
            index++;
            if (game.input.GetKeyDown("q") && game.input.GetKeyDown("w") && game.input.GetKeyDown("e"))
                states.ActiveState("game");
            if (index > 120*2)
               states.ActiveState("game");
        }
        public override void Render()
        {
            //with "lighting"
            /*
            game.renderer.BindTexture(game.textures.GetRawTexture("white"));
            game.renderer.AddSprite(0, 0, game.grid.GetCellsX(), game.grid.GetCellsY());
            game.renderer.Render_SceneToLayer(game.layers.GetLayer("flash_light"));
            game.renderer.NewLayer(true);

            game.renderer.BindTexture(game.textures.GetRawTexture("tortoise2dlogo"));
            game.renderer.AddSprite(0,0, game.grid.GetCellsX(), game.grid.GetCellsY());
            game.renderer.Render_SceneToLayer(game.layers.GetLayer("flash_logo"));

            Layer[] logolayer = new Layer[] { game.layers.GetLayer("flash_logo")};
            Layer[] lightlayer = new Layer[] { game.layers.GetLayer("flash_light") };
            game.renderer.Render_MergeLayers(logolayer, lightlayer);
            */

            game.renderer.BindTexture(game.textures.GetRawTexture("tortoise2dlogo"));
            game.renderer.AddSprite(0, 0, game.grid.GetCellsX(), game.grid.GetCellsY());
            game.renderer.Render_SceneToLayer(game.layers.GetLayer("flash_logo"));
            game.renderer.RenderLayer(game.layers.GetLayer("flash_logo"));
        }
    }
}