using Microsoft.Xna.Framework;

namespace SuperMario.Entities.Blocks
{
    public class BlueBrickBlock : BrickBlock
    {
        public BlueBrickBlock(Vector2 screenLocation, BlockItemType item) : base(screenLocation, item)
        {
            int numberOfBlocksInSprite = 4;
            var brickBlockTexture = WinterTextureStorage.BrickBlockSpriteSheetWinter;
            int width = brickBlockTexture.Width / numberOfBlocksInSprite;
            int height = width;
            CurrentSprite = new Sprite(brickBlockTexture, new Rectangle(width, 0, width, height));
        }
    }
}
