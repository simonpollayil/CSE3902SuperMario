using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using SuperMario.Sound;

namespace SuperMario.Entities.Items
{
    public class RedMushroom : MovingStaticEntity
    {
        ICollisionHandler itemCollisionHandler;

        public RedMushroom(Vector2 screenLocation) : base(screenLocation)
        {
            Texture2D redMushroomTexture = WinterTextureStorage.RedMushroomSpriteSheetWinter;
            CurrentSprite = new Sprite(redMushroomTexture, new Rectangle(0, 0, redMushroomTexture.Width, redMushroomTexture.Height));
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
            SoundEffects.Instance.PlayPowerUp();
            Seppuku();
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
            RestrictedMovementDirections.UnionWith(itemCollisionHandler.Collide(entity, collisions));
        }
    }
}
