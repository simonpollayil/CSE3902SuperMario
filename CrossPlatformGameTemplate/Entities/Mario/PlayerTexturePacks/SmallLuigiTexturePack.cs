using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Mario.PlayerTexturePacks
{
    public class SmallLuigiTexturePack: IPlayerTexturePack
    {
        public Texture2D CrouchingLeft => WinterLuigiTextureStorage.SmallLuigiStandStillLeftWinter;

        public Texture2D CrouchingRight => WinterLuigiTextureStorage.SmallLuigiStandStillRightWinter;

        public Texture2D Dead => WinterLuigiTextureStorage.DeadLuigiWinter;

        public Texture2D FacingLeft => WinterLuigiTextureStorage.SmallLuigiStandStillLeftWinter;

        public Texture2D FacingRight => WinterLuigiTextureStorage.SmallLuigiStandStillRightWinter;

        public Texture2D JumpingLeft => WinterLuigiTextureStorage.SmallLuigiJumpingLeftWinter;

        public Texture2D JumpingRight => WinterLuigiTextureStorage.SmallLuigiJumpingRightWinter;

        public Texture2D RunningLeft => WinterLuigiTextureStorage.SmallLuigiLeftMoveWinter;

        public Texture2D RunningRight => WinterLuigiTextureStorage.SmallLuigiRightMoveWinter;
    }
}
