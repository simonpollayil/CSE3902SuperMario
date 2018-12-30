using SuperMario.Entities;
using SuperMario.Entities.Mario;

namespace SuperMario.Commands.MarioCommand
{
    public class ChangeMarioYDirection : ICommand
    {
        Direction marioYDirection;
        int playerIndex;

        public ChangeMarioYDirection(int playerIndex, Direction marioYDirection)
        {
            this.playerIndex = playerIndex;
            this.marioYDirection = marioYDirection;
        }

        public void Execute()
        {
            MarioEntity mario = (MarioEntity)EntityStorage.Instance.PlayerEntityList[playerIndex];
            mario.SetMarioYDirection(marioYDirection);
        }
    }
}