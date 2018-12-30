using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities
{
    public abstract class AnimatedEntity : Entity
    {
        public int AnimationDelayInTicks { get; set; }
        long lastGameTime;

        protected AnimatedEntity(Vector2 screenLocation, int animationDelay): base(screenLocation)
        {
            this.AnimationDelayInTicks = animationDelay;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (CurrentSprite == null)
                CurrentSprite = FirstSprite;

            CurrentSprite.Draw(ScreenLocation, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (CurrentSprite == null)
                CurrentSprite = FirstSprite;

            if (lastGameTime == 0)
                lastGameTime = gameTime.TotalGameTime.Ticks;

            if (gameTime.TotalGameTime.Ticks - lastGameTime > AnimationDelayInTicks)
            {
                lastGameTime = gameTime.TotalGameTime.Ticks;

                CurrentSprite = NextSprite;
            }
        }

        public abstract ISprite NextSprite { get; }

        public abstract ISprite FirstSprite { get; }
    }
}
