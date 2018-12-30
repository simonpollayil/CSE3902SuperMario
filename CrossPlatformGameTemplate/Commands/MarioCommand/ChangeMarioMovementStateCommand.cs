using SuperMario.Entities.Mario;
using static SuperMario.Entities.Mario.MarioStateEnum;

namespace SuperMario.Commands.MarioCommand
{
    public class ChangeMarioMovementStateCommand : ICommand
    {
        MarioCommands marioCommand;
        int playerIndex;

        public ChangeMarioMovementStateCommand(int playerIndex, MarioCommands marioCommand)
        {
            this.playerIndex = playerIndex;
            this.marioCommand = marioCommand;
        }

        public void Execute()
        {
            MarioEntity mario = (MarioEntity)EntityStorage.Instance.PlayerEntityList[playerIndex];
            mario.SetMarioState(marioCommand);
        }
    }
}