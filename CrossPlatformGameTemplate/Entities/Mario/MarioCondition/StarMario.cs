using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Collision;

namespace SuperMario.Entities.Mario.MarioCondition
{
    public abstract class StarMario : MarioConditionState
    {
        protected StarMario(IPlayerTexturePack playerTexturePack) : base(playerTexturePack) {}

        Entity CrouchLeft;
        Entity CrouchRight;
        Entity JumpLeft;
        Entity JumpRight;
        Entity StandLeft;
        Entity StandRight;

        protected override Entity CrouchingLeft
        {
            get
            {
                if (CrouchLeft == null)
                    CrouchLeft = new StaticTintableMarioEntity(ScreenLocation, TexturePack.CrouchingLeft, new Rectangle(0, 0, TexturePack.CrouchingLeft.Width, TexturePack.CrouchingLeft.Height));
                CrouchLeft.SetScreenLocation(ScreenLocation);

                return CrouchLeft;
            }
        }

        protected override Entity CrouchingRight
        {
            get
            {
                if (CrouchRight == null)
                    CrouchRight = new StaticTintableMarioEntity(ScreenLocation, TexturePack.CrouchingRight, new Rectangle(0, 0, TexturePack.CrouchingRight.Width, TexturePack.CrouchingRight.Height));

                CrouchRight.SetScreenLocation(ScreenLocation);
                return CrouchRight;
            }
        }

        protected override Entity JumpingLeft
        {
            get
            {
                if (JumpLeft == null)
                    JumpLeft = new StaticTintableMarioEntity(ScreenLocation, TexturePack.JumpingLeft, new Rectangle(0, 0, TexturePack.JumpingLeft.Width, TexturePack.JumpingLeft.Height));

                JumpLeft.SetScreenLocation(ScreenLocation);
                return JumpLeft;
            }
        }

        protected override Entity JumpingRight
        {
            get
            {
                if (JumpRight == null)
                    JumpRight = new StaticTintableMarioEntity(ScreenLocation, TexturePack.JumpingRight, new Rectangle(0, 0, TexturePack.JumpingRight.Width, TexturePack.JumpingRight.Height));

                JumpRight.SetScreenLocation(ScreenLocation);
                return JumpRight;
            }
        }

        protected override Entity RunningLeft
        {
            get
            {
                if (RunningLeftValue == null)
                    RunningLeftValue = new RunningTintedMario(ScreenLocation, TexturePack.RunningLeft);

                RunningLeftValue.SetScreenLocation(ScreenLocation);
                return RunningLeftValue;
            }
        }

        protected override Entity RunningRight
        {
            get
            {
                if (RunningRightValue == null)
                    RunningRightValue = new RunningTintedMario(ScreenLocation, TexturePack.RunningRight);

                RunningRightValue.SetScreenLocation(ScreenLocation);
                return RunningRightValue;
            }
        }

        protected override Entity StandingLeft
        {
            get
            {
                if (StandLeft == null)
                    StandLeft = new StaticTintableMarioEntity(ScreenLocation, TexturePack.FacingLeft, new Rectangle(0, 0, TexturePack.FacingLeft.Width, TexturePack.FacingLeft.Height));

                StandLeft.SetScreenLocation(ScreenLocation);
                return StandLeft;
            }
        }

        protected override Entity StandingRight
        {
            get
            {
                if (StandRight == null)
                    StandRight = new StaticTintableMarioEntity(ScreenLocation, TexturePack.FacingRight, new Rectangle(0, 0, TexturePack.FacingRight.Width, TexturePack.FacingRight.Height));

                StandRight.SetScreenLocation(ScreenLocation);
                return StandRight;
            }
        }
    }

    public class RunningTintedMario : TintableAnimatedEntity
    {
        Texture2D texture;

        Rectangle currentAnimationRectangle;

        int numberOfFrames = 3;

        public RunningTintedMario(Vector2 screenLocation, Texture2D texture) : base(screenLocation, 2000000)
        {
            this.texture = texture;
            currentAnimationRectangle = new Rectangle(0, 0, texture.Width / numberOfFrames, texture.Height);
        }

        public override ISprite FirstSprite => new TintableSprite(texture, new Rectangle(0, 0, texture.Width / numberOfFrames, texture.Height));

        public override ISprite NextSprite
        {
            get
            {
                currentAnimationRectangle.X += texture.Width / numberOfFrames;
                if (currentAnimationRectangle.X == texture.Width)
                    currentAnimationRectangle.X = 0;

                return new TintableSprite(texture, currentAnimationRectangle);
            }
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }
}
