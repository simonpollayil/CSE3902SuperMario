using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Mario.PlayerTexturePacks
{
    public class SmallMarioTexturePack : IPlayerTexturePack
    {
        public Texture2D CrouchingLeft => WinterMarioTextureStorage.WinterSmallMarioStandStillLeft;

        public Texture2D CrouchingRight => WinterMarioTextureStorage.WinterSmallMarioStandStillRight;

        public Texture2D Dead => WinterMarioTextureStorage.WinterDeadMario;

        public Texture2D FacingLeft => WinterMarioTextureStorage.WinterSmallMarioStandStillLeft;

        public Texture2D FacingRight => WinterMarioTextureStorage.WinterSmallMarioStandStillRight;

        public Texture2D JumpingLeft => WinterMarioTextureStorage.WinterSmallMarioJumpingLeft;

        public Texture2D JumpingRight => WinterMarioTextureStorage.WinterSmallMarioJumpingRight;

        public Texture2D RunningLeft => WinterMarioTextureStorage.WinterSmallMarioLeftMove;

        public Texture2D RunningRight => WinterMarioTextureStorage.WinterSmallMarioRightMove;
    }
}
