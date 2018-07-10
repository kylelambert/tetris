using Tetris.Commands;
using System;

namespace Tetris.Controllers
{
    internal interface IController
    {
        /// <summary>
        /// Add a new command with a given controller input.
        /// </summary>
        /// <param name="input">The input of the controller.</param>
        /// <param name="command">The command associated with the input.</param>
        void AddInputCommand(Enum input, ICommand command);

        /// <summary>
        /// Update the current input of the controller.
        /// </summary>
        void UpdateInput();
    }
}
