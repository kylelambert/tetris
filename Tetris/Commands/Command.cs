namespace Tetris.Commands
{
    /// <summary>
    /// GENERIC COMMAND INTERFACE IMPLEMENTATION
    /// </summary>
    /// <typeparam name="TReceiver"></typeparam>
    internal abstract class Command<TReceiver> : ICommand
    {
        /// <summary>
        /// Defines the generic receriver of the command.
        /// </summary>
        protected TReceiver Receiver;

        /// <summary>
        /// Constructs a command using a generic receiver.
        /// </summary>
        /// <param name="receiver">The generic receiver object</param>
        protected Command(TReceiver receiver)
        {
            this.Receiver = receiver;
        }

        /// <inheritdoc />
        /// <summary>
        /// Executes set action of the given receiver.
        /// </summary>
        public abstract void Execute();
    }

    internal abstract class GameCommand : Command<TetrisGame>
    {
        /// <inheritdoc />
        protected GameCommand(TetrisGame game) : base(game)
        {
        }
    }
}
