using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities
{
    public class TintableSprite : ISprite
    {
        Texture2D texture;
        readonly Rectangle sourceRectangle;

        public TintableSprite(Texture2D texture, Rectangle sourceRectangle)
        {
            this.texture = texture;
            Color = Color.White;
            this.sourceRectangle = sourceRectangle;
        }

        public Color Color { get; set; }

        public void Draw(Vector2 screenLocation, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)screenLocation.X, (int)screenLocation.Y, sourceRectangle.Width, sourceRectangle.Height), sourceRectangle, Color);
        }

        public Rectangle GetBoundingBox(Vector2 screenLocation)
        {
            return new Rectangle((int)screenLocation.X, (int)screenLocation.Y, sourceRectangle.Width, sourceRectangle.Height);
        }
    }
}
