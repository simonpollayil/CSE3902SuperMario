using SuperMario.Desktop;

namespace SuperMario.Commands
{
    public class PauseCommand : ICommand
    {
        readonly Game1 game;
        public PauseCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.TogglePause();
        }
    }
}
