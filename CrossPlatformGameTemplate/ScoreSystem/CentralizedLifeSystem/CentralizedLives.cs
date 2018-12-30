using SuperMario.Sound;

namespace SuperMario.Entities.Mario.CentralizedLifeSystem
{
    public sealed class CentralizedLives
    {
        public int LifeCount { get; private set; }

        static readonly CentralizedLives instance = new CentralizedLives();

        public static CentralizedLives Instance
        {
            get
            {
                return instance;
            }
        }

        private CentralizedLives()
        {
            LifeCount = 0;
        }

        public void SetInitialLives(int amountOfLives)
        {
            LifeCount = amountOfLives;
        }
        public void GainOneLife()
        {
            LifeCount++;
            SoundEffects.Instance.PlayOneUp();
        }

        public void RemoveOneLife()
        {
            LifeCount--;
        }

    }
}
