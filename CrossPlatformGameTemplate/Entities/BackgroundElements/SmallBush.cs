using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Collision;

namespace SuperMario.Entities.BackgroundElements
{
    public class SmallBush : StaticEntity
    {
        public SmallBush(Vector2 screenLocation) : base(screenLocation)
        {
            Texture2D bushTexture = WinterBackgroundTextureStorage.SmallBushTextureWinter;
            CurrentSprite = new Sprite(bushTexture, new Rectangle(0, 0, bushTexture.Width, bushTexture.Height));
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }
}
