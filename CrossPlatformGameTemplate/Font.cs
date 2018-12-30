using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public static class FontManager
    {
        public static SpriteFont ScoreFont { get; private set; }

        public static void SetScoreFont(SpriteFont spriteFont)
        {
            ScoreFont = spriteFont;
        }
    }
}
