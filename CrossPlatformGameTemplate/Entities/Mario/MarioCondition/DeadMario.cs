using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Entities.Mario.MarioCondition;

namespace SuperMario.Entities.Mario
{
    public class DeadMario : MarioConditionState
    {
        int spriteWidth = 15;
        int spriteHeight = 14;

        Texture2D deadTexture;

        public DeadMario(IPlayerTexturePack playerTexturePack) : base(playerTexturePack)
        {
            deadTexture = playerTexturePack.Dead;
        }

        public override void ActivateAbility(bool use, Direction direction, GameTime currentGameTime)
        {
        }

        protected override Entity RunningRight => new StaticMarioEntity(ScreenLocation, deadTexture, new Rectangle(0, 0, spriteWidth, spriteHeight));
        protected override Entity RunningLeft => new StaticMarioEntity(ScreenLocation, deadTexture, new Rectangle(0, 0, spriteWidth, spriteHeight));
        protected override Entity StandingLeft => new StaticMarioEntity(ScreenLocation, deadTexture, new Rectangle(0, 0, spriteWidth, spriteHeight));
        protected override Entity StandingRight => new StaticMarioEntity(ScreenLocation, deadTexture, new Rectangle(0, 0, spriteWidth, spriteHeight));
        protected override Entity CrouchingLeft => new StaticMarioEntity(ScreenLocation, deadTexture, new Rectangle(0, 0, spriteWidth, spriteHeight));
        protected override Entity CrouchingRight => new StaticMarioEntity(ScreenLocation, deadTexture, new Rectangle(0, 0, spriteWidth, spriteHeight));
        protected override Entity JumpingLeft => new StaticMarioEntity(ScreenLocation, deadTexture, new Rectangle(0, 0, spriteWidth, spriteHeight));
        protected override Entity JumpingRight => new StaticMarioEntity(ScreenLocation, deadTexture, new Rectangle(0, 0, spriteWidth, spriteHeight));

        public override PlayerCondition PlayerConditionType => PlayerCondition.Dead;
    }
}
