using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Collision;

namespace SuperMario.Entities.BackgroundElements
{
    public class Castle : StaticEntity
    {
        public Castle(Vector2 screenLocation) : base(screenLocation)
        {
            Texture2D castleTexture = WinterBackgroundTextureStorage.CastleTextureWinter;
            CurrentSprite = new Sprite(castleTexture, new Rectangle(0, 0, castleTexture.Width, castleTexture.Height));
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }
}
