using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static SuperMario.Entities.Mario.MarioStateEnum;

namespace SuperMario.Entities.Mario.MarioCondition
{
    public abstract class MarioConditionState : IMarioCondition
    {
        protected virtual Entity StandingLeft => new StaticMarioEntity(ScreenLocation, TexturePack.FacingLeft, new Rectangle(0, 0, TexturePack.FacingLeft.Width, TexturePack.FacingLeft.Height));
        protected virtual Entity StandingRight => new StaticMarioEntity(ScreenLocation, TexturePack.FacingRight, new Rectangle(0, 0, TexturePack.FacingRight.Width, TexturePack.FacingRight.Height));
        protected abstract Entity RunningRight { get; }
        protected abstract Entity RunningLeft { get; }
        protected virtual Entity CrouchingLeft => new StaticMarioEntity(ScreenLocation, TexturePack.CrouchingLeft, new Rectangle(0, 0, TexturePack.CrouchingLeft.Width, TexturePack.CrouchingLeft.Height));
        protected virtual Entity CrouchingRight => new StaticMarioEntity(ScreenLocation, TexturePack.CrouchingRight, new Rectangle(0, 0, TexturePack.CrouchingRight.Width, TexturePack.CrouchingRight.Height));
        protected virtual Entity JumpingLeft => new StaticMarioEntity(ScreenLocation, TexturePack.JumpingLeft, new Rectangle(0, 0, TexturePack.JumpingLeft.Width, TexturePack.JumpingLeft.Height));
        protected virtual Entity JumpingRight => new StaticMarioEntity(ScreenLocation, TexturePack.JumpingRight, new Rectangle(0, 0, TexturePack.JumpingRight.Width, TexturePack.JumpingRight.Height));
        public Vector2 ScreenLocation { get; set; }
        public ISprite CurrentStateSprite { get; set; }
        public Entity RunningLeftValue { get; set; }
        public Entity RunningRightValue { get; set; }
        public abstract void ActivateAbility(bool use, Direction direction, GameTime currentGameTime);
        public abstract PlayerCondition PlayerConditionType { get; }

        public IPlayerTexturePack TexturePack { get; protected set; }

        protected MarioConditionState(IPlayerTexturePack playerTexturePack)
        {
            TexturePack = playerTexturePack;
        }

        public void Update(MarioState marioState, GameTime gameTime)
        {
            switch (marioState)
            {
                case MarioState.FacingLeft:
                    StandingLeft.Update(gameTime);
                    CurrentStateSprite = StandingLeft.CurrentSprite;
                    break;
                case MarioState.JumpingLeft:
                    JumpingLeft.Update(gameTime);
                    CurrentStateSprite = JumpingLeft.CurrentSprite;
                    break;
                case MarioState.CrouchingLeft:
                    CrouchingLeft.Update(gameTime);
                    CurrentStateSprite = CrouchingLeft.CurrentSprite;
                    break;
                case MarioState.MovingLeft:
                    RunningLeft.Update(gameTime);
                    CurrentStateSprite = RunningLeft.CurrentSprite;
                    break;
                case MarioState.MovingRight:
                    RunningRight.Update(gameTime);
                    CurrentStateSprite = RunningRight.CurrentSprite;
                    break;
                case MarioState.CrouchingRight:
                    CrouchingRight.Update(gameTime);
                    CurrentStateSprite = CrouchingRight.CurrentSprite;
                    break;
                case MarioState.JumpingRight:
                    JumpingRight.Update(gameTime);
                    CurrentStateSprite = JumpingRight.CurrentSprite;
                    break;
                case MarioState.FacingRight:
                    StandingRight.Update(gameTime);
                    CurrentStateSprite = StandingRight.CurrentSprite;
                    break;
            }
        }

        public void SetScreenLocation(Vector2 marioScreenLocation)
        {
            ScreenLocation = marioScreenLocation;
        }
    }

    public class StaticMarioEntity : StaticEntity
    {
        public StaticMarioEntity(Vector2 screenLocation, Texture2D texture, Rectangle sourceRectangle) : base(screenLocation)
        {
            CurrentSprite = new Sprite(texture, sourceRectangle);
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }

    public class StaticTintableMarioEntity : TintableStaticEntity
    {
        public StaticTintableMarioEntity(Vector2 screenLocation, Texture2D texture, Rectangle sourceRectangle) : base(screenLocation, 2000000)
        {
            CurrentSprite = new TintableSprite(texture, sourceRectangle);
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }
}
