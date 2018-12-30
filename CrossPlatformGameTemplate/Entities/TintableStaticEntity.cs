using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SuperMario.Entities
{
    public abstract class TintableStaticEntity : StaticEntity
    {
        long lastGameTime;
        Color currentColor;
        IList<Color> marioColors;
        int index;
        readonly int animationDelayInTicks;

        protected TintableStaticEntity(Vector2 screenLocation, int animationDelay) : base(screenLocation)
        {
            marioColors = new List<Color> { Color.White, Color.DarkOrange, Color.Red, Color.Aqua };
            currentColor = marioColors[0];
            animationDelayInTicks = animationDelay;
        }

        public override void Update(GameTime gameTime)
        {
            if (lastGameTime == 0)
                lastGameTime = gameTime.TotalGameTime.Ticks;

            if (gameTime.TotalGameTime.Ticks - lastGameTime > animationDelayInTicks)
            {
                lastGameTime = gameTime.TotalGameTime.Ticks;
                index = marioColors.IndexOf(currentColor);
                currentColor = marioColors[((index + 1) % marioColors.Count)];
                CurrentSprite.Color = currentColor;
            }
        }
    }
}
