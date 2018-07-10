namespace Tetris.Commands
{
    internal class ExitCommand : GameCommand
    {
        /// <inheritdoc />
        /// <summary>
        /// Constructs a new command to exit the main game.
        /// </summary>
        /// <param name="game">The main game class of the program.</param>
        public ExitCommand(TetrisGame game) : base(game)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Exits the game.
        /// </summary>
        public override void Execute()
        {
            this.Receiver.Exit();
        }
    }

    internal class MoveLeft : GameCommand
    {
        /// <inheritdoc />
        /// <summary>
        /// Constructs a new command to exit the main game.
        /// </summary>
        /// <param name="game">The main game class of the program.</param>
        public MoveLeft(TetrisGame game) : base(game)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Exits the game.
        /// </summary>
        public override void Execute()
        {
            this.Receiver.MoveLeft();
        }
    }

    internal class MoveRight : GameCommand
    {
        /// <inheritdoc />
        /// <summary>
        /// Constructs a new command to exit the main game.
        /// </summary>
        /// <param name="game">The main game class of the program.</param>
        public MoveRight(TetrisGame game) : base(game)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Exits the game.
        /// </summary>
        public override void Execute()
        {
            this.Receiver.MoveRight();
        }
    }

    internal class MoveDown : GameCommand
    {
        /// <inheritdoc />
        /// <summary>
        /// Constructs a new command to exit the main game.
        /// </summary>
        /// <param name="game">The main game class of the program.</param>
        public MoveDown(TetrisGame game) : base(game)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Exits the game.
        /// </summary>
        public override void Execute()
        {
            this.Receiver.MoveDown();
        }
    }

    internal class HardDrop : GameCommand
    {
        /// <inheritdoc />
        /// <summary>
        /// Constructs a new command to exit the main game.
        /// </summary>
        /// <param name="game">The main game class of the program.</param>
        public HardDrop(TetrisGame game) : base(game)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Exits the game.
        /// </summary>
        public override void Execute()
        {
            this.Receiver.HardDrop();
        }
    }
}
