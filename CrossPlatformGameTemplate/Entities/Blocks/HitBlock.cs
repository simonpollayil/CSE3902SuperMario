using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Blocks
{
    public class HitBlock : StaticEntity
    {
        Texture2D hitBlockTexture;

        public HitBlock(Vector2 screenLocation) : base(screenLocation)
        {
            int numberOfBlocksInSprite = 4;
            hitBlockTexture = WinterTextureStorage.HitBlockSpriteSheetWinter;
            int width = hitBlockTexture.Width / numberOfBlocksInSprite;
            int height = width;
            CurrentSprite = new Sprite(hitBlockTexture, new Rectangle(0, 0, width, height));
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }
}
