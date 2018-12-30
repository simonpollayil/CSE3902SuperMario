using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuperMario.Collision;
using SuperMario.Entities.Items;
using SuperMario.Sound;

namespace SuperMario.Entities.Blocks
{
    public abstract class BlockHelper
    {
        public static ISet<Direction> GetRectangleRestrictedMovement(RectangleCollisions rectangleCollisions) {
            ISet<Direction> restrictedMovementDirection = new HashSet<Direction>();

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

        public static Entity CreateItem(BlockItemType blockItemType, Vector2 screenLocation, PowerUpType powerUpType)
        {
            screenLocation.Y -= 16;
            switch (blockItemType)
            {
                case BlockItemType.PowerUp:
                    switch (powerUpType) 
                    {
                        case PowerUpType.Flower:
                            SoundEffects.Instance.PlayPowerUpAppear();
                            return new Flower(screenLocation);
                        case PowerUpType.RedMushroom:
                            SoundEffects.Instance.PlayPowerUpAppear();
                            return new RedMushroom(screenLocation);
                    }
                    break;
                case BlockItemType.Coin:
                    var coin = new Coin(screenLocation);
                    coin.Obtain();
                    return coin;
                case BlockItemType.Star:
                    SoundEffects.Instance.PlayPowerUpAppear();
                    return new Star(screenLocation);
                case BlockItemType.GreenMushroom:
                    SoundEffects.Instance.PlayPowerUpAppear();
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

    public enum PowerUpType {
        RedMushroom,
        Flower
    }
}
