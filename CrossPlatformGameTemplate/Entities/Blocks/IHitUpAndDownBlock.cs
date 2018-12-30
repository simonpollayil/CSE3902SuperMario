using Microsoft.Xna.Framework;

namespace SuperMario.Entities.Blocks
{
    public interface IHitUpAndDownBlock
    {
        Vector2 StartLocation { get; set; }
        bool AnimatingUpAndDown { get; set; }

        void Jiggle();
    }
}
