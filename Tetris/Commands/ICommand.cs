﻿namespace Tetris.Commands
{
    internal interface ICommand
    {
        /// <summary>
        /// Execute action of the receiver.
        /// </summary>
        void Execute();
    }
}
