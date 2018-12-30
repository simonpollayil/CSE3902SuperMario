using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities
{
    public abstract class MovingAnimatedEntity : MovingEntity
    {
        int animationDelayInTicks;
        long lastGameTime;

        protected MovingAnimatedEntity(Vector2 screenLocation, int animationDelay) : base(screenLocation)
        {
            animationDelayInTicks = animationDelay;
            EntityXDirection = Direction.Right;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (CurrentSprite == null)
                CurrentSprite = FirstSprite;

            CurrentSprite.Draw(ScreenLocation, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (lastGameTime == 0)
                lastGameTime = gameTime.TotalGameTime.Ticks;

            if (gameTime.TotalGameTime.Ticks - lastGameTime > animationDelayInTicks)
            {
                lastGameTime = gameTime.TotalGameTime.Ticks;

                CurrentSprite = NextSprite;
            }
            base.Update(gameTime);
        }

        public abstract ISprite NextSprite { get; }

        public abstract ISprite FirstSprite { get; }
    }
}
