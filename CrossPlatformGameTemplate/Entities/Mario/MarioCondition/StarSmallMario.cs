using Microsoft.Xna.Framework;

namespace SuperMario.Entities.Mario.MarioCondition
{
    public class StarSmallMario : StarMario
    {
        public StarSmallMario(IPlayerTexturePack playerTexturePack): base(playerTexturePack) {}

        public override PlayerCondition PlayerConditionType => PlayerCondition.StarSmall;

        public override void ActivateAbility(bool use, Direction direction, GameTime currentGameTime)
        {
            
        }
    }
}
