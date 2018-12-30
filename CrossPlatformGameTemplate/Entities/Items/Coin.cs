using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Sound;
using SuperMario.ScoreSystem.CentralSystems;

namespace SuperMario.Entities.Items
{
    public class Coin : AnimatedEntity
    {
        Texture2D coinTexture;
        int currentX;
        bool obtaining;

        float moveIncrement = 3.5f;
        int moveHeight = 10;
        bool movingUp = true;
        Vector2 startLocation;

        int numberOfFrames = 4;

        public Coin(Vector2 screenLocation) : base(screenLocation, 700000)
        {
            coinTexture = WinterTextureStorage.CoinSpriteSheetWinter;
        }

        public override ISprite FirstSprite => new Sprite(coinTexture, new Rectangle(0, 0, coinTexture.Width / numberOfFrames, coinTexture.Height));

        public override ISprite NextSprite
        {
            get
            {
                currentX += coinTexture.Width / numberOfFrames;
                if (currentX == coinTexture.Width)
                    currentX = 0;

                return new Sprite(coinTexture, new Rectangle(currentX, 0, coinTexture.Width / numberOfFrames, coinTexture.Height));
            }
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (obtaining)
            {
                if (movingUp)
                {
                    var currScreenLocation = ScreenLocation;
                    currScreenLocation.Y = currScreenLocation.Y - moveIncrement;
                    ScreenLocation = currScreenLocation;

                    if (ScreenLocation.Y <= startLocation.Y - (moveIncrement * moveHeight))
                        movingUp = false;
                }
                else
                {
                    var currScreenLocation = ScreenLocation;
                    currScreenLocation.Y = currScreenLocation.Y + moveIncrement;
                    ScreenLocation = currScreenLocation;

                    if (ScreenLocation.Y >= startLocation.Y)
                    {
                        SoundEffects.Instance.PlayCoin();
                        obtaining = false;
                        movingUp = true;
                        CoinSystem.Instance.GainOneCoin();
                        Seppuku();
                    }
                }
            }
        }

        public void Obtain()
        {
            if (!obtaining)
            {
                obtaining = true;
                startLocation = ScreenLocation;
            }
        }
    }
}