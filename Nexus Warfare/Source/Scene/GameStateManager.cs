using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Scene
{
    public enum GameState
    {
        MainMenu,
        Play,
        Pause,
        GameOver,
        Victory,
        Exit
    }

    public class GameStateManager
    {
        public GameState CurrentState { get; private set; }

        public GameStateManager()
        {
            CurrentState = GameState.MainMenu;
        }

        public void ChangeState(GameState newState)
        {
            CurrentState = newState;
            // Handle the transition logic between states
        }

        // Methods for handling each state (e.g., Update and Draw for each state)
    }
}
