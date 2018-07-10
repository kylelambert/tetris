using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Tetris.Commands;
using System;
using System.Collections.Generic;

namespace Tetris.Controllers
{
    internal class GamePadController : IController
    {
        /// <summary>
        /// Defines the previous state of the GamePad.
        /// </summary>
        private GamePadState _previousGamePadState;

        /// <summary>
        /// Defines the dictionary of buttons with their corresponding commands.
        /// </summary>
        private readonly Dictionary<Buttons, ICommand> _inputCommands;

        /// <summary>
        /// Constructs a GamePad controller.
        /// </summary>
        public GamePadController()
        {
            this._previousGamePadState = GamePad.GetState(PlayerIndex.One);
            this._inputCommands = new Dictionary<Buttons, ICommand>();
        }

        /// <inheritdoc />
        /// <summary>
        /// Add a new command with a given button.
        /// </summary>
        /// <param name="input">The input of the keyboard.</param>
        /// <param name="command">The command associated with the key.</param>
        public void AddInputCommand(Enum input, ICommand command)
        {
            if (!this._inputCommands.ContainsKey((Buttons)input))
            {
                this._inputCommands.Add((Buttons)input, command);
            }
        }

        /// <summary>
        /// Update the current input of the GamePad.
        /// </summary>
        public void UpdateInput()
        {
            GamePadState currentGamePadState = GamePad.GetState(PlayerIndex.One);

            List<Buttons> buttonsPressed = GetPressedButtons(currentGamePadState);
            foreach (Buttons button in buttonsPressed)
            {
                if (!_previousGamePadState.IsButtonDown(button) && this._inputCommands.ContainsKey(button))
                {
                    this._inputCommands[button].Execute();
                }
            }
            this._previousGamePadState = currentGamePadState;
        }

        /// <summary>
        /// The GetPressedButtons
        /// </summary>
        /// <param name="gamePadState">The <see cref="GamePadState"/></param>
        /// <returns>The <see cref="List{Buttons}"/></returns>
        private static List<Buttons> GetPressedButtons(GamePadState gamePadState)
        {
            List<Buttons> pressedButtons = new List<Buttons>();

            foreach (Buttons button in Enum.GetValues(typeof(Buttons)))
            {
                if (gamePadState.IsButtonDown(button))
                {
                    pressedButtons.Add(button);
                }
            }

            return pressedButtons;
        }
    }
}
