using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities
{
    public abstract class StaticEntity : Entity
    {
        protected StaticEntity(Vector2 screenLocation) : base(screenLocation)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (CurrentSprite != null)
                CurrentSprite.Draw(ScreenLocation, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
