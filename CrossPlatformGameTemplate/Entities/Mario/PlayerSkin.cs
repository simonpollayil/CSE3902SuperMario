using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Mario
{
    public enum PlayerSkin
    {
        Mario,
        Luigi
    }

    public interface IPlayerTexturePack
    {
        Texture2D RunningLeft { get; }
        Texture2D RunningRight { get; }
        Texture2D CrouchingLeft { get; }
        Texture2D CrouchingRight { get; }
        Texture2D JumpingLeft { get; }
        Texture2D JumpingRight { get; }
        Texture2D FacingLeft { get; }
        Texture2D FacingRight { get; }
        Texture2D Dead { get; }
    }

    public interface IPlayerTexture
    {
        IPlayerTexturePack SmallPlayer { get; }
        IPlayerTexturePack SuperPlayer { get; }
        IPlayerTexturePack FirePlayer { get; }
    }
}
