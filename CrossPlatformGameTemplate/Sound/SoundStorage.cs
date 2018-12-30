using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace SuperMario.Sound
{
    public static class SoundStorage
    {
        public static void LoadAllSounds(ContentManager content)
        {
            //music
            MainTheme = content.Load<Song>("Audio/Music/MainTheme");
            Underworld = content.Load<Song>("Audio/Music/Underworld");
            Starman = content.Load<Song>("Audio/Music/Starman");
            LevelComplete = content.Load<Song>("Audio/Music/LevelComplete");
            YoureDead = content.Load<Song>("Audio/Music/YoureDead");
            GameOver = content.Load<Song>("Audio/Music/GameOver");
            GameOver2 = content.Load<Song>("Audio/Music/GameOver2");
            MainThemeHurry = content.Load<Song>("Audio/Music/MainThemeHurry");
            StarmanHurry = content.Load<Song>("Audio/Music/StarmanHurry");
            UnderworldHurry = content.Load<Song>("Audio/Music/UnderworldHurry");

            //sound effects
            OneUp = content.Load<SoundEffect>("Audio/Sound Effects/OneUp");
            BreakBlock = content.Load<SoundEffect>("Audio/Sound Effects/BreakBlock");
            Coin = content.Load<SoundEffect>("Audio/Sound Effects/Coin");
            Fireball = content.Load<SoundEffect>("Audio/Sound Effects/Fireball");
            Flagpole = content.Load<SoundEffect>("Audio/Sound Effects/Flagpole");
            Jump = content.Load<SoundEffect>("Audio/Sound Effects/Jump");
            Pause = content.Load<SoundEffect>("Audio/Sound Effects/Pause");
            Pipe = content.Load<SoundEffect>("Audio/Sound Effects/Pipe");
            PowerUp = content.Load<SoundEffect>("Audio/Sound Effects/PowerUp");
            PowerUpAppear = content.Load<SoundEffect>("Audio/Sound Effects/PowerUpAppears");
            Stomp = content.Load<SoundEffect>("Audio/Sound Effects/Stomp");
            Bump = content.Load<SoundEffect>("Audio/Sound Effects/Bump");
        }

        public static Song MainTheme { get; private set; }
        public static Song Underworld { get; private set; }
        public static Song Starman { get; private set; }
        public static Song LevelComplete { get; private set; }
        public static Song YoureDead { get; private set; }
        public static Song GameOver { get; private set; }
        public static Song GameOver2 { get; private set; }
        public static Song MainThemeHurry { get; private set; }
        public static Song StarmanHurry { get; private set; }
        public static Song UnderworldHurry { get; private set; }
        public static SoundEffect BreakBlock { get; private set; }
        public static SoundEffect Coin { get; private set; }
        public static SoundEffect Fireball { get; private set; }
        public static SoundEffect Flagpole { get; private set; }
        public static SoundEffect Jump { get; private set; }
        public static SoundEffect OneUp { get; private set; }
        public static SoundEffect Pause { get; private set; }
        public static SoundEffect Pipe { get; private set; }
        public static SoundEffect PowerUp { get; private set; }
        public static SoundEffect PowerUpAppear { get; private set; }
        public static SoundEffect Stomp { get; private set; }
        public static SoundEffect Bump { get; private set; }
    }
}
