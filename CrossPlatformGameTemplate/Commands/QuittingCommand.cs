using SuperMario.Desktop;

namespace SuperMario.Commands
{
    public class QuittingCommand : ICommand
    {
        readonly Game1 game;
        public QuittingCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Exit();
        }
    }
}
