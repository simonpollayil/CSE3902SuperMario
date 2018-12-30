using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Collision;

namespace SuperMario.Entities.BackgroundElements
{
    public class GameOverScreen : StaticEntity
    {
        int xSpriteOffset = -94;
        public GameOverScreen() : base(Vector2.Zero)
        {
            int spriteScaler = 2;
            Texture2D gameOverTexture = WinterBackgroundTextureStorage.GameOverTextureWinter;
            CurrentSprite = new Sprite(gameOverTexture, new Rectangle(xSpriteOffset, 0, gameOverTexture.Width * spriteScaler, gameOverTexture.Height * spriteScaler));
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            CurrentSprite.Draw(Vector2.Zero, spriteBatch);
        }
    }
}
