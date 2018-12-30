using SuperMario.Sound;

namespace SuperMario.Entities.Mario.CentralizedLifeSystem
{
    public sealed class CentralizedLives
    {
        public int LifeCount { get; private set; }
        bool negativeLifeCount;
        
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
            negativeLifeCount = false;
        }

        public void SetInitialLives(int amountOfLives)
        {
            LifeCount = amountOfLives;
        }

        public bool ReachedNegativeLives()
        {
            return negativeLifeCount;
        }

        public void GainOneLife()
        {
            LifeCount++;
            SoundEffects.Instance.PlayOneUp();
        }

        public void RemoveOneLife()
        {
            LifeCount--;
            if (LifeCount < 0)
            {
                negativeLifeCount = true;
                LifeCount = 0;
            }
        }
    }
}
