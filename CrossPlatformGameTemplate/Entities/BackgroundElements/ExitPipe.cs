using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Collision;

namespace SuperMario.Entities.BackgroundElements
{
    public class ExitPipe : StaticEntity
    {
        public ExitPipe(Vector2 screenLocation) : base(screenLocation)
        {
            Texture2D exitPipeTexture = WinterBackgroundTextureStorage.ExitPipeTextureWinter;
            CurrentSprite = new Sprite(exitPipeTexture, new Rectangle(0, 0, exitPipeTexture.Width, exitPipeTexture.Height));
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }
}
