using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuperMario.Collision;
using SuperMario.Entities.Items;
using SuperMario.Entities.Mario;
using SuperMario.Entities.Mario.MarioCondition;
using static SuperMario.Entities.MovementDirectionsEnum;

namespace SuperMario.Entities.Blocks
{
    public abstract class Block
    {
        public static IList<Direction> GetRestrictedMovement(RectangleCollisions rectangleCollisions) {
            List<Direction> restrictedMovementDirection = new List<Direction>();

            if (rectangleCollisions.Collisions.Contains(RectangleCollision.TopBottom))
                restrictedMovementDirection.Add(Direction.Up);

            if (rectangleCollisions.Collisions.Contains(RectangleCollision.BottomTop))
                restrictedMovementDirection.Add(Direction.Down);

            if (rectangleCollisions.Collisions.Contains(RectangleCollision.LeftRight))
                restrictedMovementDirection.Add(Direction.Right);

            if (rectangleCollisions.Collisions.Contains(RectangleCollision.RightLeft))
                restrictedMovementDirection.Add(Direction.Left);

            return restrictedMovementDirection;
        }

        public static Entity CreateItem(BlockItemType blockItemType, Vector2 screenLocation, MarioEntity mario)
        {
            screenLocation.Y -= 16;
            switch (blockItemType)
            {
                case BlockItemType.PowerUp:
                    if (mario.CurrentMarioCondition is SmallMario || mario.CurrentMarioCondition is StarSmallMario)
                        return new RedMushroom(screenLocation);

                    return new Flower(screenLocation);
                case BlockItemType.Coin:
                    var coin = new Coin(screenLocation);
                    coin.Hit();
                    return coin;
                case BlockItemType.Star:
                    return new Star(screenLocation);
                case BlockItemType.GreenMushroom:
                    return new GreenMushroom(screenLocation);
                case BlockItemType.None:
                    return null;
            }

            return null;
        }
    }

    public enum BlockItemType {
        PowerUp, 
        GreenMushroom,
        Coin,
        Star,
        None
    }
}
