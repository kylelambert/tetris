using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tetris.Commands;
using Tetris.Controllers;
using Tetris.Sprites;

namespace Tetris
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TetrisGame : Game
    {
        private SpriteBatch _spriteBatch;

        #region Controllers
        private IController _keyboard;
        private IController _gamePad;
        #endregion
        
        private Texture2D _block;
        private Texture2D _background;
        private Texture2D _border;

        private Sprite _currentBlock;
        private int _currentX;
        private int _currentY;
        private int _posX;
        private int _posY;
        private bool _hit;

        private int _timeElapsed;

        private int _offsetX;
        private int _offsetY;
        private Grid _grid;

        public TetrisGame()
        {
            GraphicsDeviceManager graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.IsMouseVisible = true;
            graphics.IsFullScreen = false;

            graphics.PreferredBackBufferWidth = 448;
            graphics.PreferredBackBufferHeight = 800;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this._keyboard = new KeyboardController();
            this._gamePad = new GamePadController();

            this._keyboard.AddInputCommand(Keys.Q, new ExitCommand(this));
            this._gamePad.AddInputCommand(Buttons.Start, new ExitCommand(this));

            this._keyboard.AddInputCommand(Keys.Left, new MoveLeft(this));
            this._keyboard.AddInputCommand(Keys.Right, new MoveRight(this));
            this._keyboard.AddInputCommand(Keys.Down, new MoveDown(this));
            this._keyboard.AddInputCommand(Keys.Up, new HardDrop(this));

            _offsetX = 64;
            _offsetY = 96;
            _grid = new Grid(_offsetX, _offsetY);
            _currentX = 0;
            _currentY = 1;
            _posX = 0;
            _posY = 0;
            _timeElapsed = 0;
            _hit = false;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            _block = Content.Load<Texture2D>("block");
            _background = Content.Load<Texture2D>("background");
            _border = Content.Load<Texture2D>("border");

            _currentBlock = new StaticAtlasSprite(_block, new Point(32, 32), Point.Zero);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
            Content.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            this._keyboard.UpdateInput();
            this._gamePad.UpdateInput();

            _timeElapsed += gameTime.ElapsedGameTime.Milliseconds;
            
            if (_timeElapsed > 750)
            {
                MoveDown();
                if (_hit)
                {
                    _hit = false;
                }
            }

            _grid.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);
            this._spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _grid.Draw(_spriteBatch, Color.White, _block, _background, _border);

            _currentBlock.Draw(_spriteBatch, Color.White, new Point(_posX + _offsetX, _posY + _offsetY));

            this._spriteBatch.End();
            base.Draw(gameTime);
        }

        public void MoveLeft()
        {
            if (_currentX > 0 && _grid.GetArray()[_currentY, _currentX - 1] == 0)
            {
                _posX -= 32;
                _currentX--;
            }
        }

        public void MoveRight()
        {
            if (_currentX + 1 < _grid.GetColumns() && _grid.GetArray()[_currentY, _currentX + 1] == 0)
            {
                _posX += 32;
                _currentX++;
            }
        }

        public void MoveDown()
        {
            _timeElapsed = 0;

            if (_currentY + 1 < _grid.GetRows() && _grid.GetArray()[_currentY + 1, _currentX] == 0)
            {
                _posY += 32;
                _currentY++;
            }
            else
            {
                _hit = true;
                _grid.GetArray()[_currentY, _currentX] = 1;

                _currentBlock = new StaticAtlasSprite(_block, new Point(32, 32), Point.Zero);
                _currentX = 0;
                _currentY = 1;
                _posY = 0;
                _posX = 0;
                _timeElapsed = 0;
            }
        }

        public void HardDrop()
        {
            while (!_hit)
            {
                MoveDown();
            }

            _hit = false;
        }
    }
}
