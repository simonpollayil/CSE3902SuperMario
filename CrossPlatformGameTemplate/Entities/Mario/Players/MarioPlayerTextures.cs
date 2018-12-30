namespace SuperMario.Entities.Mario.PlayerTexturePacks
{
    public class MarioPlayerTextures : IPlayerTexture
    {
        public IPlayerTexturePack FirePlayer => new FirePlayerTexturePack();
        public IPlayerTexturePack SmallPlayer => new SmallMarioTexturePack();
        public IPlayerTexturePack SuperPlayer => new SuperMarioTexturePack();
    }
}
