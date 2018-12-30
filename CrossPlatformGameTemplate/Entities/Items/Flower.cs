using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Sound;

namespace SuperMario.Entities.Items
{
    public class Flower : AnimatedEntity
    {
        Texture2D flowerTexture;
        int currentX;

        int numberOfFrames = 8;

        public Flower(Vector2 screenLocation) : base(screenLocation, 700000)
        {
            flowerTexture = WinterTextureStorage.FlowerSpriteSheetWinter;
        }

        public override ISprite FirstSprite => new Sprite(flowerTexture, new Rectangle(0, 0, flowerTexture.Width / numberOfFrames, flowerTexture.Height));

        public override ISprite NextSprite
        {
            get
            {
                currentX += flowerTexture.Width / numberOfFrames;
                if (currentX == flowerTexture.Width)
                {
                    currentX = 0;
                }
                return new Sprite(flowerTexture, new Rectangle(currentX, 0, flowerTexture.Width / numberOfFrames, flowerTexture.Height));

            }
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }

        public void Obtain()
        {
            SoundEffects.Instance.PlayPowerUp();
            Seppuku();
        }
    }
}
