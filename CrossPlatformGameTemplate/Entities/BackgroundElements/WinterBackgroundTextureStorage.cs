using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.BackgroundElements
{
    public static class WinterBackgroundTextureStorage
    {
        public static Texture2D SmallHillTextureWinter { get; private set; }
        public static Texture2D BigHillTextureWinter { get; private set; }
        public static Texture2D SmallBushTextureWinter { get; private set; }
        public static Texture2D MediumBushTextureWinter { get; private set; }
        public static Texture2D BigBushTextureWinter { get; private set; }
        public static Texture2D SmallCloudTextureWinter { get; private set; }
        public static Texture2D MediumCloudTextureWinter { get; private set; }
        public static Texture2D BigCloudTextureWinter { get; private set; }
        public static Texture2D CastleTextureWinter { get; private set; }
        public static Texture2D FlagTextureWinter { get; private set; }
        public static Texture2D FlagpoleTextureWinter { get; private set; }
        public static Texture2D ExitPipeTextureWinter { get; private set; }
        public static Texture2D GameOverTextureWinter { get; private set; }

        public static void LoadAllTextures(ContentManager content)
        {
            SmallHillTextureWinter = content.Load<Texture2D>("WinterSkin/BackgroundElementsWinterSprites/Hills/smallHillWinter");
            BigHillTextureWinter = content.Load<Texture2D>("WinterSkin/BackgroundElementsWinterSprites/Hills/bigHillWinter");
            SmallBushTextureWinter = content.Load<Texture2D>("WinterSkin/BackgroundElementsWinterSprites/Bushes/smallBushWinter");
            MediumBushTextureWinter = content.Load<Texture2D>("WinterSkin/BackgroundElementsWinterSprites/Bushes/mediumBushWinter");
            BigBushTextureWinter = content.Load<Texture2D>("WinterSkin/BackgroundElementsWinterSprites/Bushes/bigBushWinter");
            SmallCloudTextureWinter = content.Load<Texture2D>("BackgroundElements/Clouds/smallCloud");
            MediumCloudTextureWinter = content.Load<Texture2D>("BackgroundElements/Clouds/mediumCloud");
            BigCloudTextureWinter = content.Load<Texture2D>("BackgroundElements/Clouds/bigCloud");
            CastleTextureWinter = content.Load<Texture2D>("WinterSkin/BackgroundElementsWinterSprites/mario-castle-winter");
            FlagTextureWinter = content.Load<Texture2D>("BackgroundElements/mario-flag");
            FlagpoleTextureWinter = content.Load<Texture2D>("WinterSkin/BackgroundElementsWinterSprites/mario-flagpole-winter");
            ExitPipeTextureWinter = content.Load<Texture2D>("WinterSkin/BackgroundElementsWinterSprites/mario-underground-pipe-winter");
            GameOverTextureWinter = content.Load<Texture2D>("game-over-screen");
        }
    }
}
