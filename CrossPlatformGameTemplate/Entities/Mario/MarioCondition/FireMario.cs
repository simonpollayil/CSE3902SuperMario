using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Entities.Items;

namespace SuperMario.Entities.Mario.MarioCondition
{
    public class FireMario : MarioConditionState
    {
        long lastGameTimeInTicks;
        int fireProjectileDelayInTicks = 2500000;
        int flowerLimit = 3;

        public FireMario(IPlayerTexturePack playerTexturePack): base(playerTexturePack) {}

        public override void ActivateAbility(bool use, Direction direction, GameTime currentGameTime)
        {
            var projectile = new Projectile(ScreenLocation, direction);
            int projectileCount = 0;

            if (currentGameTime.TotalGameTime.Ticks - lastGameTimeInTicks > fireProjectileDelayInTicks)
            {
                lastGameTimeInTicks = currentGameTime.TotalGameTime.Ticks;
                foreach (Entity item in EntityStorage.Instance.ItemEntityList)
                {
                    if (item is Projectile)
                        projectileCount++;
                }

                if (projectileCount < flowerLimit)
                    EntityStorage.Instance.QueueItemEntity(projectile);
            }
        }

        protected override Entity RunningLeft
        {
            get
            {

                if (RunningLeftValue == null)
                    RunningLeftValue = new RunningFireMario(ScreenLocation, TexturePack.RunningLeft);

                RunningLeftValue.SetScreenLocation(ScreenLocation);
                return RunningLeftValue;
            }
        }

        protected override Entity RunningRight
        {
            get
            {
                if (RunningRightValue == null)
                    RunningRightValue = new RunningFireMario(ScreenLocation, TexturePack.RunningRight);

                RunningRightValue.SetScreenLocation(ScreenLocation);
                return RunningRightValue;
            }
        }

        public override PlayerCondition PlayerConditionType => PlayerCondition.Fire;
    }


    public class RunningFireMario : AnimatedEntity
    {
        Texture2D texture;

        Rectangle currentAnimationRectangle;

        int numberOfFrames = 4;

        public RunningFireMario(Vector2 screenLocation, Texture2D texture) : base(screenLocation, 1000000)
        {
            this.texture = texture;
            currentAnimationRectangle = new Rectangle(0, 0, texture.Width / numberOfFrames, texture.Height);
        }

        public override ISprite FirstSprite => new Sprite(texture, new Rectangle(0, 0, texture.Width / numberOfFrames, texture.Height));

        public override ISprite NextSprite
        {
            get
            {
                currentAnimationRectangle.X += texture.Width / numberOfFrames;
                if (currentAnimationRectangle.X == texture.Width)
                    currentAnimationRectangle.X = 0;

                return new Sprite(texture, currentAnimationRectangle);
            }
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }
}
