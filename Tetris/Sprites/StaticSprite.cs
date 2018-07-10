using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris.Sprites
{
    internal class StaticAtlasSprite : Sprite
    {
        public StaticAtlasSprite(Texture2D texture, Point dimensions, Point positionOnTextureAtlas) : base(texture, dimensions, positionOnTextureAtlas)
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Color tint, Point positionInGame)
        {
            if (!this.IsVisible) return;

            var sourceRectangle = new Rectangle(this.PositionOnTextureAtlas, this.Dimensions);
            var destinationRectangle = new Rectangle(positionInGame, this.Dimensions);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, tint);
        }

        public override void Update(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
        }
    }
}
