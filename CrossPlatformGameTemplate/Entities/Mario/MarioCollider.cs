using System.Collections.Generic;
using SuperMario.Collision;
using static SuperMario.Entities.MovementDirectionsEnum;

namespace SuperMario.Entities.Mario
{
    public class MarioCollider : IEntityCollider
    {
        readonly MovingEntity mario;
        readonly ICollider rectangleCollider;

        public MarioCollider(Entity mario)
        {
            this.mario = (MovingEntity)mario;
            rectangleCollider = new RectangleCollider();
        }

        private IList<Direction> EntityPastLevelBoundsRestrictDirection()
        {
            List<Direction> restrictMovementDirections = new List<Direction>();

            if (mario.BoundingBox.Left <= 0)
                restrictMovementDirections.Add(Direction.Left);
            else if (mario.BoundingBox.Right >= 3600)
                restrictMovementDirections.Add(Direction.Right);

            return restrictMovementDirections;
        }

        public IList<Direction> RunCollision()
        {
            List<Direction> restrictMovementDirections = new List<Direction>();
            mario.Grounded = false;

            for (int i = 0; i < EntityStorage.EntityList.Count; i++)
            {
                var entity = EntityStorage.EntityList[i];
                if (!entity.Equals(mario))
                {
                    RectangleCollisions collisions = (RectangleCollisions)rectangleCollider.Collide(mario.BoundingBox, entity.BoundingBox);

                    if (collisions.Collisions.Count > 0)
                        restrictMovementDirections.AddRange(entity.Collide(mario, collisions));
                }
            }

            restrictMovementDirections.AddRange(EntityPastLevelBoundsRestrictDirection());

            return restrictMovementDirections;
        }
    }
}
 