using SuperMario.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Entities.Enemies
{
    public class EnemyCollider
    {
        readonly Entity item;
        readonly ICollider rectangleCollider;

        public EnemyCollider(Entity item)
        {
            this.item = item;
            rectangleCollider = new RectangleCollider();
        }

        public void RunCollision()
        {
            RectangleCollisions collisions;
            foreach (Entity entity in EntityStorage.EnemyEntityList)
            {
                collisions = (RectangleCollisions)rectangleCollider.Collide(item.BoundingBox, entity.BoundingBox);
                if (collisions.Collisions.Count > 0)
                {
                    item.Collide(entity, collisions);
                }
            }
        }
    }
}
