using SuperMario.Entities;
using SuperMario.Entities.Mario;

namespace SuperMario.Commands.MarioCommand
{
    public class ChangeMarioXDirection : ICommand
    {
        Direction marioXDirection;
        int playerIndex;

        public ChangeMarioXDirection(int playerIndex, Direction marioXDirection)
        {
            this.playerIndex = playerIndex;
            this.marioXDirection = marioXDirection;
        }

        public void Execute()
        {
            MarioEntity mario = (MarioEntity)EntityStorage.Instance.PlayerEntityList[playerIndex];
            mario.SetMarioXDirection(marioXDirection);
        }
    }
}