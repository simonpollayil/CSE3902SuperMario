using System.Collections.Generic;
using SuperMario.Entities;
using SuperMario.Entities.BackgroundElements;
using SuperMario.Entities.Blocks;
using SuperMario.Entities.Enemies;
using SuperMario.Entities.Items;
using SuperMario.Entities.Mario;
using SuperMario.Entities.Mario.CentralizedLifeSystem;
using SuperMario.Entities.Mario.MarioCondition;
using SuperMario.ScoreSystem;
using static SuperMario.Entities.Mario.MarioStateEnum;

namespace SuperMario.Collision
{
    public class MarioCollisionHandler : ICollisionHandler
    {
        MarioEntity mario;
        int levelWidth = 3600;
        ISet<Direction> restrictedMovementDirections;

        public MarioCollisionHandler(MarioEntity mario)
        {
            this.mario = mario;
            restrictedMovementDirections = new HashSet<Direction>();
        }

        PowerUpType GetMarioPowerType()
        {
            if (mario.CurrentConditionIsSmallCondtion())
                return PowerUpType.RedMushroom;
            else
                return PowerUpType.Flower;
        }

        void EntityPastLevelBoundsRestrictDirection()
        {
            if (mario.BoundingBox.Left <= 0)
                restrictedMovementDirections.Add(Direction.Left);
            else if (mario.BoundingBox.Right >= levelWidth)
                restrictedMovementDirections.Add(Direction.Right);
        }

        public ISet<Direction> Collide(Entity entity, RectangleCollisions rectangleCollisions)
        {
            restrictedMovementDirections.Clear();

            if (mario.CurrentMarioCondition is DeadMario)
                return restrictedMovementDirections;

            if (entity is BrickBlock brickBlock)
                HandleBrickBlock(brickBlock, rectangleCollisions);
            else if (entity is GravelBlock || entity is HitBlock || entity is ShinyBlock)
                HandleUnbreakableBlock(entity, rectangleCollisions);
            else if (entity is InvisibleBlock invisibleBlock)
                HandleInvisibleBlock(invisibleBlock, rectangleCollisions);
            else if (entity is QuestionBlock questionBlock)
                HandleQuestionBlock(questionBlock, rectangleCollisions);
            else if (entity is Goomba goomba)
                HandleGoomba(goomba, rectangleCollisions);
            else if (entity is KoopaTroopa koopaTroopa)
                HandleKoopa(koopaTroopa, rectangleCollisions);
            else if (entity is Coin coin)
            {
                coin.Obtain();
                mario.DrawScorePopUp(ScoreKeeper.Instance.IncrementScore());
            }
            else if (entity is Flower flower)
                HandleFlower(flower);
            else if (entity is Pipe)
                HandlePipe(entity, rectangleCollisions);
            else if (entity is RedMushroom redMushroom)
            {
                redMushroom.Obtain();
                ScoreKeeper.Instance.IncrementScoreGetPowerUp();
                mario.SetMarioConditionState(PlayerCondition.Super);
            }
            else if (entity is GreenMushroom greenMushroom)
            {
                greenMushroom.Obtain();
                ScoreKeeper.Instance.IncrementScoreGetPowerUp();
                CentralizedLives.Instance.GainOneLife();
            }
            else if (entity is Star star)
            {
                star.Obtain();
                ScoreKeeper.Instance.IncrementScoreGetPowerUp();
                mario.SetMarioState(MarioCommands.Star);
            }
            else if (entity is ExitPipe exitPipe)
            {
                if (rectangleCollisions.Collisions.Contains(RectangleCollision.BottomTop))
                    CollisionHelper.SetEntityLocationToTopOfEntity(mario, exitPipe);

                restrictedMovementDirections.UnionWith(BlockHelper.GetRectangleRestrictedMovement(rectangleCollisions));

                if (mario.CurrentState is MarioState.MovingRight)
                    mario.WarpBack();
            }
            else if (entity is Flagpole flagpole)
            {
                flagpole.EndGame();
                mario.StartEndGameSequence();
            }
            else if (entity is MarioEntity marioEntity && !marioEntity.Equals(mario))
                HandleMario(marioEntity, rectangleCollisions);

            EntityPastLevelBoundsRestrictDirection();

            return restrictedMovementDirections;
        }

        void HandleBrickBlock(BrickBlock brickBlock, RectangleCollisions rectangleCollisions)
        {
            ScoreKeeper.Instance.ChainReset();
            if (rectangleCollisions.Collisions.Contains(RectangleCollision.TopBottom))
            {
                if (mario.CurrentConditionIsSmallCondtion())
                    brickBlock.Jiggle();
                else
                    brickBlock.Hit(GetMarioPowerType());
            }
            else if (rectangleCollisions.Collisions.Contains(RectangleCollision.BottomTop))
                CollisionHelper.SetEntityLocationToTopOfEntity(mario, brickBlock);

            restrictedMovementDirections.UnionWith(BlockHelper.GetRectangleRestrictedMovement(rectangleCollisions));
        }

        void HandleUnbreakableBlock(Entity block, RectangleCollisions rectangleCollisions)
        {
            ScoreKeeper.Instance.ChainReset();
            if (rectangleCollisions.Collisions.Contains(RectangleCollision.BottomTop))
                CollisionHelper.SetEntityLocationToTopOfEntity(mario, block);

            restrictedMovementDirections.UnionWith(BlockHelper.GetRectangleRestrictedMovement(rectangleCollisions));
        }

        void HandleInvisibleBlock(InvisibleBlock invisibleBlock, RectangleCollisions rectangleCollisions)
        {
            ScoreKeeper.Instance.ChainReset();
            if (rectangleCollisions.Collisions.Contains(RectangleCollision.BottomTop))
                CollisionHelper.SetEntityLocationToTopOfEntity(mario, invisibleBlock);

            if (rectangleCollisions.Collisions.Contains(RectangleCollision.TopBottom))
                invisibleBlock.Hit(GetMarioPowerType());

            restrictedMovementDirections.UnionWith(BlockHelper.GetRectangleRestrictedMovement(rectangleCollisions));
        }

        void HandleQuestionBlock(QuestionBlock questionBlock, RectangleCollisions rectangleCollisions)
        {
            ScoreKeeper.Instance.ChainReset();
            if (rectangleCollisions.Collisions.Contains(RectangleCollision.BottomTop))
                CollisionHelper.SetEntityLocationToTopOfEntity(mario, questionBlock);

            if (rectangleCollisions.Collisions.Contains(RectangleCollision.TopBottom))
            {
                if (!questionBlock.IsHit())
                    mario.DrawScorePopUp(ScoreKeeper.Instance.IncrementScore());
                questionBlock.Hit(GetMarioPowerType());
            }

            restrictedMovementDirections.UnionWith(BlockHelper.GetRectangleRestrictedMovement(rectangleCollisions));
        }

        void HandleGoomba(Goomba goomba, RectangleCollisions rectangleCollisions)
        {
            if (rectangleCollisions.Collisions.Contains(RectangleCollision.BottomTop))
            {
                if (!goomba.IsHit())
                {
                    mario.EnemyHitMarioBounce();
                    goomba.Hit();
                    mario.DrawScorePopUp(ScoreKeeper.Instance.IncrementScore());
                    ScoreKeeper.Instance.ChainIncrement();
                }
            }

            if (mario.CurrentConditionIsStarCondition())
            {
                if (!goomba.IsHit())
                {
                    goomba.Hit();
                    mario.DrawScorePopUp(ScoreKeeper.Instance.IncrementScore());
                    ScoreKeeper.Instance.ChainIncrement();
                }
            }

            if ((rectangleCollisions.Collisions.Contains(RectangleCollision.LeftRight) || rectangleCollisions.Collisions.Contains(RectangleCollision.RightLeft)
                || rectangleCollisions.Collisions.Contains(RectangleCollision.TopBottom)) && !goomba.IsHit())
                mario.SetMarioState(MarioCommands.Hit);

            if (!goomba.IsHit())
                restrictedMovementDirections.UnionWith(BlockHelper.GetRectangleRestrictedMovement(rectangleCollisions));
        }

        void HandleKoopa(KoopaTroopa koopaTroopa, RectangleCollisions rectangleCollisions)
        {
            if (rectangleCollisions.Collisions.Contains(RectangleCollision.BottomTop))
            {
                mario.EnemyHitMarioBounce();
                koopaTroopa.Hit();
                mario.DrawScorePopUp(ScoreKeeper.Instance.IncrementScore());
                ScoreKeeper.Instance.ChainIncrement();
            }

            if (mario.CurrentConditionIsStarCondition())
            {
                koopaTroopa.Hit();
                mario.DrawScorePopUp(ScoreKeeper.Instance.IncrementScore());
                ScoreKeeper.Instance.ChainIncrement();
            }

            if (rectangleCollisions.Collisions.Contains(RectangleCollision.RightLeft) && koopaTroopa.IsShellState() && !koopaTroopa.IsShellHit())
                koopaTroopa.ShellHit(Direction.Left);
            else if (rectangleCollisions.Collisions.Contains(RectangleCollision.LeftRight) && koopaTroopa.IsShellState() && !koopaTroopa.IsShellHit())
                koopaTroopa.ShellHit(Direction.Right);
            else if (rectangleCollisions.Collisions.Contains(RectangleCollision.BottomTop) && koopaTroopa.IsShellState() && !koopaTroopa.IsShellHit())
                koopaTroopa.ShellHit(Direction.Idle);
            else if ((rectangleCollisions.Collisions.Contains(RectangleCollision.LeftRight) || rectangleCollisions.Collisions.Contains(RectangleCollision.RightLeft) || rectangleCollisions.Collisions.Contains(RectangleCollision.TopBottom)) &&
                (koopaTroopa.IsShellHit() || !koopaTroopa.IsShellState()))
                mario.SetMarioState(MarioCommands.Hit);

            restrictedMovementDirections.UnionWith(BlockHelper.GetRectangleRestrictedMovement(rectangleCollisions));
        }

        void HandleFlower(Flower flower)
        {
            flower.Obtain();
            ScoreKeeper.Instance.IncrementScoreGetPowerUp();
            mario.SetMarioConditionState(PlayerCondition.Fire);
        }

        void HandlePipe(Entity pipe, RectangleCollisions rectangleCollisions)
        {
            ScoreKeeper.Instance.ChainReset();
            if (rectangleCollisions.Collisions.Contains(RectangleCollision.BottomTop))
                CollisionHelper.SetEntityLocationToTopOfEntity(mario, pipe);

            restrictedMovementDirections.UnionWith(BlockHelper.GetRectangleRestrictedMovement(rectangleCollisions));

            if (mario.CurrentState is MarioState.CrouchingLeft || mario.CurrentState is MarioState.CrouchingRight)
                mario.Warp();
        }

        void HandleMario(MarioEntity otherMario, RectangleCollisions rectangleCollisions)
        {
            if (rectangleCollisions.Collisions.Contains(RectangleCollision.BottomTop))
                CollisionHelper.SetEntityLocationToTopOfEntity(mario, otherMario);

            restrictedMovementDirections.UnionWith(BlockHelper.GetRectangleRestrictedMovement(rectangleCollisions));
        }
    }
}