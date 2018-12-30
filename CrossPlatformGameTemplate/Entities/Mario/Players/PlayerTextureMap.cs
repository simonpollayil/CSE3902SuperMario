using System.Collections.Generic;
using SuperMario.Entities.Mario.PlayerTexturePacks;

namespace SuperMario.Entities.Mario.Players
{
    public static class PlayerTextureMap
    {
        public static IDictionary<PlayerSkin, IPlayerTexture> PlayerTypes { get; } = new Dictionary<PlayerSkin, IPlayerTexture>
        {
            { PlayerSkin.Mario, new MarioPlayerTextures() },
            { PlayerSkin.Luigi, new LuigiPlayerTextures() }
        };
    }
}
