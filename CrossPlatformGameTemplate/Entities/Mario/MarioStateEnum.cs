namespace SuperMario.Entities.Mario
{
    public static class MarioStateEnum
    {
        public enum MarioState {
            FacingLeft,
            FacingRight,
            JumpingLeft,
            JumpingRight,
            CrouchingRight,
            CrouchingLeft,
            MovingLeft,
            MovingRight,
            TurningLeft,
            TurningRight,
            Dead
        }

        public enum MarioCommands {
            MoveLeft,
            MoveRight,
            Crouch,
            Jump,
            Hit,
            Star,
            Stop
        }
    }
}
