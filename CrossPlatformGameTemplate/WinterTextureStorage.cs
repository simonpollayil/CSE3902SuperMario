using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace SuperMario
{
    public static class WinterTextureStorage
    {
        public static void LoadAllTextures(ContentManager content, GraphicsDevice graphicsDevice)
        {
            // Create border and Invisible Block textures
            BorderWinter = new Texture2D(graphicsDevice, 4, graphicsDevice.Viewport.Height);
            BorderWinter.SetData(Enumerable.Repeat(Color.White, 4 * graphicsDevice.Viewport.Height).ToArray());
            InvisbleBlockWinter = new Texture2D(graphicsDevice, 16, 16);
            InvisbleBlockWinter.SetData(Enumerable.Repeat(Color.Transparent, 16 * 16).ToArray());
            ShinyBlockSpriteSheetWinter = content.Load<Texture2D>("WinterSkin/BlockWinterSprites/mario-shiny-block-winter");
            HitBlockSpriteSheetWinter = content.Load<Texture2D>("WinterSkin/BlockWinterSprites/mario-hit-block-winter");
            GravelBlockSpriteSheetWinter = content.Load<Texture2D>("WinterSkin/BlockWinterSprites/mario-gravel-blocks-winter");
            BrickBlockSpriteSheetWinter = content.Load<Texture2D>("WinterSkin/BlockWinterSprites/mario-brick-blocks-winter");
            QuestionBlockSpriteSheetWinter = content.Load<Texture2D>("WinterSkin/BlockWinterSprites/mario-question-blocks-winter");
            GoombaSpriteSheetWinter = content.Load<Texture2D>("WinterSkin/EnemyAndItemWinterSprites/goombaWinter");
            KoopaTroopaSpriteSheetWinter = content.Load<Texture2D>("WinterSkin/EnemyAndItemWinterSprites/koopaWinter");
            CoinSpriteSheetWinter = content.Load<Texture2D>("WinterSkin/EnemyAndItemWinterSprites/coinWinter");
            FlowerSpriteSheetWinter = content.Load<Texture2D>("WinterSkin/EnemyAndItemWinterSprites/flowerWinter");
            GreenMushroomSpriteSheetWinter = content.Load<Texture2D>("WinterSkin/EnemyAndItemWinterSprites/greenMushroomWinter");
            PipeSpriteSheetWinter = content.Load<Texture2D>("WinterSkin/EnemyAndItemWinterSprites/PipeSpriteSheetWinter");
            RedMushroomSpriteSheetWinter = content.Load<Texture2D>("WinterSkin/EnemyAndItemWinterSprites/redMushroomWinter");
            StarSpriteSheetWinter = content.Load<Texture2D>("WinterSkin/EnemyAndItemWinterSprites/starWinter");
            DeadKoopaWinter = content.Load<Texture2D>("WinterSkin/EnemyAndItemWinterSprites/deadKoopaWinter");
            DeadGoombaWinter = content.Load<Texture2D>("WinterSkin/EnemyAndItemWinterSprites/deadGoombaWinter");
            RightFacingKoopaWinter = content.Load<Texture2D>("WinterSkin/EnemyAndItemWinterSprites/RightFacingKoopaWinter");
        }

        public static Texture2D BorderWinter { get; private set; }
        public static Texture2D InvisbleBlockWinter { get; private set; }
        public static Texture2D ShinyBlockSpriteSheetWinter { get; private set; }
        public static Texture2D HitBlockSpriteSheetWinter { get; private set; }
        public static Texture2D GravelBlockSpriteSheetWinter { get; private set; }
        public static Texture2D BrickBlockSpriteSheetWinter { get; private set; }
        public static Texture2D QuestionBlockSpriteSheetWinter { get; private set; }
        public static Texture2D GoombaSpriteSheetWinter { get; private set; }
        public static Texture2D KoopaTroopaSpriteSheetWinter { get; private set; }
        public static Texture2D CoinSpriteSheetWinter { get; private set; }
        public static Texture2D FlowerSpriteSheetWinter { get; private set; }
        public static Texture2D GreenMushroomSpriteSheetWinter { get; private set; }
        public static Texture2D PipeSpriteSheetWinter { get; private set; }
        public static Texture2D RedMushroomSpriteSheetWinter { get; private set; }
        public static Texture2D StarSpriteSheetWinter { get; private set; }
        public static Texture2D DeadGoombaWinter { get; private set; }
        public static Texture2D RightFacingKoopaWinter { get; private set; }
        public static Texture2D DeadKoopaWinter { get; private set; }

    }
}
