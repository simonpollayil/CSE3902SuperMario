using System.Collections.Generic;
using SuperMario.Entities;

namespace SuperMario.Collision
{
    public static class MasterCollider
    {
        static List<Entity> collidingEntitesToAdd = new List<Entity>();

        public static IList<Entity> Colliders { get; private set; } = new List<Entity>();

        public static void RunCollision() 
         {
            RectangleCollisions collisions;
            foreach(Entity collider in Colliders)
            {
                if (collider is MovingEntity movingEntity)
                    movingEntity.Grounded = false;

                foreach (Entity entity in EntityStorage.Instance.EntityList)
                {
                    collisions = RectangleCollider.Collide(collider.BoundingBox, entity.BoundingBox);

                    if (collisions.Collisions.Count > 0)
                        collider.Collide(entity, collisions);
                }
            }

            ((List<Entity>)Colliders).AddRange(collidingEntitesToAdd);
            collidingEntitesToAdd.Clear();

            EntityStorage.Instance.AddQueuedItems();
        }

        public static void AddCollidingEntity(Entity entity) 
        {
            collidingEntitesToAdd.Add(entity);
        }

        public static void Reset()
        {
            Colliders = new List<Entity>();
        }
    }
}
