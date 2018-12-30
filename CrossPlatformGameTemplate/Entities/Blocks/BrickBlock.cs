using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Sound;

namespace SuperMario.Entities.Blocks
{
    public class BrickBlock : HitUpAndDownBlockStatic
    {
        readonly Texture2D brickBlockTexture;

        Entity containedItem;

        public BlockItemType BlockItemType { get; set; }

        public BrickBlock(Vector2 screenLocation, BlockItemType item) : base(screenLocation)
        {
            int numberOfBlocksInSprite = 4;
            brickBlockTexture = WinterTextureStorage.BrickBlockSpriteSheetWinter;
            int width = brickBlockTexture.Width / numberOfBlocksInSprite;
            int height = width;
            CurrentSprite = new Sprite(brickBlockTexture, new Rectangle(0, 0, width, height));
            BlockItemType = item;
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }

        public void Hit(PowerUpType powerUpType) 
        {
            SoundEffects.Instance.PlayBreakBlock();
            Jiggle();
            Seppuku();

            if (BlockItemType != BlockItemType.None)
            {
                containedItem = BlockHelper.CreateItem(BlockItemType, ScreenLocation, powerUpType);
                EntityStorage.Instance.QueueItemEntity(containedItem);
            }
        }
    }
}
