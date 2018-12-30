using System.Collections.Generic;
using SuperMario.Entities;
using SuperMario.Entities.Blocks;
using SuperMario.Entities.Items;

namespace SuperMario.Collision
{
    public class ItemCollisionHandler : ICollisionHandler
    {
        MovingEntity item;
        ISet<Direction> restrictedMovementDirection;

        public ItemCollisionHandler(MovingEntity item)
        {
            this.item = item;
            restrictedMovementDirection = new HashSet<Direction>();
        }

        public ISet<Direction> Collide(Entity entity, RectangleCollisions rectangleCollisions)
        {
            restrictedMovementDirection.Clear();

            if (CollisionHelper.EntityIsBlock(entity) || entity is Pipe)
            {
                if (rectangleCollisions.Collisions.Contains(RectangleCollision.BottomTop))
                    CollisionHelper.SetEntityLocationToTopOfEntity(item, entity);

                restrictedMovementDirection.UnionWith(BlockHelper.GetRectangleRestrictedMovement(rectangleCollisions));
            }

            return restrictedMovementDirection;
        }
    }
}
