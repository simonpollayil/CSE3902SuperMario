using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Mario
{
    public static class WinterLuigiTextureStorage
    {
        public static Texture2D SmallLuigiLeftMoveWinter { get; private set; }
        public static Texture2D SmallLuigiRightMoveWinter { get; private set; }
        public static Texture2D SmallLuigiStandStillLeftWinter { get; private set; }
        public static Texture2D SmallLuigiStandStillRightWinter { get; private set; }
        public static Texture2D SmallLuigiJumpingLeftWinter { get; private set; }
        public static Texture2D SmallLuigiJumpingRightWinter { get; private set; }

        public static Texture2D SuperLuigiLeftMoveWinter { get; private set; }
        public static Texture2D SuperLuigiRightMoveWinter { get; private set; }
        public static Texture2D SuperLuigiStandStillLeftWinter { get; private set; }
        public static Texture2D SuperLuigiStandStillRightWinter { get; private set; }
        public static Texture2D SuperLuigiCrouchedRightWinter { get; private set; }
        public static Texture2D SuperLuigiCrouchedLeftWinter { get; private set; }
        public static Texture2D SuperLuigiJumpingLeftWinter { get; private set; }
        public static Texture2D SuperLuigiJumpingRightWinter { get; private set; }

        public static Texture2D DeadLuigiWinter { get; private set; }

        public static void LoadAllTextures(ContentManager content)
        {
            SmallLuigiLeftMoveWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-rl-winter");
            SmallLuigiRightMoveWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-rr-winter");
            SmallLuigiStandStillLeftWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-fl-winter");
            SmallLuigiStandStillRightWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-fr-winter");
            SmallLuigiJumpingLeftWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-jl-winter");
            SmallLuigiJumpingRightWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-jr-winter");
            SuperLuigiLeftMoveWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-su-rl-winter");
            SuperLuigiRightMoveWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-su-rr-winter");
            SuperLuigiStandStillLeftWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-su-fl-winter");
            SuperLuigiStandStillRightWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-su-fr-winter");
            SuperLuigiCrouchedLeftWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-su-cl-winter");
            SuperLuigiCrouchedRightWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-su-cr-winter");
            SuperLuigiJumpingLeftWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-su-jl-winter");
            SuperLuigiJumpingRightWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-su-jr-winter");
            DeadLuigiWinter = content.Load<Texture2D>("WinterSkin/LuigiWinterSprites/lu-dead-winter");
        }
    }
}
