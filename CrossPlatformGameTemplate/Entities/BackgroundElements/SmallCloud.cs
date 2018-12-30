using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Collision;

namespace SuperMario.Entities.BackgroundElements
{
    public class SmallCloud : StaticEntity
    {
        public SmallCloud(Vector2 screenLocation) : base(screenLocation)
        {
            Texture2D cloudTexture = WinterBackgroundTextureStorage.SmallCloudTextureWinter;
            CurrentSprite = new Sprite(cloudTexture, new Rectangle(0, 0, cloudTexture.Width, cloudTexture.Height));
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }
}
