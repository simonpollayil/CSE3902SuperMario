using SuperMario.Entities.Mario.CentralizedLifeSystem;
using SuperMario.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.ScoreSystem.CentralSystems
{
    public sealed class CoinSystem
    {
        public int CoinCount { get; private set; }

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
            CoinCount = 0;
        }

        public void GainOneCoin()
        {
            CoinCount++;
            if (CoinCount >= 100) 
            {
                ResetCoinCounter();
                CentralizedLives.Instance.GainOneLife();
            }
        }

        public void ResetCoinCounter()
        {
            CoinCount = 0;
        }
    }
}
