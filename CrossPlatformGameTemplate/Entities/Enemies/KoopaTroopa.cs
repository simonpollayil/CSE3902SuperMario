using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using SuperMario.Sound;

namespace SuperMario.Entities.Enemies
{
    public class KoopaTroopa : MovingAnimatedEntity , IEnemy
    {
        bool shellHit;
        bool shellState;
        Texture2D koopaTexture;
        Texture2D koopaRightTexture;
        Texture2D koopaDeadTexture;
        int spriteHeightDifference;
        int currentX;
        GameTime currentGameTime;
        long shellGameTime;
        readonly long shellMaxTime = 7;
        ICollisionHandler enemyCollisionHandler;

        int numberOfFrames = 2;

        public KoopaTroopa(Vector2 screenLocation) : base(screenLocation, 2000000)
        {
            koopaTexture = WinterTextureStorage.KoopaTroopaSpriteSheetWinter;

            enemyCollisionHandler = new EnemyCollisionHandler(this);
            koopaTexture = WinterTextureStorage.KoopaTroopaSpriteSheetWinter;
            koopaRightTexture = WinterTextureStorage.RightFacingKoopaWinter;
            koopaDeadTexture = WinterTextureStorage.DeadKoopaWinter;
            spriteHeightDifference = koopaTexture.Height - koopaDeadTexture.Height;
            EntityVelocity = new Vector2(1, 0);
        }

        public override ISprite FirstSprite => new Sprite(koopaTexture, new Rectangle(0, 0, koopaTexture.Width / numberOfFrames, koopaTexture.Height));

        public override ISprite NextSprite
        {
            get
            {
                if (!shellState)
                {
                    currentX += koopaTexture.Width / numberOfFrames;
                    if (currentX == koopaTexture.Width)
                        currentX = 0;

                    if (EntityXDirection == Direction.Right)
                        return new Sprite(koopaRightTexture, new Rectangle(currentX, 0, koopaTexture.Width / numberOfFrames, koopaTexture.Height));

                    return new Sprite(koopaTexture, new Rectangle(currentX, 0, koopaTexture.Width / numberOfFrames, koopaTexture.Height));
                }
                    
                return new Sprite(koopaDeadTexture, new Rectangle(0, 0, koopaDeadTexture.Width, koopaDeadTexture.Height));
            }
        }

        public override void Update(GameTime gameTime)
        {
            currentGameTime = gameTime;
            base.Update(gameTime);

            if (shellState && !shellHit && gameTime.TotalGameTime.Seconds - shellGameTime > shellMaxTime)
            {
                ScreenLocation = new Vector2(ScreenLocation.X, ScreenLocation.Y - spriteHeightDifference);
                EntityXDirection = Direction.Left;
                shellState = false;
            }

            Move();
            RestrictedMovementDirections.Clear();
        }

        public void Hit()
        {
            shellState = true;
            shellGameTime = currentGameTime.TotalGameTime.Seconds;
            EntityXDirection = Direction.Idle;

            SoundEffects.Instance.PlayStomp();
        }

        public void ShellHit(Direction moveDirection)
        {
            float offsetShellLocation = 3;
            shellHit = true;

            if (moveDirection.Equals(Direction.Left))
                ScreenLocation = new Vector2(ScreenLocation.X - offsetShellLocation, ScreenLocation.Y);
            else if (moveDirection.Equals(Direction.Right))
                ScreenLocation = new Vector2(ScreenLocation.X + offsetShellLocation, ScreenLocation.Y);
            else
            {
                shellHit = false;
                shellGameTime = currentGameTime.TotalGameTime.Seconds;
            }

            EntityXDirection = moveDirection;
        }

        public bool IsShellHit()
        {
            return shellHit;
        }

        public bool IsShellState()
        {
            return shellState;
        }

        protected override void Move()
        {
            if (shellHit || !shellState)
            {
                int shellSpeed = 3;

                if (shellHit && EntityVelocity.X != shellSpeed)
                    EntityVelocity = new Vector2(shellSpeed, EntityVelocity.Y);
                else if (!shellState && EntityVelocity.X == shellSpeed)
                    EntityVelocity = new Vector2(1, EntityVelocity.Y);

                base.Move();
            }
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
            RestrictedMovementDirections.UnionWith(enemyCollisionHandler.Collide(entity, collisions));
        }
    }
}
