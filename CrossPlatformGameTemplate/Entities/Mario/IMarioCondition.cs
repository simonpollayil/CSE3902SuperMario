using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static SuperMario.Entities.Mario.MarioStateEnum;

namespace SuperMario.Entities.Mario
{
    public interface IMarioCondition
    {
        void Update(MarioState marioState, GameTime gameTime);
    }
}