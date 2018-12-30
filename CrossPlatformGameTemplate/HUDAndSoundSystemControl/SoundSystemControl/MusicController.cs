using SuperMario.Entities;
using SuperMario.Entities.Mario;
using SuperMario.Sound;

namespace SuperMario.HUDAndSoundSystemControl.SoundSystemControl
{
    public sealed class MusicController
    {
        bool starState;
        bool inUnderground;
        bool deadPlayer;
        bool endGameSequence;
        readonly int hurryTimeInTicks = 1000000000;
        
        static readonly MusicController instance = new MusicController();

        public static MusicController Instance
        {
            get
            {
                return instance;
            }
        }

        MusicController()
        {
            starState = false;
            inUnderground = false;
            deadPlayer = false;
            endGameSequence = false;
        }

        public void UpdateMusic()
        {
            if (!Music.IsMusicStopped())
                return;

            UpdateConditions();
            if (endGameSequence)
                Music.Instance.PlayLevelComplete();
            else if (deadPlayer)
                Music.Instance.PlayDead();
            else if (!IsTimeRunningOut())
            {
                if (starState)
                    Music.Instance.PlayStarman();
                else if (inUnderground)
                    Music.Instance.PlayUnderworld();
                else
                    Music.Instance.PlayMainTheme();
            }
            else
            {
                if (starState)
                    Music.Instance.PlayStarManHurry();
                else if (inUnderground)
                    Music.Instance.PlayUnderworldHurry();
                else
                    Music.Instance.PlayMainThemeHurry();
            }
        }

        void UpdateConditions()
        {
            starState = AreAnyPlayersStarState();
            inUnderground = AreAnyPlayersUnderground();
            deadPlayer = AreAnyPlayersDead();
            endGameSequence = HaveAnyPlayerReachedFlag();
        }

        bool IsTimeRunningOut()
        {
            return HUDController.Instance.TimeInTicks <= hurryTimeInTicks;
        }

        static bool AreAnyPlayersStarState()
        {
            foreach (Entity player in EntityStorage.Instance.PlayerEntityList)
            {
                MarioEntity playerLookingAt = (MarioEntity) player;
                if (playerLookingAt.CurrentConditionIsStarCondition())
                    return true;
            }
            return false;
        }

        static bool AreAnyPlayersUnderground()
        {
            foreach (Entity player in EntityStorage.Instance.PlayerEntityList)
            {
                MarioEntity playerLookingAt = (MarioEntity)player;
                if (playerLookingAt.IsMarioUnderGround())
                    return true;
            }
            return false;
        }

        static bool AreAnyPlayersDead()
        {
            foreach (Entity player in EntityStorage.Instance.PlayerEntityList)
            {
                MarioEntity playerLookingAt = (MarioEntity)player;
                if (playerLookingAt.MarioDead)
                    return true;
            }
            return false;
        }

        static bool HaveAnyPlayerReachedFlag()
        {
            foreach (Entity player in EntityStorage.Instance.PlayerEntityList)
            {
                MarioEntity playerLookingAt = (MarioEntity)player;
                if (playerLookingAt.IsMarioEndGame())
                    return true;
            }
            return false;
        }
    }
}
