using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuperMario.Collision
{
    public static class RectangleCollider
    {
        public static RectangleCollisions Collide(Rectangle rectangle1, Rectangle rectangle2)
        {
            var rectangleCollisions = new RectangleCollisions();

            var crossArea = Rectangle.Intersect(rectangle1, rectangle2);
            if (crossArea.IsEmpty) 
                return rectangleCollisions;

            var direction = rectangle1.Center.ToVector2() - crossArea.Center.ToVector2();
            var isHorizontal = crossArea.Height >= crossArea.Width;

            RectangleCollision collisionCase;

            if (direction.X <= 0 && direction.Y < 0)
                collisionCase = (isHorizontal ? RectangleCollision.LeftRight : RectangleCollision.BottomTop);
            else if (direction.X > 0 && direction.Y < 0)
                collisionCase = (isHorizontal ? RectangleCollision.RightLeft : RectangleCollision.BottomTop);
            else if (direction.X <= 0 && direction.Y >= 0)
                collisionCase = (isHorizontal ? RectangleCollision.LeftRight : RectangleCollision.TopBottom);
            else
                collisionCase = (isHorizontal ? RectangleCollision.RightLeft : RectangleCollision.TopBottom);

            rectangleCollisions.Collisions.Add(collisionCase);

            return rectangleCollisions;
        }
    }

    public class RectangleCollisions
    {
        public IList<RectangleCollision> Collisions { get; } = new List<RectangleCollision>();
    }

    public enum RectangleCollision {
        TopBottom,
        BottomTop,
        LeftRight,
        RightLeft,
    }
}
