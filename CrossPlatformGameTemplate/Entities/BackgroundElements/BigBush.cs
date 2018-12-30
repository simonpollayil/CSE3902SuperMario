using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Collision;

namespace SuperMario.Entities.BackgroundElements
{
    public class BigBush : StaticEntity
    {
        public BigBush(Vector2 screenLocation) : base(screenLocation)
        {
            Texture2D bushTexture = WinterBackgroundTextureStorage.BigBushTextureWinter;
            CurrentSprite = new Sprite(bushTexture, new Rectangle(0, 0, bushTexture.Width, bushTexture.Height));
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }
}
