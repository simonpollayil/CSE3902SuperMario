using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Blocks
{
    public class GravelBlock : StaticEntity
    {
        readonly Texture2D gravelBlockTexture;

        public GravelBlock(Vector2 screenLocation) : base(screenLocation)
        {
            int numberOfBlocksInSprite = 4;
            gravelBlockTexture = WinterTextureStorage.GravelBlockSpriteSheetWinter;
            int width = gravelBlockTexture.Width / numberOfBlocksInSprite;
            int height = width;
            CurrentSprite = new Sprite(gravelBlockTexture, new Rectangle(0, 0, width, height));
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }
}
