using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Mario
{
    public static class LuigiTextureStorage
    {
        public static Texture2D SmallLuigiLeftMove { get; private set; }
        public static Texture2D SmallLuigiRightMove { get; private set; }
        public static Texture2D SmallLuigiStandStillLeft { get; private set; }
        public static Texture2D SmallLuigiStandStillRight { get; private set; }
        public static Texture2D SmallLuigiJumpingLeft { get; private set; }
        public static Texture2D SmallLuigiJumpingRight { get; private set; }

        public static Texture2D SuperLuigiLeftMove { get; private set; }
        public static Texture2D SuperLuigiRightMove { get; private set; }
        public static Texture2D SuperLuigiStandStillLeft { get; private set; }
        public static Texture2D SuperLuigiStandStillRight { get; private set; }
        public static Texture2D SuperLuigiCrouchedRight { get; private set; }
        public static Texture2D SuperLuigiCrouchedLeft { get; private set; }
        public static Texture2D SuperLuigiJumpingLeft { get; private set; }
        public static Texture2D SuperLuigiJumpingRight { get; private set; }

        public static Texture2D DeadLuigi { get; private set; }

        public static void LoadAllTextures(ContentManager content)
        {
            SmallLuigiLeftMove = content.Load<Texture2D>("LuigiSprites/lu-rl");
            SmallLuigiRightMove = content.Load<Texture2D>("LuigiSprites/lu-rr");
            SmallLuigiStandStillLeft = content.Load<Texture2D>("LuigiSprites/lu-fl");
            SmallLuigiStandStillRight = content.Load<Texture2D>("LuigiSprites/lu-fr");
            SmallLuigiJumpingLeft = content.Load<Texture2D>("LuigiSprites/lu-jl");
            SmallLuigiJumpingRight = content.Load<Texture2D>("LuigiSprites/lu-jr");

            SuperLuigiLeftMove = content.Load<Texture2D>("LuigiSprites/lu-su-rl");
            SuperLuigiRightMove = content.Load<Texture2D>("LuigiSprites/lu-su-rr");
            SuperLuigiStandStillLeft = content.Load<Texture2D>("LuigiSprites/lu-su-fl");
            SuperLuigiStandStillRight = content.Load<Texture2D>("LuigiSprites/lu-su-fr");
            SuperLuigiCrouchedLeft = content.Load<Texture2D>("LuigiSprites/lu-su-cl");
            SuperLuigiCrouchedRight = content.Load<Texture2D>("LuigiSprites/lu-su-cr");
            SuperLuigiJumpingLeft = content.Load<Texture2D>("LuigiSprites/lu-su-jl");
            SuperLuigiJumpingRight = content.Load<Texture2D>("LuigiSprites/lu-su-jr");

            DeadLuigi = content.Load<Texture2D>("LuigiSprites/lu-dead");
        }
    }
}
