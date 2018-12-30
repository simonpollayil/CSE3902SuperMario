using Microsoft.Xna.Framework;

namespace SuperMario.Entities.Blocks
{
    public class BlueGravelBlock : GravelBlock
    {
        public BlueGravelBlock(Vector2 screenLocation) : base(screenLocation)
        {
            int numberOfBlocksInSprite = 4;
            var gravelBlockTexture = WinterTextureStorage.GravelBlockSpriteSheetWinter;
            int width = gravelBlockTexture.Width / numberOfBlocksInSprite;
            int height = width;
            CurrentSprite = new Sprite(gravelBlockTexture, new Rectangle(width, 0, width, height));
        }
    }
}
