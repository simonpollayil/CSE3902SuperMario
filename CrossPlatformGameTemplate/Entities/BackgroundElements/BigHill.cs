using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Collision;

namespace SuperMario.Entities.BackgroundElements
{
    public class BigHill : StaticEntity
    {
        public BigHill(Vector2 screenLocation) : base(screenLocation)
        {
            Texture2D hillTexture = WinterBackgroundTextureStorage.BigHillTextureWinter;
            CurrentSprite = new Sprite(hillTexture, new Rectangle(0, 0, hillTexture.Width, hillTexture.Height));
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }
}
