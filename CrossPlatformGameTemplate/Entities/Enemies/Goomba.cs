using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Collision;
using SuperMario.Sound;

namespace SuperMario.Entities.Enemies
{
    public class Goomba : MovingAnimatedEntity , IEnemy
    {
        Texture2D goombaTexture;
        Texture2D deadTexture;
        int currentX;
        int squishDelay = 4900000;
        long squishGameTime;
        GameTime currentGameTime;
        bool isSquished;
        bool hit;
        ICollisionHandler enemyCollisionHandler;

        int numberOfFrames = 2;

        public Goomba(Vector2 screenLocation) : base(screenLocation, 2000000)
        {
            isSquished = false;
            goombaTexture = WinterTextureStorage.GoombaSpriteSheetWinter;
            deadTexture = WinterTextureStorage.DeadGoombaWinter;
            enemyCollisionHandler = new EnemyCollisionHandler(this);
            EntityVelocity = new Vector2(1, 0);
        }

        public override ISprite FirstSprite => new Sprite(goombaTexture, new Rectangle(0, 0, goombaTexture.Width / numberOfFrames, goombaTexture.Height));

        public override ISprite NextSprite
        {
            get
            {
                if(!hit) {
                    currentX += goombaTexture.Width / numberOfFrames;
                    if (currentX == goombaTexture.Width)
                        currentX = 0;

                    return new Sprite(goombaTexture, new Rectangle(currentX, 0, goombaTexture.Width / numberOfFrames, goombaTexture.Height));
                }
                else
                {
                    if (isSquished)
                        Seppuku();

                    return new Sprite(deadTexture, new Rectangle(0, 0, deadTexture.Width, deadTexture.Height));
                }
            }
        }
        public override void Update(GameTime gameTime)
        {
            currentGameTime = gameTime;

            if(squishGameTime > 0)
                if (gameTime.TotalGameTime.Ticks - squishGameTime > squishDelay)
                    isSquished = true;

            base.Update(gameTime);

            if (!hit)
                Move();

            RestrictedMovementDirections.Clear();
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
            RestrictedMovementDirections.UnionWith(enemyCollisionHandler.Collide(entity, collisions));
        }

        public void Hit()
        {
            if (!IsHit())
            {
                hit = true;
                SoundEffects.Instance.PlayStomp();
                squishGameTime = currentGameTime.TotalGameTime.Ticks;
            }
        }

        public bool IsHit()
        {
            return hit;
        }
    }
}

