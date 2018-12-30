using Microsoft.Xna.Framework;
using SuperMario.Commands;
using SuperMario.Desktop;
using SuperMario.ScoreSystem;

namespace SuperMario.Entities.Mario
{
    public class MarioEndLevelAnimation
    {
        MarioEntity mario;

        long slideTimeInTicks = 20000000;
        int flagpoleX = 3463;
        int castleDoorLocationX = 3540;
        float marioXSpeed = 1.0f;

        long startOfSlideTime; 

        public MarioEndLevelAnimation(MarioEntity mario, Vector2 startScreenLocation)
        {
            this.mario = mario;

            mario.SetScreenLocation(new Vector2(flagpoleX, startScreenLocation.Y));
            int seconds = (int)(HUDController.Instance.TimeInTicks/ 10000000);
            ScoreKeeper.Instance.IncrementScorePointsForSecondsLeft(seconds);
            Game1.ToggleGameClock();
        }

        public void RunAnimation(GameTime gameTime)
        {
            mario.SetMarioState(MarioStateEnum.MarioCommands.Crouch);
            if (startOfSlideTime <= 0)
                startOfSlideTime = gameTime.TotalGameTime.Ticks;

            if ((gameTime.TotalGameTime.Ticks - startOfSlideTime) > slideTimeInTicks)
            {
                if (mario.ScreenLocation.X < castleDoorLocationX)
                {
                    mario.SetMarioXDirection(Direction.Right);
                    mario.SetMarioState(MarioStateEnum.MarioCommands.MoveRight);
                    mario.SetScreenLocation(new Vector2(mario.ScreenLocation.X + marioXSpeed, mario.ScreenLocation.Y));
                    mario.CurrentMarioCondition.Update(MarioStateEnum.MarioState.MovingRight, gameTime);
                    mario.CurrentSprite = mario.CurrentMarioCondition.CurrentStateSprite;
                }
                else
                {
                    Game1.ToggleGameClock();
                    new ResetInitialStateCommand(Game1.LevelData).Execute();
                }
            }
        }
    }
}
