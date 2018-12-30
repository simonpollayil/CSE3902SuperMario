using SuperLuigi.Entities.Mario.PlayerTexturePacks;

namespace SuperMario.Entities.Mario.PlayerTexturePacks
{
    public class LuigiPlayerTextures : IPlayerTexture
    {
        public IPlayerTexturePack FirePlayer => new FirePlayerTexturePack();
        public IPlayerTexturePack SmallPlayer => new SmallLuigiTexturePack();
        public IPlayerTexturePack SuperPlayer => new SuperLuigiTexturePack();
    }
}
