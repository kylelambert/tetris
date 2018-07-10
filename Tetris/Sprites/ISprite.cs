using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris.Sprites
{
    internal interface ISprite
    {
        Point Position { get; set; }

        /// <summary>
        /// Gets the visibility of the sprite
        /// </summary>
        bool IsVisible { get; }

        /// <summary>
        /// Draws the sprite to the screen
        /// </summary>
        /// <param name="spriteBatch">The <see cref="SpriteBatch"/> used to render sprites to the screen</param>
        /// <param name="tint">The <see cref="Color"/> used to tint sprites</param>
        /// <param name="positionInGame">The <see cref="Point"/> where sprites are rendered to the screen</param>
        void Draw(SpriteBatch spriteBatch, Color tint, Point positionInGame);
        
        /// <summary>
        /// Updates the position of the sprite
        /// </summary>
        /// <param name="gameTime">The <see cref="GameTime"/> of the current program</param>
        /// <param name="graphicsDevice">The <see cref="GraphicsDevice"/> of the current program</param>
        void Update(GameTime gameTime, GraphicsDevice graphicsDevice);
    }
}
