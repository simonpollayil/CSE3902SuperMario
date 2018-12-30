using SuperMario.Collision;
using SuperMario.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperMario.Entities.MovementDirectionsEnum;

namespace SuperMario.Entities.Blocks
{
    public class BlockCollider 
    {
        readonly Entity item;
        readonly ICollider rectangleCollider;

        public BlockCollider(Entity item)
        {
            this.item = item;
            rectangleCollider = new RectangleCollider();
        }

        public void RunCollision()
        {
            RectangleCollisions collisions;
            foreach (Entity entity in EntityStorage.BlockEntityList)
            {
                collisions = (RectangleCollisions)rectangleCollider.Collide(item.BoundingBox, entity.BoundingBox);
                if(collisions.Collisions.Count > 0)
                {
                    item.Collide(entity, collisions);
                }
            }
            foreach (Entity entity in EntityStorage.ItemEntityList)
            {
                if (entity is Pipe)
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
}
