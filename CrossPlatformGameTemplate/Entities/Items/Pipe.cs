using SuperMario.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Items
{
    public class Pipe : StaticEntity
    {
        public Pipe(Vector2 screenLocation) : base(screenLocation)
        {
            Texture2D pipeTexture = WinterTextureStorage.PipeSpriteSheetWinter;
            CurrentSprite = new Sprite(pipeTexture, new Rectangle(0, 0, pipeTexture.Width, pipeTexture.Height));
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }
    }
}
