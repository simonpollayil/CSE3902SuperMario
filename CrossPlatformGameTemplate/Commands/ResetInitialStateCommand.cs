using SuperMario.Collision;
using SuperMario.Desktop;
using SuperMario.Entities;
using SuperMario.ScoreSystem;
using SuperMario.Sound;

namespace SuperMario.Commands
{
    public class ResetInitialStateCommand : ICommand
    {
        LevelData levelData;

        public ResetInitialStateCommand(LevelData levelData)
        {
            this.levelData = levelData;
        }

        public void Execute()
        {
            HUDController.Instance.ResetTimer();
            ScoreKeeper.Instance.ResetScore();
            MasterCollider.Reset();
            EntityStorage.Instance.PopulateEntityList(levelData);
            Music.StopMusic();
            Game1.GameOver = false;
        }
    }
}
