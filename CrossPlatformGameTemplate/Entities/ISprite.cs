using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities
{
    public interface ISprite
    {
        void Draw(Vector2 screenLocation, SpriteBatch spriteBatch);
        Color Color { get; set; }

        Rectangle GetBoundingBox(Vector2 screenLocation);
    }
}
