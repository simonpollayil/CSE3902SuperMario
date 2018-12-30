using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Items
{
    public class GreenMushroom : MovingStaticEntity
    {
        ICollisionHandler itemCollisionHandler;

        public GreenMushroom(Vector2 screenLocation) : base(screenLocation)
        {
            Texture2D greenMushroomTexture = WinterTextureStorage.GreenMushroomSpriteSheetWinter;
            CurrentSprite = new Sprite(greenMushroomTexture, new Rectangle(0, 0, greenMushroomTexture.Width, greenMushroomTexture.Height));
            itemCollisionHandler = new ItemCollisionHandler(this);
            EntityVelocity = new Vector2(1, 0);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move();
            RestrictedMovementDirections.Clear();
        }

        public void Obtain()
        {
            Seppuku();
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
            RestrictedMovementDirections.UnionWith(itemCollisionHandler.Collide(entity, collisions));
        }
    }
}
