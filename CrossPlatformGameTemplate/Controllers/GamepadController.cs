using SuperMario.Commands;
using SuperMario.Desktop;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SuperMario.Controllers
{
    public class GamepadController : IController
    {
        readonly IDictionary<Buttons, ICommand> ButtonCommandDictionary;
        public GamepadController(Game1 game)
        {
            ButtonCommandDictionary = new Dictionary<Buttons, ICommand>
            {
                { Buttons.Start, new QuittingCommand(game) }
            };
        }

        public void Reset()
        {
        }

        public void Update()
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            if (state.IsConnected)
            {
                Buttons[] buttonList = (Buttons[])System.Enum.GetValues(typeof(Buttons));
                foreach (Buttons button in buttonList)
                {
                    bool validButton = ButtonCommandDictionary.TryGetValue(button, out ICommand command);
                    if (state.IsButtonDown(button) && validButton)
                    {
                        command.Execute();
                    }
                }
            }
        }
    }
}
