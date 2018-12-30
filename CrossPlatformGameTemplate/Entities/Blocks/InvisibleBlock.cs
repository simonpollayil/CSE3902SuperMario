using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Blocks
{
    public class InvisibleBlock : HitUpAndDownBlockStatic
    {
        Texture2D hitBlockTexture;
        BlockItemType blockItemType;
        bool hit;
        Entity containedItem;

        int numberOfBlocksInSprite = 4;

        public InvisibleBlock(Vector2 screenLocation, BlockItemType item) : base(screenLocation)
        {
            hitBlockTexture = WinterTextureStorage.HitBlockSpriteSheetWinter;

            blockItemType = item;

            CurrentSprite = new Sprite(WinterTextureStorage.InvisbleBlockWinter, new Rectangle(0, 0, WinterTextureStorage.BrickBlockSpriteSheetWinter.Width / numberOfBlocksInSprite, WinterTextureStorage.BrickBlockSpriteSheetWinter.Width / numberOfBlocksInSprite));
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }

        public void Hit(PowerUpType powerUpType) {
            if (!hit)
            {
                Jiggle();
                CurrentSprite = new Sprite(hitBlockTexture, new Rectangle(0, 0, hitBlockTexture.Width / numberOfBlocksInSprite, hitBlockTexture.Width / numberOfBlocksInSprite));

                hit = true;

                if (blockItemType != BlockItemType.None)
                {
                    containedItem = BlockHelper.CreateItem(blockItemType, ScreenLocation, powerUpType);
                    EntityStorage.Instance.QueueItemEntity(containedItem);
                }
            }
        }
    }
}
