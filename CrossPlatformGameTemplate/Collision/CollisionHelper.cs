using Microsoft.Xna.Framework;
using SuperMario.Entities;
using SuperMario.Entities.Blocks;

namespace SuperMario.Collision
{
    public static class CollisionHelper
    {
        public static void SetEntityLocationToTopOfEntity(MovingEntity movingEntity, Entity collidedEntity) 
        {
            movingEntity.Grounded = true;
            movingEntity.SetScreenLocation(new Vector2(movingEntity.BoundingBox.X, collidedEntity.BoundingBox.Top - movingEntity.BoundingBox.Height));
        }

        public static void SetEntityLocationToTopOfEntity(Entity movingEntity, Entity collidedEntity)
        {
            movingEntity.SetScreenLocation(new Vector2(movingEntity.BoundingBox.X, collidedEntity.BoundingBox.Top - movingEntity.BoundingBox.Height));
        }

        public static bool EntityIsBlock(Entity entity)
        {
            return entity is BrickBlock || entity is GravelBlock || entity is HitBlock
                || entity is InvisibleBlock || entity is QuestionBlock || entity is ShinyBlock;
        }
    }
}
