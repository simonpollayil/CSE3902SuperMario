using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities
{
    public abstract class MovingStaticEntity : MovingEntity
    {
        protected MovingStaticEntity(Vector2 screenLocation) : base(screenLocation)
        {
            EntityXDirection = Direction.Right;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (CurrentSprite != null)
                CurrentSprite.Draw(ScreenLocation, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
