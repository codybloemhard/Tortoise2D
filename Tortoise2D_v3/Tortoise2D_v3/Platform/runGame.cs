using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tortoise2D_v3.Platform
{
    internal class runGame : GameState
    {
        public runGame(Tortoise2d game, GameStateManager states) : base(game, states)
        {

        }

        public override void Load()
        {
            game.EXEC_LOAD();
        }
        public override void Init()
        {
            game.EXEC_INIT();
        }
        public override void Update()
        {
            game.EXEC_UPDATE();
        }
        public override void Render()
        {
            game.EXEC_RENDER();
        }
    }
}
