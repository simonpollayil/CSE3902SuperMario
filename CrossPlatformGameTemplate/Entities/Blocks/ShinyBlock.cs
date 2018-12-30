using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Blocks
{
    public class ShinyBlock : StaticEntity
    {
        Texture2D shinyBlockTexture;

        public ShinyBlock(Vector2 screenLocation) : base(screenLocation)
        {
            int numberOfBlocks = 4;
            shinyBlockTexture = WinterTextureStorage.ShinyBlockSpriteSheetWinter;
            int width = shinyBlockTexture.Width / numberOfBlocks;
            int height = width;
            CurrentSprite = new Sprite(shinyBlockTexture, new Rectangle(0, 0, width, height));
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }
}
