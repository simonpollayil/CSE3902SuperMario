using System.Collections.Generic;
using SuperMario.Entities;
using SuperMario.Entities.Blocks;
using SuperMario.Entities.Enemies;
using SuperMario.Entities.Items;
using SuperMario.ScoreSystem;

namespace SuperMario.Collision
{
    public class FireballCollisionHandler : ICollisionHandler
    {
        Projectile fireball;
        ISet<Direction> restrictedMovementDirection;

        public FireballCollisionHandler(Projectile fireball)
        {
            this.fireball = fireball;
            restrictedMovementDirection = new HashSet<Direction>();
        }

        public ISet<Direction> Collide(Entity entity, RectangleCollisions rectangleCollisions)
        {
            restrictedMovementDirection.Clear();

            if (CollisionHelper.EntityIsBlock(entity) || entity is Pipe)
            {
                if (rectangleCollisions.Collisions.Contains(RectangleCollision.BottomTop))
                    CollisionHelper.SetEntityLocationToTopOfEntity(fireball, entity);

                restrictedMovementDirection.UnionWith(BlockHelper.GetRectangleRestrictedMovement(rectangleCollisions));

                if (rectangleCollisions.Collisions.Contains(RectangleCollision.LeftRight))
                    fireball.Hit();
            }
            else if(entity is IEnemy enemy)
            {
                enemy.Hit();
                ScoreKeeper.Instance.IncrementScore();
                fireball.Hit();
            }

            return restrictedMovementDirection;
        }
    }
}
