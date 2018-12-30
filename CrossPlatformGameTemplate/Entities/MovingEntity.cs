using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SuperMario.Entities
{
    public abstract class MovingEntity : Entity
    {
        public bool Grounded { get; set; }
        protected Direction EntityXDirection { get; set; }
        protected Direction EntityYDirection { get; set; }
        protected Vector2 EntityVelocity { get; set; }
        protected float GravityVelocity { get; set; }
        protected ISet<Direction> RestrictedMovementDirections { get; } = new HashSet<Direction>();

        float gravityMax;

        protected MovingEntity(Vector2 screenLocation) : base(screenLocation)
        {
            ScreenLocation = screenLocation;
            gravityMax = 4f;
            Grounded = false;
        }

        void Gravity()
        {
            float downVelocity = 0.1f;

            if (!Grounded)
            {
                if (GravityVelocity <= gravityMax)
                {
                    GravityVelocity += downVelocity;
                    ScreenLocation = new Vector2(ScreenLocation.X, ScreenLocation.Y + GravityVelocity);
                }
                else
                    ScreenLocation = new Vector2(ScreenLocation.X, ScreenLocation.Y + GravityVelocity);
            }
            else
                GravityVelocity = 0;
        }

        protected virtual void UpdateXDirectionWithRestrictions()
        {
            if (RestrictedMovementDirections.Contains(Direction.Left) && EntityXDirection.Equals(Direction.Left) && !RestrictedMovementDirections.Contains(Direction.Down))
                EntityXDirection = Direction.Right;
            else if (RestrictedMovementDirections.Contains(Direction.Right) && EntityXDirection.Equals(Direction.Right) && !RestrictedMovementDirections.Contains(Direction.Down))
                EntityXDirection = Direction.Left;
        }

        protected virtual void Move()
        {
            UpdateXDirectionWithRestrictions();

            switch (EntityXDirection)
            {
                case Direction.Left:
                    ScreenLocation = new Vector2(ScreenLocation.X - EntityVelocity.X, ScreenLocation.Y);
                    break;
                case Direction.Right:
                    ScreenLocation = new Vector2(ScreenLocation.X + EntityVelocity.X, ScreenLocation.Y);
                    break;
                case Direction.Idle:
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            Gravity();
        }
    }
}
