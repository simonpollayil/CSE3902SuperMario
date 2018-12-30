using System.Collections.Generic;
using SuperMario.Entities;

namespace SuperMario.Collision
{
    public interface ICollisionHandler
    {
        ISet<Direction> Collide(Entity entity, RectangleCollisions collisions);
    }
}
