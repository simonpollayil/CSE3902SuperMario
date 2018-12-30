using SuperMario.Entities.Mario.CentralizedLifeSystem;
using SuperMario.ScoreSystem.CentralSystems;
using SuperMario.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.ScoreSystem
{
    public sealed class ScoreKeeper
    {
        int chain;
        public long Score { get; private set; }
        public static int CoinCount => CoinSystem.Instance.CoinCount;
        public static int LifeCount => CentralizedLives.Instance.LifeCount;

        static readonly ScoreKeeper instance = new ScoreKeeper();

        public static ScoreKeeper Instance
        {
            get
            {
                return instance;
            }
        }

        private ScoreKeeper()
        {
            Score = 0;
            chain = 0;
        }

        public long IncrementScore()
        {
            long oldScore = Score;
            switch (chain)
            {
                case 0:
                    Score += 100;
                    break;
                case 1:
                    Score += 200;
                    break;
                case 2:
                    Score += 400;
                    break;
                case 3:
                    Score += 500;
                    break;
                case 4:
                    Score += 800;
                    break;
                case 5:
                    Score += 1000;
                    break;
                case 6:
                    Score += 2000;
                    break;
                case 7:
                    Score += 4000;
                    break;
                case 8:
                    Score += 5000;
                    break;
                case 9:
                    Score += 8000;
                    break;
                default:
                    CentralizedLives.Instance.GainOneLife();
                    SoundEffects.Instance.PlayOneUp();
                    break;
            }

            return (Score - oldScore);
        }

        public void IncrementScoreBlockBreak()
        {
            Score += 50;
        }

        public void IncrementScoreGetPowerUp()
        {
            Score += 1000;
        }

        public void IncrementScorePointsForSecondsLeft(int seconds)
        {
            Score += (50 * seconds);
        }

        public void ChainIncrement()
        {
            chain++;
        }

        public void ChainReset()
        {
            chain = 0;
        }

        public void ResetScore()
        {
            Score = 0;
            CoinSystem.Instance.ResetCoinCounter();
        }
    }
}
