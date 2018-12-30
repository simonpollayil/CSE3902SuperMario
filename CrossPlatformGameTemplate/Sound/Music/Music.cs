using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace SuperMario.Sound
{
    public sealed class Music
    {
        private static readonly Music instance = new Music();

        public static Music Instance
        {
            get
            {
                return instance;
            }
        }

        public IList<Song> MusicList { get; } = new List<Song>();

        private Music()
        {
            MusicList.Add(SoundStorage.MainTheme);
            MusicList.Add(SoundStorage.MainThemeHurry);
            MusicList.Add(SoundStorage.Underworld);
            MusicList.Add(SoundStorage.LevelComplete);
            MusicList.Add(SoundStorage.Starman);
            MusicList.Add(SoundStorage.StarmanHurry);
            MusicList.Add(SoundStorage.YoureDead);
            MusicList.Add(SoundStorage.GameOver);
            MusicList.Add(SoundStorage.GameOver2);
            MusicList.Add(SoundStorage.UnderworldHurry);
        }

        public void PlayMainTheme()
        {
            MediaPlayer.Play(MusicList[0]);
            MediaPlayer.IsRepeating = true;
        }

        public void PlayMainThemeHurry()
        {
            MediaPlayer.Play(MusicList[1]);
            MediaPlayer.IsRepeating = true;
        }

        public void PlayUnderworld()
        {
            MediaPlayer.Play(MusicList[2]);
            MediaPlayer.IsRepeating = true;
        }

        public void PlayLevelComplete()
        {
            MediaPlayer.Play(MusicList[3]);
            MediaPlayer.IsRepeating = false;
        }

        public void PlayStarman()
        {
            MediaPlayer.Play(MusicList[4]);
            MediaPlayer.IsRepeating = true;
        }

        public void PlayStarManHurry()
        {
            MediaPlayer.Play(MusicList[5]);
            MediaPlayer.IsRepeating = true;
        }

        public void PlayDead()
        {
            MediaPlayer.Play(MusicList[6]);
            MediaPlayer.IsRepeating = false;
        }

        public void PlayGameOver()
        {
            MediaPlayer.Play(MusicList[7]);
            MediaPlayer.IsRepeating = false;
        }

        public void PlayGameOver2()
        {
            MediaPlayer.Play(MusicList[8]);
            MediaPlayer.IsRepeating = false;
        }

        public void PlayUnderworldHurry()
        {
            MediaPlayer.Play(MusicList[9]);
            MediaPlayer.IsRepeating = true;
        }

        public static void PauseMusic()
        {
            MediaPlayer.Pause();
        }

        public static void ResumeMusic()
        {
            MediaPlayer.Resume();
        }

        public static void StopMusic()
        {
            MediaPlayer.Stop();
        }

        public static void Event()
        {
            StopMusic();
        }

        public static bool IsMusicStopped()
        {
           if((MediaPlayer.State == MediaState.Stopped) || (MediaPlayer.State == MediaState.Paused))
                return true;

            return false;
        }
    }
}
