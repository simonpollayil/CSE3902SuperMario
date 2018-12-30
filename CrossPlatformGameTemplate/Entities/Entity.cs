using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities
{
    public abstract class Entity
    {
        Rectangle emptyBoundingBox = new Rectangle(-1, -1, -1, -1);
        public Vector2 ScreenLocation { get; set; }
        public ISprite CurrentSprite { get; set; }
        public bool Remove { get; private set; }

        protected Entity(Vector2 screenLocation){
            ScreenLocation = screenLocation;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public void SetScreenLocation(Vector2 screenLocation)
        {
            ScreenLocation = screenLocation;
        }

        protected void Seppuku()
        {
            Remove = true;
        }

        public Rectangle BoundingBox => CurrentSprite != null ? CurrentSprite.GetBoundingBox(ScreenLocation) : emptyBoundingBox;

        public abstract void Collide(Entity entity, RectangleCollisions collisions);
    }
}
