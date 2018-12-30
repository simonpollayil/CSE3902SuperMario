using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace SuperMario.Sound
{
    public sealed class SoundEffects
    {
        float masterVolume = 0.5f;
        private static readonly SoundEffects instance = new SoundEffects();

        public static SoundEffects Instance
        {
            get
            {
                return instance;
            }
        }

        public IList<SoundEffect> SoundEffectsList { get; } = new List<SoundEffect>();

        private SoundEffects()
        {
            SoundEffectsList.Add(SoundStorage.OneUp);
            SoundEffectsList.Add(SoundStorage.BreakBlock);
            SoundEffectsList.Add(SoundStorage.Coin);
            SoundEffectsList.Add(SoundStorage.Fireball);
            SoundEffectsList.Add(SoundStorage.Flagpole);
            SoundEffectsList.Add(SoundStorage.Jump);
            SoundEffectsList.Add(SoundStorage.Pause);
            SoundEffectsList.Add(SoundStorage.Pipe);
            SoundEffectsList.Add(SoundStorage.PowerUp);
            SoundEffectsList.Add(SoundStorage.PowerUpAppear);
            SoundEffectsList.Add(SoundStorage.Stomp);
            SoundEffectsList.Add(SoundStorage.Bump);
            SoundEffect.MasterVolume = masterVolume;
        }
        public void PlayOneUp()
        {
            SoundEffectsList[0].CreateInstance().Play();
        }

        public void PlayBreakBlock()
        {
            SoundEffectsList[1].CreateInstance().Play();
        }

        public void PlayCoin()
        {
            SoundEffectsList[2].CreateInstance().Play();
        }

        public void PlayFireball()
        {
            SoundEffectsList[3].CreateInstance().Play();
        }

        public void PlayFlagpole()
        {
            SoundEffectsList[4].CreateInstance().Play();
        }

        public void PlayJump()
        {
            SoundEffectsList[5].CreateInstance().Play();
        }

        public void PlayPause()
        {
            SoundEffectsList[6].CreateInstance().Play();
        }

        public void PlayPipe()
        {
            SoundEffectsList[7].CreateInstance().Play();
        }

        public void PlayPowerUp()
        {
            SoundEffectsList[8].CreateInstance().Play();
        }

        public void PlayPowerUpAppear()
        {
            SoundEffectsList[9].CreateInstance().Play();
        }

        public void PlayStomp()
        {
            SoundEffectsList[10].CreateInstance().Play();
        }

        public void PlayBump()
        {
            SoundEffectsList[11].CreateInstance().Play();
        }

    }
}
