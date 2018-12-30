using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.ScoreSystem;
using SuperMario.Sound;

namespace SuperMario
{
    public sealed class HUDController
    {
        SpriteFont currentFont;
        long timeCounter;
        long limitInTicks = 4000000000;
        readonly int hurryTimeInTicks = 1000000000;
        bool hurryTime = false;
        GameTime gameTime;

        public long TimeInTicks { get; private set; } = 4000000000;

        private static readonly HUDController instance = new HUDController();
        private HUDController()
        {
        }

        public static HUDController Instance
        {
            get
            {
                return instance;
            }
        }

        public void Initialize(SpriteFont font)
        {
            currentFont = font;
        }

        public void SetGameTime(GameTime currentGameTime)
        {
            gameTime = currentGameTime;
        }

        public void ResetTimer()
        {
            TimeInTicks = 4000000000;
            limitInTicks = 4000000000;
            timeCounter = 0;
        }

        public void KeepTime()
        {
            timeCounter += gameTime.ElapsedGameTime.Ticks;
            TimeInTicks = limitInTicks - timeCounter;
            if (!hurryTime && TimeInTicks <= hurryTimeInTicks)
            {
                hurryTime = true;
                Music.Event();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int tickToSecondConversion = 10000000;

            int worldLocationYOffset = 30;
            int coinLocationXOffset = 700;
            int lifeLocationXOffset = 350;
            int timeLocationXOffset = 700;
            int timeLocationYOffset = 30;

            Vector2 scoreLocation = Vector2.Zero;
            Vector2 worldLocation = new Vector2(0, worldLocationYOffset);
            Vector2 coinLocation = new Vector2(coinLocationXOffset, 0);
            Vector2 timeLocation = new Vector2(timeLocationXOffset, timeLocationYOffset);
            Vector2 lifeLocation = new Vector2(lifeLocationXOffset, 0);
            spriteBatch.DrawString(currentFont, "Score : " + ScoreKeeper.Instance.Score, scoreLocation, Color.NavajoWhite);
            spriteBatch.DrawString(currentFont, "World 1-1", worldLocation, Color.NavajoWhite);
            spriteBatch.DrawString(currentFont, "Lives: " + ScoreKeeper.LifeCount, lifeLocation, Color.NavajoWhite);
            spriteBatch.DrawString(currentFont, "Coin : " + ScoreKeeper.CoinCount, coinLocation, Color.NavajoWhite);
            spriteBatch.DrawString(currentFont, "Time : " + TimeInTicks / tickToSecondConversion, timeLocation, Color.NavajoWhite);
        }
    }
}