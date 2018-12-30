using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Collision;

namespace SuperMario.Entities.BackgroundElements
{
    public class Flag : StaticEntity
    {
        bool slidingDown;
        int slideDistance = 120;
        float slideSpeed = 1.25f;

        Vector2 originalLocation;

        public Flag(Vector2 screenLocation) : base(screenLocation)
        {
            Texture2D flagTexture = WinterBackgroundTextureStorage.FlagTextureWinter;
            CurrentSprite = new Sprite(flagTexture, new Rectangle(0, 0, flagTexture.Width, flagTexture.Height));

            originalLocation = screenLocation;
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (slidingDown && ScreenLocation.Y < originalLocation.Y + slideDistance)
                ScreenLocation = new Vector2(ScreenLocation.X, ScreenLocation.Y + slideSpeed);
            else if(slidingDown)
                slidingDown = false;
        }

        public void SlideDown()
        {
            slidingDown = true;
        }
    }
}
