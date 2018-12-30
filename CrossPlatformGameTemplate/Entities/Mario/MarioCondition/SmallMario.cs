using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Mario.MarioCondition
{
    public class SmallMario : MarioConditionState
    {
        public SmallMario(IPlayerTexturePack playerTexturePack) : base(playerTexturePack) {}

        public override void ActivateAbility(bool use, Direction direction, GameTime currentGameTime)
        {
            
        }

        protected override Entity RunningLeft
        {
            get
            {
                if (RunningLeftValue == null)
                    RunningLeftValue = new RunningSmallMario(ScreenLocation, TexturePack.RunningLeft);

                RunningLeftValue.SetScreenLocation(ScreenLocation);
                return RunningLeftValue;
            }
        }

        protected override Entity RunningRight
        {
            get
            {
                if (RunningRightValue == null)
                    RunningRightValue = new RunningSmallMario(ScreenLocation, TexturePack.RunningRight);

                RunningRightValue.SetScreenLocation(ScreenLocation);
                return RunningRightValue;
            }
        }

        public override PlayerCondition PlayerConditionType => PlayerCondition.Small;
    }

    public class RunningSmallMario : AnimatedEntity
    {
        Texture2D texture;

        Rectangle currentAnimationRectangle;

        int numberOfFrames = 3;

        public RunningSmallMario(Vector2 screenLocation, Texture2D texture) : base(screenLocation, 1000000)
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
