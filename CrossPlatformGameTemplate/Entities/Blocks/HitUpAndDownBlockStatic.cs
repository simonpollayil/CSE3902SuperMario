using Microsoft.Xna.Framework;

namespace SuperMario.Entities.Blocks
{
    public abstract class HitUpAndDownBlockStatic : StaticEntity, IHitUpAndDownBlock
    {
        bool movingUp = true;
        float moveIncrement = 1f;
        float moveHeight = 4f;

        public Vector2 StartLocation { get; set; }
        public bool AnimatingUpAndDown { get; set; }

        protected HitUpAndDownBlockStatic(Vector2 screenLocation) : base(screenLocation)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(AnimatingUpAndDown)
            {
                if (movingUp)
                {
                    var currScreenLocation = ScreenLocation;
                    currScreenLocation.Y = currScreenLocation.Y - moveIncrement;
                    ScreenLocation = currScreenLocation;

                    if (ScreenLocation.Y <= StartLocation.Y - (moveIncrement * moveHeight))
                        movingUp = false;
                }
                else
                {
                    var currScreenLocation = ScreenLocation;
                    currScreenLocation.Y = currScreenLocation.Y + moveIncrement;
                    ScreenLocation = currScreenLocation;

                    if (ScreenLocation.Y >= StartLocation.Y)
                    {
                        AnimatingUpAndDown = false;
                        movingUp = true;
                        ScreenLocation = StartLocation;
                    }
                }
            }
        }

        public void Jiggle() 
        {
            if (!AnimatingUpAndDown)
            {
                StartLocation = ScreenLocation;
                AnimatingUpAndDown = true;
            }
        }
    }
}
