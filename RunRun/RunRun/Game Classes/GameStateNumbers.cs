using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunRun.Game_Classes
{
    public class GameStateNumbers
    {
        // Define top level states i.e. if the game is in menu, play or exit state
        public const int STATE_MENU = 0, STATE_PLAY = 1, STATE_EXIT = 2;
        public int top_level_state = 0;

        // Define menu states i.e. if the menu is in root or tutorial state
        public const int MENU_STATE_ROOT = 0, MENU_STATE_TUTORIAL = 1;
        public int menu_level_state = 0;

        // Define game states i.e. if the game is paused or not
        public const int GAME_STATE_PLAY = 0, GAME_STATE_PAUSE = 1;
        public int game_level_state = 0;

        // Define termination states i.e. if the player really wants to exit the game or not
        public const int EXIT_STATE_CONFIRM = 0, EXIT_STATE_WILLEXIT = 1;
        public int exit_level_state = 0;
    }
}
