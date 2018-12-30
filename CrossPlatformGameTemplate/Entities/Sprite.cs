using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities
{
    public class Sprite : ISprite
    {
        Texture2D texture;
        Rectangle sourceRectangle;
        int boundingBoxWidth = -1;
        int boundingBoxHeight = -1;
        public Color Color { get; set; }

        public Sprite(Texture2D texture, Rectangle sourceRectangle)
        {
            this.texture = texture;
            this.sourceRectangle = sourceRectangle;
            Color = Color.White;
        }

        public Sprite(Texture2D texture, Rectangle sourceRectangle, int boundingBoxWidth, int boundingBoxHeight)
        {
            this.texture = texture;
            this.sourceRectangle = sourceRectangle;
            this.boundingBoxWidth = boundingBoxWidth;
            this.boundingBoxHeight = boundingBoxHeight;
        }

        public void Draw(Vector2 screenLocation, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)screenLocation.X, (int)screenLocation.Y, sourceRectangle.Width, sourceRectangle.Height), sourceRectangle, Color);
        }

        public Rectangle GetBoundingBox(Vector2 screenLocation)
        {
            int emptyBoundingBoxValue = -1;
            if(boundingBoxWidth > emptyBoundingBoxValue && boundingBoxHeight > emptyBoundingBoxValue) // bounding box exists properly
                return new Rectangle((int)screenLocation.X, (int)screenLocation.Y, boundingBoxWidth, boundingBoxHeight);
            else
                return new Rectangle((int)screenLocation.X, (int)screenLocation.Y, sourceRectangle.Width, sourceRectangle.Height);
        }
    }
}
