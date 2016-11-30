using System;


namespace Tortoise2D_v3.Platform
{
    internal class GameState
    {
        public GameStateManager states;
        public Tortoise2d game;

        public GameState(Tortoise2d game, GameStateManager states)
        {
            this.states = states;
            this.game = game;
        }

        public virtual void Load()
        {
            
        }
        public virtual void Init()
        {
            
        }
        public virtual void Update()
        {
        }
        public virtual void Render()
        {
        }
    }
}
