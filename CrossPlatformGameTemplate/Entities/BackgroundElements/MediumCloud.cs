using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Collision;

namespace SuperMario.Entities.BackgroundElements
{
    public class MediumCloud : StaticEntity
    {
        public MediumCloud(Vector2 screenLocation) : base(screenLocation)
        {
            Texture2D cloudTexture = WinterBackgroundTextureStorage.MediumCloudTextureWinter;
            CurrentSprite = new Sprite(cloudTexture, new Rectangle(0, 0, cloudTexture.Width, cloudTexture.Height));
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }
}
