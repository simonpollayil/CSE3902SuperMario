using SuperMario.Desktop;
using SuperMario.Entities.Mario;
using SuperMario.Entities.Mario.MarioCondition;

namespace SuperMario.Commands.MarioCommand
{
    public class ChangeMarioConditionStateCommand : ICommand
    {
        PlayerCondition playerCondition;
        int playerIndex;

        public ChangeMarioConditionStateCommand(int playerIndex, PlayerCondition playerCondition)
        {
            this.playerIndex = playerIndex;
            this.playerCondition = playerCondition;
        }

        public void Execute()
        {
            MarioEntity mario = (MarioEntity)EntityStorage.Instance.PlayerEntityList[playerIndex];
            mario.SetMarioConditionState(playerCondition);
        }
    }
}
