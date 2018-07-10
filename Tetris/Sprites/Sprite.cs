using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris.Sprites
{
    internal abstract class Sprite : ISprite
    {
        protected Point PositionInGame;

        /// <summary>
        /// Defines the texture of the sprite
        /// </summary>
        protected Texture2D Texture;

        /// <summary>
        /// Defines the width and height of the sprite
        /// </summary>
        protected Point Dimensions;

        /// <summary>
        /// Defines the upper left point of the image on the png
        /// </summary>
        protected Point PositionOnTextureAtlas;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class
        /// </summary>
        /// <param name="texture">The 2D texture for the sprite</param>
        /// <param name="dimensions">The <see cref="Point"/> for width and height of the sprite</param>
        /// <param name="positionOnTextureAtlas">The upper left <see cref="Point"/> on the png file where the 
        ///         sprite is located</param>
        protected Sprite(Texture2D texture, Point dimensions, Point positionOnTextureAtlas)
        {
            this.Texture = texture;
            this.Dimensions = dimensions;
            this.PositionOnTextureAtlas = positionOnTextureAtlas;
            this.PositionInGame = Point.Zero;
            this.IsVisible = true;
        }

        /// <inheritdoc />
        public abstract void Draw(SpriteBatch spriteBatch, Color tint, Point positionInGame);
        
        /// <inheritdoc />
        public abstract void Update(GameTime gameTime, GraphicsDevice graphicsDevice);

        /// <inheritdoc />
        public bool IsVisible { get; protected set; }

        public Point Position { get => PositionInGame; set => PositionInGame = value; }
    }
}
