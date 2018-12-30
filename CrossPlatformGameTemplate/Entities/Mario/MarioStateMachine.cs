using SuperMario.Entities.Mario.MarioCondition;
using static SuperMario.Entities.Mario.MarioStateEnum;

namespace SuperMario.Entities.Mario
{
    internal class MarioStateMachine
    {
        private MarioStateMachine()
        {
        }

        public static MarioStateConditionTuple GetNextMarioState(PlayerCondition currentmarioCondition, MarioState currentMarioState, MarioCommands command)
        {
            MarioStateConditionTuple tuple = new MarioStateConditionTuple(currentmarioCondition, currentMarioState);

            if (command.Equals(MarioCommands.Hit))
            {
                if (!(currentmarioCondition.Equals(PlayerCondition.StarFire) || currentmarioCondition.Equals(PlayerCondition.StarSmall) || currentmarioCondition.Equals(PlayerCondition.StarSuper)))
                {
                    if (currentmarioCondition.Equals(PlayerCondition.Small))
                        tuple.marioCondition = PlayerCondition.Dead;
                    else if (currentmarioCondition.Equals(PlayerCondition.Fire) || currentmarioCondition.Equals(PlayerCondition.Super))
                        tuple.marioCondition = PlayerCondition.Small;
                }

                return tuple;
            }

            if (command.Equals(MarioCommands.Star))
            {
                if (currentmarioCondition.Equals(PlayerCondition.Fire))
                    tuple.marioCondition = PlayerCondition.StarFire;

                if (currentmarioCondition.Equals(PlayerCondition.Super))
                    tuple.marioCondition = PlayerCondition.StarSuper;

                if (currentmarioCondition.Equals(PlayerCondition.Small))
                    tuple.marioCondition = PlayerCondition.StarSmall;

                return tuple;
            }

            if (!currentMarioState.Equals(MarioState.Dead))
            {
                switch (command)
                {
                    case MarioCommands.MoveLeft:
                        tuple.marioState = MarioState.MovingLeft;
                        return tuple;
                    case MarioCommands.MoveRight:
                        tuple.marioState = MarioState.MovingRight;
                        return tuple;
                }

                switch (currentMarioState)
                {
                    case MarioState.CrouchingLeft:
                        tuple.marioState = CrouchLeft(command);
                        return tuple;
                    case MarioState.CrouchingRight:
                        tuple.marioState = CrouchRight(command);
                        return tuple;
                    case MarioState.FacingLeft:
                        tuple.marioState = FaceLeft(command, currentmarioCondition);
                        return tuple;
                    case MarioState.FacingRight:
                        tuple.marioState = FaceRight(command, currentmarioCondition);
                        return tuple;
                    case MarioState.JumpingLeft:
                        tuple.marioState = JumpLeft(command);
                        return tuple;
                    case MarioState.JumpingRight:
                        tuple.marioState = JumpRight(command);
                        return tuple;
                    case MarioState.MovingLeft:
                        tuple.marioState = MoveLeft(command);
                        return tuple;
                    case MarioState.MovingRight:
                        tuple.marioState = MoveRight(command);
                        return tuple;
                }
            }

            return tuple;
        }

        private static MarioState CrouchLeft(MarioCommands command)
        {
            switch (command)
            {
                case MarioCommands.Jump:
                    return MarioState.FacingLeft;
                default:
                    return MarioState.CrouchingLeft;
            }
        }

        private static MarioState CrouchRight(MarioCommands command)
        {
            switch (command)
            {
                case MarioCommands.Jump:
                    return MarioState.FacingRight;
                default:
                    return MarioState.CrouchingRight;
            }
        }

        private static MarioState FaceLeft(MarioCommands command, PlayerCondition condition)
        {
            switch (command)
            {
                case MarioCommands.Jump:
                    return MarioState.JumpingLeft;
                case MarioCommands.Crouch:
                    if (!(condition.Equals(PlayerCondition.Small) || condition.Equals(PlayerCondition.StarSmall)))
                        return MarioState.CrouchingLeft;

                    return MarioState.FacingLeft;
                default:
                    return MarioState.FacingLeft;
            }
        }

        private static MarioState FaceRight(MarioCommands command, PlayerCondition condition)
        {
            switch (command)
            {
                case MarioCommands.Jump:
                    return MarioState.JumpingRight;
                case MarioCommands.Crouch:
                    if (!(condition.Equals(PlayerCondition.Small) || condition.Equals(PlayerCondition.StarSmall)))
                        return MarioState.CrouchingRight;

                    return MarioState.FacingRight;
                default:
                    return MarioState.FacingRight;
            }
        }

        private static MarioState JumpLeft(MarioCommands command)
        {
            switch (command)
            {
                case MarioCommands.Crouch:
                case MarioCommands.Stop:
                    return MarioState.FacingLeft;
                default:
                    return MarioState.JumpingLeft;
            }
        }

        private static MarioState JumpRight(MarioCommands command)
        {
            switch (command)
            {
                case MarioCommands.Crouch:
                case MarioCommands.Stop:
                    return MarioState.FacingRight;
                default:
                    return MarioState.JumpingRight;
            }
        }

        private static MarioState MoveLeft(MarioCommands command)
        {
            switch (command)
            {
                case MarioCommands.Crouch:
                    return MarioState.CrouchingLeft;
                case MarioCommands.Jump:
                    return MarioState.JumpingLeft;
                case MarioCommands.Stop:
                    return MarioState.FacingLeft;
                default:
                    return MarioState.MovingLeft;
            }
        }

        private static MarioState MoveRight(MarioCommands command)
        {
            switch (command)
            {
                case MarioCommands.Crouch:
                    return MarioState.CrouchingRight;
                case MarioCommands.Jump:
                    return MarioState.JumpingRight;
                case MarioCommands.Stop:
                    return MarioState.FacingRight;
                default:
                    return MarioState.MovingRight;
            }
        }
    }

    internal class MarioStateConditionTuple
    {
        public PlayerCondition marioCondition { get; set; }
        public MarioState marioState { get; set; }

        public MarioStateConditionTuple(PlayerCondition marioCondition, MarioState marioState)
        {
            this.marioCondition = marioCondition;
            this.marioState = marioState;
        }
    }
}
