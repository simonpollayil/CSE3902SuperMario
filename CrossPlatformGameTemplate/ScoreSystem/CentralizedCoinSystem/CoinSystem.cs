using SuperMario.Entities.Mario.CentralizedLifeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.ScoreSystem.CentralizedCoinSystem
{
    public sealed class CoinSystem
    {
        public int coinCount { get; private set; }

        static readonly CoinSystem instance = new CoinSystem();

        public static CoinSystem Instance
        {
            get
            {
                return instance;
            }
        }

        private CoinSystem()
        {
            coinCount = 0;
        }

        public void IncrementCoinCount()
        {
            coinCount++;
            if ( coinCount >= 100)
            {
                coinCount = 0;
                CentralizedLives.Instance.GainOneLife();
            }
        }
        
        public void ResetCoinCount()
        {
            coinCount = 0;
        }
    }
}
