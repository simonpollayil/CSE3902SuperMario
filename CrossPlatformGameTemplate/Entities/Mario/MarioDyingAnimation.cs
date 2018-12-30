using Microsoft.Xna.Framework;
using SuperMario.Desktop;
using SuperMario.Entities.Mario.CentralizedLifeSystem;
using SuperMario.Entities.Mario.MarioCondition;
using static SuperMario.Entities.Mario.MarioStateEnum;

namespace SuperMario.Entities.Mario
{
    public class MarioDyingAnimation
    {
        MarioEntity mario;
        Vector2 marioOriginLocation;

        float marioYVelocity = 3.0f;
        float marioTotalYUpMovement;
        float marioMaxTotalYUpMovement = 60;

        long startOfDeathTime;
        int deathAnimationTimeLimit = 3;

        public MarioDyingAnimation(MarioEntity mario, Vector2 marioOriginLocation)
        {
            this.mario = mario;
            this.marioOriginLocation = marioOriginLocation;
        }

        public void RunAnimation(GameTime gameTime)
        {
            mario.Grounded = true;
            if (startOfDeathTime <= 0)
                startOfDeathTime = gameTime.TotalGameTime.Seconds;

            if ((gameTime.TotalGameTime.Seconds - startOfDeathTime) <= deathAnimationTimeLimit)
            {
                if (marioTotalYUpMovement <= marioMaxTotalYUpMovement)
                {
                    marioTotalYUpMovement += marioYVelocity;
                    mario.SetScreenLocation(new Vector2(mario.ScreenLocation.X, mario.ScreenLocation.Y - marioYVelocity));
                    mario.CurrentMarioCondition.SetScreenLocation(new Vector2(mario.ScreenLocation.X, mario.ScreenLocation.Y));
                }
                else
                    mario.Grounded = false;
            }
            else if (CentralizedLives.Instance.ReachedNegativeLives())
            {
                Game1.GameOver = true;
            }
            else
            {
                mario.MarioDead = false;
                mario.SetMarioConditionState(PlayerCondition.Small);
                mario.SetScreenLocation(marioOriginLocation);
                mario.CurrentMarioCondition.SetScreenLocation(mario.ScreenLocation);
                mario.SetMarioState(MarioCommands.Stop);
                mario.SetMarioXDirection(Direction.Idle);
                mario.SetMarioYDirection(Direction.Idle);
                mario.Grounded = false;
                if (CentralizedLives.Instance.LifeCount == 0)
                {
                    mario.SetScreenLocation(new Vector2(mario.ScreenLocation.X, mario.ScreenLocation.Y - 400));
                    mario.ToggleUpdate();
                }
            }
        }
    }
}
