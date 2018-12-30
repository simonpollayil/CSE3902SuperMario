using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Collision;

namespace SuperMario.Entities.Blocks
{
    public class QuestionBlock : HitUpAndDownBlockAnimated
    {
        Texture2D questionBlockTexture;
        int currentY;
        bool blockHit;
        BlockItemType blockItemType;
        Entity containedItem;
        int numberOfBlockFrames = 3;
        int heightOfBlock = 16;
        int numberOfBlocksInSprite = 4;

        public QuestionBlock(Vector2 screenLocation, BlockItemType item) : base(screenLocation, 700000)
        {
            questionBlockTexture = WinterTextureStorage.QuestionBlockSpriteSheetWinter;

            blockItemType = item;

            blockHit = false;
        }

        public override ISprite FirstSprite => new Sprite(questionBlockTexture, new Rectangle(0, 0, questionBlockTexture.Width / numberOfBlocksInSprite, questionBlockTexture.Height / numberOfBlockFrames));

        public override ISprite NextSprite
        {
            get
            {
                if (!blockHit)
                {
                    if (currentY == (heightOfBlock*numberOfBlockFrames)-heightOfBlock)
                        currentY = 0;
                    else
                        currentY += heightOfBlock;

                    return new Sprite(questionBlockTexture, new Rectangle(0, currentY, heightOfBlock, heightOfBlock));
                }

                return new Sprite(WinterTextureStorage.HitBlockSpriteSheetWinter, new Rectangle(0, 0, heightOfBlock, heightOfBlock));
            }
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }

        public void Hit(PowerUpType powerUpType)
        {
            if (!IsHit())
            {
                Jiggle();

                blockHit = true;
                currentY = 0;

                if (blockItemType != BlockItemType.None)
                {
                    containedItem = BlockHelper.CreateItem(blockItemType, ScreenLocation, powerUpType);
                    EntityStorage.Instance.QueueItemEntity(containedItem);
                }
            }
        }

        public bool IsHit()
        {
            return blockHit;
        }
    }
}
