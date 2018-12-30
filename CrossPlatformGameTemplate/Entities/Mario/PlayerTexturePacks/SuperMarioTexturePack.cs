using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Mario.PlayerTexturePacks
{
    public class SuperMarioTexturePack : IPlayerTexturePack
    {
        public Texture2D CrouchingLeft => WinterMarioTextureStorage.WinterSuperMarioCrouchedLeft;

        public Texture2D CrouchingRight => WinterMarioTextureStorage.WinterSuperMarioCrouchedRight;

        public Texture2D Dead => WinterMarioTextureStorage.WinterDeadMario;

        public Texture2D FacingLeft => WinterMarioTextureStorage.WinterSuperMarioStandStillLeft;

        public Texture2D FacingRight => WinterMarioTextureStorage.WinterSuperMarioStandStillRight;

        public Texture2D JumpingLeft => WinterMarioTextureStorage.WinterSuperMarioJumpingLeft;

        public Texture2D JumpingRight => WinterMarioTextureStorage.WinterSuperMarioJumpingRight;

        public Texture2D RunningLeft => WinterMarioTextureStorage.WinterSuperMarioLeftMove;

        public Texture2D RunningRight => WinterMarioTextureStorage.WinterSuperMarioRightMove;
    }
}
