using System.Collections.Generic;
using SuperMario.Collision;
using SuperMario.Entities.Enemies;
using static SuperMario.Entities.MovementDirectionsEnum;

namespace SuperMario.Entities.Items
{
    public class ProjectileCollider : IEntityCollider
    {
        readonly Projectile projectile;
        readonly ICollider rectangleCollider;

        public ProjectileCollider(Projectile projectile)
        {
            this.projectile = projectile;
            rectangleCollider = new RectangleCollider();
        }

        public IList<Direction> RunCollision()
        {
            List<Direction> restrictMovementDirections = new List<Direction>();

            for (int i = 0; i < EntityStorage.EnemyEntityList.Count; i++)
            {
                var enemy = EntityStorage.EnemyEntityList[i];
                RectangleCollisions collisions = (RectangleCollisions)rectangleCollider.Collide(projectile.BoundingBox, enemy.BoundingBox);
                if (collisions.Collisions.Count > 0 && enemy.CurrentSprite != Sprite.EmptySprite())
                {
                    enemy.Collide(projectile, collisions);
                    projectile.Seppuku();
                }
            }

            for (int i = 0; i < EntityStorage.BlockEntityList.Count; i++)
            {
                var block = EntityStorage.BlockEntityList[i];
                var rect = projectile.BoundingBox;
                RectangleCollisions collisions = (RectangleCollisions)rectangleCollider.Collide(projectile.BoundingBox, block.BoundingBox);

                if ((collisions.Collisions.Contains(RectangleCollision.LeftRight) || collisions.Collisions.Contains(RectangleCollision.RightLeft))
                    && block.CurrentSprite != Sprite.EmptySprite()) {
                    projectile.Seppuku();
                }
            }

            return restrictMovementDirections;
        }
    }
}
