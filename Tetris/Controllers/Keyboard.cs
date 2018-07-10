using Microsoft.Xna.Framework.Input;
using Tetris.Commands;
using System;
using System.Collections.Generic;

namespace Tetris.Controllers
{
    internal class KeyboardController : IController
    {
        /// <summary>
        /// Defines the previous input state of the keyboard
        /// </summary>
        private KeyboardState _previousKeyboardState;

        /// <summary>
        /// Defines the dictionary of keys with their corresponding commands
        /// </summary>
        private readonly Dictionary<Keys, ICommand> _inputCommands;

        /// <summary>
        /// Constructs a keyboard controller
        /// </summary>
        public KeyboardController()
        {
            this._previousKeyboardState = Keyboard.GetState();
            this._inputCommands = new Dictionary<Keys, ICommand>();
        }

        /// <summary>
        /// Add a new command with a given key
        /// </summary>
        /// <param name="input">The input of the keyboard</param>
        /// <param name="command">The command associated with the key</param>
        public void AddInputCommand(Enum input, ICommand command)
        {
            if (!this._inputCommands.ContainsKey((Keys)input))
            {
                this._inputCommands.Add((Keys)input, command);
            }
        }

        /// <summary>
        /// Update the current input of the keyboard
        /// </summary>
        public void UpdateInput()
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            Keys[] keysPressed = currentKeyboardState.GetPressedKeys();
            foreach (Keys key in keysPressed)
            {
                if (!_previousKeyboardState.IsKeyDown(key) && this._inputCommands.ContainsKey(key))
                {
                    this._inputCommands[key].Execute();
                }
            }
            this._previousKeyboardState = currentKeyboardState;
        }
    }
}
