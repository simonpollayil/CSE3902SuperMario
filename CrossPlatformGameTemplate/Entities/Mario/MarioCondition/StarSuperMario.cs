using Microsoft.Xna.Framework;

namespace SuperMario.Entities.Mario.MarioCondition
{
    public class StarSuperMario : StarMario
    {
        public StarSuperMario(IPlayerTexturePack playerTexturePack) : base(playerTexturePack) { }

        public override PlayerCondition PlayerConditionType => PlayerCondition.StarSuper;

        public override void ActivateAbility(bool use, Direction direction, GameTime currentGameTime)
        {
            var RunningRight = (AnimatedEntity)this.RunningRight;
            var RunningLeft = (AnimatedEntity)this.RunningLeft;
            if (use)
            {
                RunningLeft.AnimationDelayInTicks = 500000;
                RunningRight.AnimationDelayInTicks = 500000;
            }
            else
            {
                RunningLeft.AnimationDelayInTicks = 1000000;
                RunningRight.AnimationDelayInTicks = 1000000;
            }
        }
    }
}

