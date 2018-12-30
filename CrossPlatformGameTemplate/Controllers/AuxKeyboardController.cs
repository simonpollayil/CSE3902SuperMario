using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using SuperMario.Commands;
using SuperMario.Commands.BrickCommands;
using SuperMario.Desktop;
using SuperMario.Entities;
using SuperMario.Entities.Blocks;

namespace SuperMario.Controllers
{
    public class AuxKeyboardController : IController
    {
        Game1 game;

        IDictionary<Keys, ICommand> OnPressKeyCommandDictionary;
        IDictionary<Keys, ICommand> PauseCommand;

        KeyboardState lastKeyboardState;

        public AuxKeyboardController(Game1 game)
        {
            this.game = game;
            Reset();
        }

        static List<QuestionBlock> GetListOfQuestionBlockType()
        {
            List<QuestionBlock> questionBlockList = new List<QuestionBlock>();
            foreach (Entity entity in EntityStorage.Instance.BlockEntityList)
            {
                if (entity is QuestionBlock)
                {
                    questionBlockList.Add(entity as QuestionBlock);
                }
            }

            return questionBlockList;
        }

        static List<InvisibleBlock> GetListOfHiddenBlockType()
        {
            List<InvisibleBlock> hiddenBlockList = new List<InvisibleBlock>();
            foreach (Entity entity in EntityStorage.Instance.BlockEntityList)
            {
                if (entity is InvisibleBlock)
                {
                    hiddenBlockList.Add(entity as InvisibleBlock);
                }
            }

            return hiddenBlockList;
        }

        public void Reset()
        {
            PauseCommand = new Dictionary<Keys, ICommand>
            {
                { Keys.P, new PauseCommand(game) },
            };

            OnPressKeyCommandDictionary = new Dictionary<Keys, ICommand>
            {
                { Keys.R, new ResetInitialStateCommand(Game1.LevelData) },
                { Keys.Z, new QuestionToUsedBlockCommand(GetListOfQuestionBlockType()) },
                { Keys.C, new InvisibleToUsedBlockCommand(GetListOfHiddenBlockType()) },
                { Keys.Q, new QuittingCommand(game) }
            };
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            foreach (Keys pressedKey in state.GetPressedKeys())
            {
                if (lastKeyboardState.IsKeyUp(pressedKey))
                {
                    bool validPressedKey = PauseCommand.TryGetValue(pressedKey, out ICommand pressCommand);
                    if (validPressedKey)
                    {
                        pressCommand.Execute();
                    }
                }
            }

            if (!game.IsPaused())
            {
                foreach (Keys pressedKey in state.GetPressedKeys())
                {
                    if (lastKeyboardState.IsKeyUp(pressedKey))
                    {
                        bool validPressedKey = OnPressKeyCommandDictionary.TryGetValue(pressedKey, out ICommand pressCommand);
                        if (validPressedKey)
                        {
                            pressCommand.Execute();
                        }
                    }
                }
            }

            lastKeyboardState = state;
        }
    }
}
