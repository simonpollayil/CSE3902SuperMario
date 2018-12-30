using SuperMario.Entities.Mario.MarioDecor;
using Microsoft.Xna.Framework;
using static SuperMario.Entities.Mario.MarioStateEnum;

namespace SuperMario.Entities.Mario
{
    public class Mario : Entity
    {
        MarioState currentState;

        MarioDecorator currentMarioDecorator;

        Entity deadMario;

        public Mario(Vector2 screenLocation) : base(screenLocation)
        {
            this.ScreenLocation = screenLocation;

            deadMario = new DeadMario(screenLocation);

            currentMarioDecorator = new SmallMario();
            currentMarioDecorator.SetScreenLocation(screenLocation);
            currentState = MarioState.FacingRight;
        }

        public void SetMarioDecoration(MarioDecorator decor)
        {
            currentMarioDecorator = decor;
            currentMarioDecorator.SetScreenLocation(ScreenLocation);

            if (currentState.Equals(MarioState.Dead))
                currentState = MarioState.FacingRight;
        }

        public void SetMarioState(MarioCommands marioCommand)
        {
            currentState = MarioStateMachine.GetNextMarioState(currentState, marioCommand);
        }

        public override void Update(GameTime gameTime)
        {
            if (!currentState.Equals(MarioState.Dead))
                currentMarioDecorator.Update(currentState, gameTime);
        }

        public override void Draw()
        {
            if (!currentState.Equals(MarioState.Dead))
                currentMarioDecorator.Draw(currentState);
            else
                deadMario.Draw();
        }

        public override void Reset()
        {
            currentMarioDecorator = new SmallMario();
            currentMarioDecorator.SetScreenLocation(ScreenLocation);
            currentState = MarioState.FacingRight;
        }
    }
}
