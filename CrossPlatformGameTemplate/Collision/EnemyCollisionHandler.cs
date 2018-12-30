using System.Collections.Generic;
using SuperMario.Entities;
using SuperMario.Entities.Blocks;
using SuperMario.Entities.Enemies;
using SuperMario.Entities.Items;
using SuperMario.ScoreSystem;
using SuperMario.Sound;

namespace SuperMario.Collision
{
    public class EnemyCollisionHandler : ICollisionHandler
    {
        MovingEntity enemy;
        ISet<Direction> restrictedMovementDirection;

        public EnemyCollisionHandler(MovingEntity enemy)
        {
            this.enemy = enemy;
            restrictedMovementDirection = new HashSet<Direction>();
        }

        public ISet<Direction> Collide(Entity entity, RectangleCollisions rectangleCollisions)
        {
            restrictedMovementDirection.Clear();

            if (enemy is KoopaTroopa koopa && koopa.IsShellHit() && (entity is KoopaTroopa || entity is Goomba) && !enemy.Equals(entity))
            {
                ((IEnemy)entity).Hit();
                ScoreKeeper.Instance.IncrementScore();
                ScoreKeeper.Instance.ChainIncrement();
                return restrictedMovementDirection;
            }

            if (CollisionHelper.EntityIsBlock(entity) || entity is Pipe || ((entity is KoopaTroopa || entity is Goomba) && !enemy.Equals(entity)))
            {
                if (rectangleCollisions.Collisions.Contains(RectangleCollision.BottomTop))
                {
                    if (entity is IHitUpAndDownBlock hitUpAndDownBlock && hitUpAndDownBlock.AnimatingUpAndDown)
                    {
                        ((IEnemy)enemy).Hit();
                        ScoreKeeper.Instance.IncrementScore();
                    }

                    CollisionHelper.SetEntityLocationToTopOfEntity(enemy, entity);
                }
                else if (enemy is KoopaTroopa koopaB && koopaB.IsShellHit())
                {
                    SoundEffects.Instance.PlayBump();
                    ScoreKeeper.Instance.ChainReset();
                }

                restrictedMovementDirection.UnionWith(BlockHelper.GetRectangleRestrictedMovement(rectangleCollisions));
            }

            return restrictedMovementDirection;
        }
    }
}
