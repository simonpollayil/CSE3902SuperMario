using CrossPlatformGameTemplate.Desktop;
using CrossPlatformGameTemplate.Entities;

namespace CrossPlatformGameTemplate.Commands
{
    public class ResetInitialStateCommand : ICommand
    {
        public ResetInitialStateCommand()
        {
        }
        public void Execute()
        {
            foreach (Entity entity in EntityStorage.SpriteList)
            {
               entity.Reset();
            }
        }
    }
}
