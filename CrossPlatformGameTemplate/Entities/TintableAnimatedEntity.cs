using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SuperMario.Entities
{
    public abstract class TintableAnimatedEntity : AnimatedEntity
    {
        readonly int animationDelayInTicks;
        long lastGameTime;
        Color currentColor;
        IList<Color> marioColors;
        int index;

        protected TintableAnimatedEntity(Vector2 screenLocation, int animationDelay) : base(screenLocation, animationDelay)
        {
            this.animationDelayInTicks = animationDelay;
            marioColors = new List<Color> { Color.White, Color.DarkOrange, Color.Red, Color.Aqua };
            currentColor = marioColors[0];

        }

        public override void Update(GameTime gameTime)
        {
            if (CurrentSprite == null)
                CurrentSprite = FirstSprite;

            if (lastGameTime == 0)
                lastGameTime = gameTime.TotalGameTime.Ticks;

            if (gameTime.TotalGameTime.Ticks - lastGameTime > animationDelayInTicks)
            {
                lastGameTime = gameTime.TotalGameTime.Ticks;
                CurrentSprite = NextSprite;
                index = marioColors.IndexOf(currentColor);
                currentColor = marioColors[((index + 1) % marioColors.Count)];
                CurrentSprite.Color = currentColor;
            }
        }
    }
}

