using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Mario.PlayerTexturePacks
{
    public class FirePlayerTexturePack : IPlayerTexturePack
    {
        public Texture2D CrouchingLeft => WinterMarioTextureStorage.WinterFireMarioCrouchedLeft;

        public Texture2D CrouchingRight => WinterMarioTextureStorage.WinterFireMarioCrouchedRight;

        public Texture2D Dead => WinterMarioTextureStorage.WinterDeadMario;

        public Texture2D FacingLeft => WinterMarioTextureStorage.WinterFireMarioStandStillLeft;

        public Texture2D FacingRight => WinterMarioTextureStorage.WinterFireMarioStandStillRight;

        public Texture2D JumpingLeft => WinterMarioTextureStorage.WinterFireMarioJumpingLeft;

        public Texture2D JumpingRight => WinterMarioTextureStorage.WinterFireMarioJumpingRight;

        public Texture2D RunningLeft => WinterMarioTextureStorage.WinterFireMarioLeftMove;

        public Texture2D RunningRight => WinterMarioTextureStorage.WinterFireMarioRightMove;
    }
}
