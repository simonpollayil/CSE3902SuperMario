using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.BackgroundElements
{
    public static class BackgroundTextureStorage
    {
        public static Texture2D SmallHillTexture { get; private set; }
        public static Texture2D BigHillTexture { get; private set; }
        public static Texture2D SmallBushTexture { get; private set; }
        public static Texture2D MediumBushTexture { get; private set; }
        public static Texture2D BigBushTexture { get; private set; }
        public static Texture2D SmallCloudTexture { get; private set; }
        public static Texture2D MediumCloudTexture { get; private set; }
        public static Texture2D BigCloudTexture { get; private set; }
        public static Texture2D CastleTexture { get; private set; }
        public static Texture2D FlagTexture { get; private set; }
        public static Texture2D FlagpoleTexture { get; private set; }
        public static Texture2D ExitPipeTexture { get; private set; }
        public static Texture2D GameOverTexture { get; private set; }

        public static void LoadAllTextures(ContentManager content)
        {
            SmallHillTexture = content.Load<Texture2D>("BackgroundElements/Hills/smallHill");
            BigHillTexture = content.Load<Texture2D>("BackgroundElements/Hills/bigHill");
            SmallBushTexture = content.Load<Texture2D>("BackgroundElements/Bushes/smallBush");
            MediumBushTexture = content.Load<Texture2D>("BackgroundElements/Bushes/mediumBush");
            BigBushTexture = content.Load<Texture2D>("BackgroundElements/Bushes/bigBush");
            SmallCloudTexture = content.Load<Texture2D>("BackgroundElements/Clouds/smallCloud");
            MediumCloudTexture = content.Load<Texture2D>("BackgroundElements/Clouds/mediumCloud");
            BigCloudTexture = content.Load<Texture2D>("BackgroundElements/Clouds/bigCloud");
            CastleTexture = content.Load<Texture2D>("BackgroundElements/mario-castle");
            FlagTexture = content.Load<Texture2D>("BackgroundElements/mario-flag");
            FlagpoleTexture = content.Load<Texture2D>("BackgroundElements/mario-flagpole");
            ExitPipeTexture = content.Load<Texture2D>("BackgroundElements/mario-underground-pipe");
            GameOverTexture = content.Load<Texture2D>("game-over-screen");
        }
    }
}
