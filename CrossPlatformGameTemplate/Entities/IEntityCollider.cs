using System.Collections.Generic;

namespace SuperMario.Entities
{
    public interface IEntityCollider
    {
        IList<Direction> RunCollision();
    }
}
