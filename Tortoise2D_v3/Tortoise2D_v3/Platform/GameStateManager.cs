using System;

namespace Tortoise2D_v3.Platform
{
    internal class GameStateManager
    {
        private int count = 0;
        private int maxStates;

        public GameState[] states;
        private string[] names;

        private GameState dummyState;
        public Tortoise2d game;
        private GameState activeState;

        public GameStateManager(Tortoise2d game, int max)
        {
            maxStates = max;
            states = new GameState[max];
            names = new string[max];
            dummyState = new GameState(game, this);
            this.game = game;
        }

        public void AddState(string name, GameState state)
        {
            names[count] = name;
            states[count] = state;
            count++;
        }

        public void Load()
        {
            for (int i = 0; i < maxStates; i++)
            {
                if (states[i] != null)
                    states[i].Load();                   
            }
        }

        public void Init()
        {
            for (int i = 0; i < maxStates; i++)
            {
                if (states[i] != null)
                    states[i].Init();
            }
        }

        public void ActiveState(string name)
        {
            for(int i = 0; i < maxStates; i++)
            {
                if (names[i] == name)
                    activeState = states[i];
            }
        }

        public string GetActiveStateName()
        {
            for (int i = 0; i < maxStates; i++)
            {
                if (states[i] == activeState)
                    return names[i];
            }
            return "";
        }

        public GameState GetActiveState()
        {
            return activeState;
        }

        public void Update()
        {
            activeState.Update();
        }
        public void Render()
        {
            activeState.Render();
        }
    }
}
