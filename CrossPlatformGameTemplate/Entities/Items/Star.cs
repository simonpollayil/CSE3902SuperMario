using System.Collections.Generic;
using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Sound;

namespace SuperMario.Entities.Items
{
    public class Star : MovingAnimatedEntity
    {
        Texture2D starTexture;
        int currentX;
        int distanceUpFromBounce;
        int upWardVelocity;
        bool goUp;
        ICollisionHandler itemCollisionHandler;

        int numberOfFrames = 4;

        public Star(Vector2 screenLocation) : base(screenLocation, 700000)
        {
            upWardVelocity = -3;
            distanceUpFromBounce = 0;
            goUp = false;
            starTexture = WinterTextureStorage.StarSpriteSheetWinter;
            itemCollisionHandler = new ItemCollisionHandler(this);
            EntityVelocity = new Vector2(1, -3);
        }

        public override ISprite FirstSprite => new Sprite(starTexture, new Rectangle(0, 0, starTexture.Width / numberOfFrames, starTexture.Height));

        public override ISprite NextSprite
        {
            get
            {
                currentX += starTexture.Width / numberOfFrames;
                if (currentX == starTexture.Width)
                    currentX = 0;

                return new Sprite(starTexture, new Rectangle(currentX, 0, starTexture.Width / numberOfFrames, starTexture.Height));
            }
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
            int timeInTicksToPlayHurryMusic = 1000000000;
            if (HUDController.Instance.TimeInTicks>= timeInTicksToPlayHurryMusic)
                Music.Instance.PlayStarman();
            else
                Music.Instance.PlayStarManHurry();
            Seppuku();
        }

        protected override void Move()
        {
            int maxBounceHeight = 48;
            base.Move();

            if (Grounded)
                goUp = true;

            if (!RestrictedMovementDirections.Contains(Direction.Up) && goUp && distanceUpFromBounce <= maxBounceHeight)
            {
                ScreenLocation = new Vector2(ScreenLocation.X, ScreenLocation.Y + EntityVelocity.Y);
                distanceUpFromBounce = distanceUpFromBounce - upWardVelocity;
            }
            else
            {
                goUp = false;
                distanceUpFromBounce = 0;
            }
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
            RestrictedMovementDirections.UnionWith(itemCollisionHandler.Collide(entity, collisions));
        }
    }
}
