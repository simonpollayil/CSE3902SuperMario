using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace SuperMario
{
    public static class TextureStorage
    {
        public static void LoadAllTextures(ContentManager content, GraphicsDevice graphicsDevice)
        {
            // Create border and Invisible Block textures
            Border = new Texture2D(graphicsDevice, 4, graphicsDevice.Viewport.Height);
            Border.SetData(Enumerable.Repeat(Color.White, 4 * graphicsDevice.Viewport.Height).ToArray());
            InvisbleBlock = new Texture2D(graphicsDevice, 16, 16);
            InvisbleBlock.SetData(Enumerable.Repeat(Color.Transparent, 16 * 16).ToArray());
            ShinyBlockSpriteSheet = content.Load<Texture2D>("BlockSprites/mario-shiny-block");
            HitBlockSpriteSheet = content.Load<Texture2D>("BlockSprites/mario-hit-block");
            GravelBlockSpriteSheet = content.Load<Texture2D>("BlockSprites/mario-gravel-blocks");
            BrickBlockSpriteSheet = content.Load<Texture2D>("BlockSprites/mario-brick-blocks");
            QuestionBlockSpriteSheet = content.Load<Texture2D>("BlockSprites/mario-question-blocks");
            GoombaSpriteSheet = content.Load<Texture2D>("EnemyAndItemSprites/goomba");
            KoopaTroopaSpriteSheet = content.Load<Texture2D>("EnemyAndItemSprites/koopa");
            CoinSpriteSheet = content.Load<Texture2D>("EnemyAndItemSprites/coin");
            FlowerSpriteSheet = content.Load<Texture2D>("EnemyAndItemSprites/flower");
            GreenMushroomSpriteSheet = content.Load<Texture2D>("EnemyAndItemSprites/greenMushroom");
            PipeSpriteSheet = content.Load<Texture2D>("EnemyAndItemSprites/PipeSpriteSheet");
            RedMushroomSpriteSheet = content.Load<Texture2D>("EnemyAndItemSprites/redMushroom");
            StarSpriteSheet = content.Load<Texture2D>("EnemyAndItemSprites/star");
            DeadKoopa = content.Load<Texture2D>("EnemyAndItemSprites/deadKoopa");
            DeadGoomba = content.Load<Texture2D>("EnemyAndItemSprites/deadGoomba");
            RightFacingKoopa = content.Load<Texture2D>("EnemyAndItemSprites/RightFacingKoopa");
        }

        public static Texture2D Border { get; private set; }
        public static Texture2D InvisbleBlock { get; private set; }
        public static Texture2D ShinyBlockSpriteSheet { get; private set; }
        public static Texture2D HitBlockSpriteSheet { get; private set; }
        public static Texture2D GravelBlockSpriteSheet { get; private set; }
        public static Texture2D BrickBlockSpriteSheet { get; private set; }
        public static Texture2D QuestionBlockSpriteSheet { get; private set; }
        public static Texture2D GoombaSpriteSheet { get; private set; }
        public static Texture2D KoopaTroopaSpriteSheet { get; private set; }
        public static Texture2D CoinSpriteSheet { get; private set; }
        public static Texture2D FlowerSpriteSheet { get; private set; }
        public static Texture2D GreenMushroomSpriteSheet { get; private set; }
        public static Texture2D PipeSpriteSheet { get; private set; }
        public static Texture2D RedMushroomSpriteSheet { get; private set; }
        public static Texture2D StarSpriteSheet { get; private set; }
        public static Texture2D DeadGoomba { get; private set; }
        public static Texture2D RightFacingKoopa { get; private set; }
        public static Texture2D DeadKoopa { get; private set; }

    }
}
