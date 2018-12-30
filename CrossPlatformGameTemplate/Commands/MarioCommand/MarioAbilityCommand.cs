using SuperMario.Desktop;
using SuperMario.Entities.Mario;

namespace SuperMario.Commands.MarioCommand
{
    class MarioAbilityCommand : ICommand
    {
        bool use;
        int playerIndex;

        public MarioAbilityCommand (int playerIndex, bool pressed)
        {
            use = pressed;
            this.playerIndex = playerIndex;
        }

        public void Execute()
        {
            MarioEntity mario = (MarioEntity)EntityStorage.Instance.PlayerEntityList[playerIndex];
            mario.ActivateAbility(use);
        }
    }
}
