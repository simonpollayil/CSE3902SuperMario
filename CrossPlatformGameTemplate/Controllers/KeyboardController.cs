using SuperMario.Commands;
using SuperMario.Commands.MarioCommand;
using SuperMario.Desktop;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using static SuperMario.Entities.Mario.MarioStateEnum;
using SuperMario.Entities.Mario.MarioCondition;
using SuperMario.Entities;

namespace SuperMario.Controllers
{
    public class PlayerKeys
    {
        public Keys UpKey { get; private set; }
        public Keys DownKey { get; private set; }
        public Keys LeftKey { get; private set; }
        public Keys RightKey { get; private set; }
        public Keys AbilityKey { get; private set; }

        public PlayerKeys(Keys upKey, Keys downKey, Keys leftKey, Keys rightKey, Keys abilityKey)
        {
            UpKey = upKey;
            DownKey = downKey;
            LeftKey = leftKey;
            RightKey = rightKey;
            AbilityKey = abilityKey;
        }
    }

    public class KeyboardController : IController
    {
        IDictionary<Keys, ICommand> HeldKeyCommandDictionary;
        IDictionary<Keys, ICommand> OnPressKeyCommandDictionary;
        IDictionary<Keys, ICommand> OnPressKeyXYDirectionCommandDictionary;
        IDictionary<Keys, ICommand> IdleCommandDictionary;
        IDictionary<Keys, ICommand> StopCommandDictionary;
        IDictionary<Keys, ICommand> MovementStateCommands;
        IDictionary<Keys, ICommand> StopAbilityCommandDictionary;

        Game1 game;

        KeyboardState lastKeyboardState;

        int playerIndex;
        PlayerKeys playerKeys;

        public KeyboardController(Game1 marioGame, int playerIndex, PlayerKeys playerKeys)
        {
            this.playerIndex = playerIndex;
            this.playerKeys = playerKeys;
            game = marioGame;
            Reset();
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            if (!game.IsPaused())
            {
                var movementKeyIsPressed = state.IsKeyDown(playerKeys.UpKey) || state.IsKeyDown(playerKeys.DownKey) 
                                                || state.IsKeyDown(playerKeys.LeftKey) || state.IsKeyDown(playerKeys.RightKey);

                foreach (Keys pressedInLastState in lastKeyboardState.GetPressedKeys())
                {
                    if (state.IsKeyUp(pressedInLastState))
                    {
                        bool validReleasedKey = StopAbilityCommandDictionary.TryGetValue(pressedInLastState, out ICommand releaseCommand);
                        if (validReleasedKey)
                        {
                            releaseCommand.Execute();
                        }
                    }
                }

                if(!movementKeyIsPressed)
                {
                    foreach (Keys key in StopCommandDictionary.Keys)
                    {
                        bool validReleasedKey = StopCommandDictionary.TryGetValue(key, out ICommand stopCommand);
                        if (validReleasedKey)
                        {
                            stopCommand.Execute();
                        }
                    }
                }

                foreach (Keys key in IdleCommandDictionary.Keys)
                {
                    bool validReleasedKey = IdleCommandDictionary.TryGetValue(key, out ICommand releaseCommand);
                    if (validReleasedKey)
                    {
                        releaseCommand.Execute();
                    }
                }

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

                    bool validHeldKey = OnPressKeyXYDirectionCommandDictionary.TryGetValue(pressedKey, out ICommand command);
                    if (validHeldKey)
                    {
                        command.Execute();
                    }

                    bool movementValidHeldKey = MovementStateCommands.TryGetValue(pressedKey, out ICommand moveCommand);
                    if (movementValidHeldKey)
                    {
                        moveCommand.Execute();
                    }

                    bool otherValidHeldKeys = HeldKeyCommandDictionary.TryGetValue(pressedKey, out ICommand heldCommand);
                    if (otherValidHeldKeys)
                    {
                        heldCommand.Execute();
                    }
                }
            }

            lastKeyboardState = state;
        }

        public void Reset()
        {
            HeldKeyCommandDictionary = new Dictionary<Keys, ICommand>
            {
                { playerKeys.AbilityKey, new MarioAbilityCommand(playerIndex, true) }
            };

            OnPressKeyCommandDictionary = new Dictionary<Keys, ICommand>
            {
                { Keys.O, new ChangeMarioConditionStateCommand(playerIndex, PlayerCondition.Fire) },
                { Keys.U, new ChangeMarioConditionStateCommand(playerIndex, PlayerCondition.Super) },
                { Keys.Y, new ChangeMarioConditionStateCommand(playerIndex, PlayerCondition.Small)},
            };

            OnPressKeyXYDirectionCommandDictionary = new Dictionary<Keys, ICommand>
            {
                { playerKeys.LeftKey, new ChangeMarioXDirection(playerIndex, Direction.Left) },
                { playerKeys.RightKey, new ChangeMarioXDirection(playerIndex, Direction.Right) },
                { playerKeys.UpKey, new ChangeMarioYDirection(playerIndex, Direction.Up) },
            };

            MovementStateCommands = new Dictionary<Keys, ICommand>
            {
                { playerKeys.UpKey, new ChangeMarioMovementStateCommand(playerIndex, MarioCommands.Jump) },
                { playerKeys.LeftKey, new ChangeMarioMovementStateCommand(playerIndex, MarioCommands.MoveLeft) },
                { playerKeys.DownKey, new ChangeMarioMovementStateCommand(playerIndex, MarioCommands.Crouch) },
                { playerKeys.RightKey, new ChangeMarioMovementStateCommand(playerIndex, MarioCommands.MoveRight) },
            };

            IdleCommandDictionary = new Dictionary<Keys, ICommand>
            {
                { playerKeys.LeftKey, new ChangeMarioXDirection(playerIndex, Direction.Idle) },
                { playerKeys.RightKey, new ChangeMarioXDirection(playerIndex, Direction.Idle) },
                { playerKeys.UpKey, new ChangeMarioYDirection(playerIndex, Direction.Idle) },
            };

            StopCommandDictionary = new Dictionary<Keys, ICommand>
            {
                { playerKeys.UpKey, new ChangeMarioMovementStateCommand(playerIndex, MarioCommands.Stop) },
                { playerKeys.LeftKey, new ChangeMarioMovementStateCommand(playerIndex, MarioCommands.Stop) },
                { playerKeys.DownKey, new ChangeMarioMovementStateCommand(playerIndex, MarioCommands.Stop) },
                { playerKeys.RightKey, new ChangeMarioMovementStateCommand(playerIndex, MarioCommands.Stop) },
            };

            StopAbilityCommandDictionary = new Dictionary<Keys, ICommand>
            {
                { playerKeys.AbilityKey, new MarioAbilityCommand(playerIndex, false) },
            };
        }
    }

}
