using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuperMario.Collision;

namespace SuperMario.Entities.Mario
{
    public class DeadMario : StaticEntity
    {
        public DeadMario(Vector2 screenLocation) : base(screenLocation)
        {
            this.CurrentSprite = new Sprite(MarioTextureStorage.DeadMario, new Rectangle(0, 0, 15, 14));
        }

        public override List<MovementDirectionsEnum.MovementDirection> Collide(Entity entity, ICollisions collisions)
        {
            return new List<MovementDirectionsEnum.MovementDirection>();
        }

        public override void Reset()
        {
        }
    }
}
