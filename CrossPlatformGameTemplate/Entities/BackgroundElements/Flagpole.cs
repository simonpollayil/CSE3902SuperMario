using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Collision;

namespace SuperMario.Entities.BackgroundElements
{
    public class Flagpole : StaticEntity
    {
        Flag flag;
        int flagXOffset = 9;
        int flagYOffset = 12;
        public Flagpole(Vector2 screenLocation) : base(screenLocation)
        {
            Texture2D flagpoleTexture = WinterBackgroundTextureStorage.FlagpoleTextureWinter;
            CurrentSprite = new Sprite(flagpoleTexture, new Rectangle(0, 0, flagpoleTexture.Width, flagpoleTexture.Height));

            flag = new Flag(new Vector2(screenLocation.X - flagXOffset, screenLocation.Y + flagYOffset));

            EntityStorage.Instance.QueueItemEntity(flag);
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
        }

        public void EndGame()
        {
            flag.SlideDown();
        }
    }

}
