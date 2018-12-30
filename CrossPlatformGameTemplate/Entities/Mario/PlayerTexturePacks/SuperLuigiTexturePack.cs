using Microsoft.Xna.Framework.Graphics;
using SuperMario.Entities.Mario;

namespace SuperLuigi.Entities.Mario.PlayerTexturePacks
{
    public class SuperLuigiTexturePack : IPlayerTexturePack
    {
        public Texture2D CrouchingLeft => WinterLuigiTextureStorage.SuperLuigiCrouchedLeftWinter;

        public Texture2D CrouchingRight => WinterLuigiTextureStorage.SuperLuigiCrouchedRightWinter;

        public Texture2D Dead => WinterLuigiTextureStorage.DeadLuigiWinter;

        public Texture2D FacingLeft => WinterLuigiTextureStorage.SuperLuigiStandStillLeftWinter;

        public Texture2D FacingRight => WinterLuigiTextureStorage.SuperLuigiStandStillRightWinter;

        public Texture2D JumpingLeft => WinterLuigiTextureStorage.SuperLuigiJumpingLeftWinter;

        public Texture2D JumpingRight => WinterLuigiTextureStorage.SuperLuigiJumpingRightWinter;

        public Texture2D RunningLeft => WinterLuigiTextureStorage.SuperLuigiLeftMoveWinter;

        public Texture2D RunningRight => WinterLuigiTextureStorage.SuperLuigiRightMoveWinter;
    }
}
