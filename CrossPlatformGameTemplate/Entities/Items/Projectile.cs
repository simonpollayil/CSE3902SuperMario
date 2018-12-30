using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Collision;
using SuperMario.Sound;

namespace SuperMario.Entities.Items
{
    public class Projectile : AnimatedEntity
    {
        Texture2D projectileTexture;
        int currentX;
        IList<Direction> restrictedMovementDirection = new List<Direction>();
        public int Velocity { get; set; } = 5;
        Direction direction;
        ICollisionHandler projectileColliderHandler;
        List<Direction> restrictedMovementDirections = new List<Direction>();
        long initialGameTimeInTicks;
        int deathDelayInTicks = 30000000;
        int numberOfFrames = 8;

        public Projectile(Vector2 screenLocation, Direction direction) : base(screenLocation, 700000)
        {
            projectileTexture = WinterTextureStorage.FlowerSpriteSheetWinter;
            this.direction = direction;
            projectileColliderHandler = new FireballCollisionHandler(this);
        }
    
        public override ISprite FirstSprite => new Sprite(projectileTexture, new Rectangle(0, 0, projectileTexture.Width / numberOfFrames, projectileTexture.Height));

        public override ISprite NextSprite
        {
            get
            {
                currentX += projectileTexture.Width / numberOfFrames;
                if (currentX == projectileTexture.Width)
                    currentX = 0;

                return new Sprite(projectileTexture, new Rectangle(currentX, 0, projectileTexture.Width / numberOfFrames, projectileTexture.Height));
            }
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
            restrictedMovementDirections.AddRange(projectileColliderHandler.Collide(entity, collisions));
        }

        public override void Update(GameTime gameTime)
        {
            if (initialGameTimeInTicks <= 0)
            {
                initialGameTimeInTicks = gameTime.TotalGameTime.Ticks;
                SoundEffects.Instance.PlayFireball();
            }

            if (direction.Equals(Direction.Right) || direction.Equals(Direction.IdleRight ))
                ScreenLocation = new Vector2(ScreenLocation.X + Velocity, ScreenLocation.Y);
            else if (direction.Equals(Direction.Left) || direction.Equals(Direction.IdleLeft))
                ScreenLocation = new Vector2(ScreenLocation.X - Velocity, ScreenLocation.Y);
            else
                ScreenLocation = new Vector2(ScreenLocation.X + Velocity, ScreenLocation.Y);

            base.Update(gameTime);

            restrictedMovementDirection.Clear();

            if (gameTime.TotalGameTime.Ticks - initialGameTimeInTicks > deathDelayInTicks)
                Hit();
        }

        public void Hit()
        {
            SoundEffects.Instance.PlayBump();
            Seppuku();
        }
    }
}
