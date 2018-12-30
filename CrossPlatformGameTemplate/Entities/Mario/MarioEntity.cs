using SuperMario.Collision;
using Microsoft.Xna.Framework;
using static SuperMario.Entities.Mario.MarioStateEnum;
using SuperMario.Entities.Mario.MarioCondition;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Desktop;
using SuperMario.Sound;
using SuperMario.ScoreSystem;
using SuperMario.Entities.Mario.CentralizedLifeSystem;
using SuperMario.Entities.Mario.Players;
using System;

namespace SuperMario.Entities.Mario
{
    public class MarioEntity : MovingEntity
    {
        public MarioState CurrentState { get; private set; }
        public MarioConditionState CurrentMarioCondition { get; private set; }

        Vector2 marioOrigin;

        GameTime currentGameTime;

        bool inUnderground;
        bool jumping;
        bool marioBounce;
        bool update;

        long starTimerInTicks;
        long starMarioStartTimeInTicks;

        ICollisionHandler marioCollisionHandler;

        int changeToBigMarioYOffsetCrouching = 6;
        int changeToBigMarioYOffsetStanding = 16;

        int crouchingYOffset = 10;

        int marioSprintVelocity = 4;
        int marioVelocity = 2;

        int marioBottomBounds = 256;

        int drawScoreTimeInTicks = 5000000;
        long scoreToDraw = -1;
        long startScorePopUpDrawTime;

        bool endingGame;
        MarioEndLevelAnimation animationController;
        MarioDyingAnimation dyingAnimation;

        bool firstUpdateCalled = false;
        public bool MarioDead { get; set; } = false;
        public bool PlayerUnderground { get; private set; }

        public IPlayerTexture PlayerTexture { get; private set; }

        public MarioEntity(Vector2 screenLocation, int marioLives, PlayerSkin playerSkin) : base(screenLocation)
        {
            CentralizedLives.Instance.SetInitialLives(marioLives);
            marioOrigin = screenLocation;
            ScreenLocation = screenLocation;
            CurrentState = MarioState.FacingRight;

            EntityXDirection = Direction.IdleRight;
            EntityYDirection = Direction.IdleRight;
            EntityVelocity = new Vector2(2, 4);
            jumping = false;
            marioBounce = false;
            inUnderground = false;
            PlayerUnderground = false;
            update = true;

            starTimerInTicks = 150000000;

            marioCollisionHandler = new MarioCollisionHandler(this);

            dyingAnimation = new MarioDyingAnimation(this, marioOrigin);

            IPlayerTexture playerTexture;
            PlayerTextureMap.PlayerTypes.TryGetValue(playerSkin, out playerTexture);
            PlayerTexture = playerTexture;

            CurrentMarioCondition = new SmallMario(PlayerTexture.SmallPlayer);
        }

        void ConditionChangeUpdateScreenLocation(PlayerCondition nextMarioCondition)
        {
            Vector2 updatedScreenLocation = ScreenLocation;

            if (CurrentConditionIsSmallCondtion() && !nextMarioCondition.Equals(PlayerCondition.Small) && !nextMarioCondition.Equals(PlayerCondition.StarSmall))
            {
                if (CurrentStateIsCrouchedState())
                    updatedScreenLocation.Y -= changeToBigMarioYOffsetCrouching;
                else
                    updatedScreenLocation.Y -= changeToBigMarioYOffsetStanding;
            }
            else if (!CurrentConditionIsSmallCondtion() && (nextMarioCondition.Equals(PlayerCondition.Small) || nextMarioCondition.Equals(PlayerCondition.StarSmall)))
            {
                if (CurrentStateIsCrouchedState())
                    updatedScreenLocation.Y += changeToBigMarioYOffsetCrouching;
                else
                    updatedScreenLocation.Y += changeToBigMarioYOffsetStanding;
            }

            SetScreenLocation(updatedScreenLocation);
            CurrentMarioCondition.SetScreenLocation(ScreenLocation);
        }

        public void SetMarioConditionState(PlayerCondition proposedNewCondition)
        {
            ConditionChangeUpdateScreenLocation(proposedNewCondition);

            BuildMarioCondition(proposedNewCondition);
        }

        void BuildMarioCondition(PlayerCondition proposedNewCondition)
        {
            if (CurrentConditionIsStarCondition())
            {
                if (proposedNewCondition.Equals(PlayerCondition.Fire))
                    CurrentMarioCondition = new StarFireMario(PlayerTexture.FirePlayer);
                if (proposedNewCondition.Equals(PlayerCondition.Super)) 
                    CurrentMarioCondition = new StarSuperMario(PlayerTexture.SuperPlayer);
                if (proposedNewCondition.Equals(PlayerCondition.Small))
                    CurrentMarioCondition = new StarSmallMario(PlayerTexture.SmallPlayer);
            }
            else
            {
                switch (proposedNewCondition)
                {
                    case PlayerCondition.Dead:
                        CurrentMarioCondition = new DeadMario(PlayerTexture.SmallPlayer);
                        break;
                    case PlayerCondition.Small:
                        CurrentMarioCondition = new SmallMario(PlayerTexture.SmallPlayer);
                        break;
                    case PlayerCondition.Super:
                        CurrentMarioCondition = new SuperMarioEntity(PlayerTexture.SuperPlayer);
                        break;
                    case PlayerCondition.Fire:
                        CurrentMarioCondition = new FireMario(PlayerTexture.FirePlayer);
                        break;
                    case PlayerCondition.StarSmall:
                        CurrentMarioCondition = new StarSmallMario(PlayerTexture.SmallPlayer);
                        break;
                    case PlayerCondition.StarSuper:
                        CurrentMarioCondition = new StarSuperMario(PlayerTexture.SuperPlayer);
                        break;
                    case PlayerCondition.StarFire:
                        CurrentMarioCondition = new StarFireMario(PlayerTexture.FirePlayer);
                        break;
                }

            }
        }

        public void SetMarioXDirection(Direction xDirection)
        {
            if (xDirection.Equals(Direction.Idle))
            {
                if (EntityXDirection.Equals(Direction.Left))
                    EntityXDirection = Direction.IdleLeft;
                else if (EntityXDirection.Equals(Direction.Right))
                    EntityXDirection = Direction.IdleRight;
            }
            else
                EntityXDirection = xDirection;
        }

        public void SetMarioYDirection(Direction yDirection)
        {
            EntityYDirection = yDirection;
        }

        public void MarioFuneral()
        {
            if (!MarioDead)
            {
                CentralizedLives.Instance.RemoveOneLife();
                Music.Event();
                dyingAnimation = new MarioDyingAnimation(this, marioOrigin);
                MarioDead = true;
            }

            dyingAnimation.RunAnimation(currentGameTime);
        }

        public void ActivateAbility(bool use)
        {
            CurrentMarioCondition.ActivateAbility(use, EntityXDirection, currentGameTime);

            if (use)
            {
                if (CurrentMarioCondition.PlayerConditionType.Equals(PlayerCondition.Super) || CurrentMarioCondition.PlayerConditionType.Equals(PlayerCondition.StarSuper))
                    EntityVelocity = new Vector2(marioSprintVelocity, EntityVelocity.Y);
            }
            else
                EntityVelocity = new Vector2(marioVelocity, EntityVelocity.Y);
        }

        public void EnemyHitMarioBounce()
        {
            marioBounce = true;
            GravityVelocity = 0;
        }

        void Bounce()
        {
            float bounceVelocity = 2;

            if (GravityVelocity <= bounceVelocity)
                ScreenLocation = new Vector2(ScreenLocation.X, ScreenLocation.Y - bounceVelocity);
            else
                marioBounce = false;
        }

        void Jump()
        {
            if (Grounded)
            {
                jumping = true;
                SoundEffects.Instance.PlayJump();
            }
            else if (jumping && GravityVelocity >= EntityVelocity.Y)
                jumping = false;

            if (jumping)
                ScreenLocation = new Vector2(ScreenLocation.X, ScreenLocation.Y - EntityVelocity.Y);
        }

        protected override void UpdateXDirectionWithRestrictions()
        {
            switch (EntityXDirection)
            {
                case Direction.Left:
                    if (RestrictedMovementDirections.Contains(Direction.Left))
                        EntityXDirection = Direction.IdleLeft;
                    break;
                case Direction.Right:
                    if (RestrictedMovementDirections.Contains(Direction.Right))
                        EntityXDirection = Direction.IdleRight;
                    break;
            }
        }

        protected override void Move()
        {
            base.Move();

            if (!RestrictedMovementDirections.Contains(Direction.Up) && (marioBounce || EntityYDirection.Equals(Direction.Up)))
            {
                if (marioBounce)
                    Bounce();
                else
                    Jump();
            }
            else
            {
                jumping = false;
                marioBounce = false;
            }
        }

        void StateChangeUpdateScreenLocation(MarioState nextState)
        {
            Vector2 updatedScreenLocation = ScreenLocation;

            if (!CurrentConditionIsSmallCondtion())
            {
                if (!CurrentStateIsCrouchedState() && (nextState.Equals(MarioState.CrouchingLeft) || nextState.Equals(MarioState.CrouchingRight)))
                    updatedScreenLocation.Y += crouchingYOffset;
                else if (CurrentStateIsCrouchedState() && !(nextState.Equals(MarioState.CrouchingLeft) || nextState.Equals(MarioState.CrouchingRight)))
                    updatedScreenLocation.Y -= crouchingYOffset;
            }

            SetScreenLocation(updatedScreenLocation);
            CurrentMarioCondition.SetScreenLocation(ScreenLocation);
        }

        public void SetMarioState(MarioCommands marioCommand)
        {
            if(marioCommand is MarioCommands.Hit)
                SoundEffects.Instance.PlayPipe();

            var tuple = MarioStateMachine.GetNextMarioState(CurrentMarioCondition.PlayerConditionType, CurrentState, marioCommand);
            if(!tuple.marioCondition.Equals(CurrentMarioCondition.PlayerConditionType) || !tuple.marioState.Equals(CurrentState))
            {
                SetMarioConditionState(tuple.marioCondition);
                StateChangeUpdateScreenLocation(tuple.marioState);
                CurrentState = tuple.marioState;

                if (MarioCommands.Star == marioCommand)
                    starMarioStartTimeInTicks = currentGameTime.TotalGameTime.Ticks;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (ScreenLocation.Y > marioBottomBounds || HUDController.Instance.TimeInTicks<= 0)
                CurrentMarioCondition = new DeadMario(PlayerTexture.SmallPlayer);

            if (CurrentMarioCondition.PlayerConditionType.Equals(PlayerCondition.Dead))
                MarioFuneral();
            else if (!endingGame)
            {
                if (CurrentConditionIsStarCondition() && currentGameTime.TotalGameTime.Ticks - starMarioStartTimeInTicks > starTimerInTicks)
                    LoseStarState();

                Move();
                CurrentMarioCondition.Update(CurrentState, gameTime);
                CurrentMarioCondition.SetScreenLocation(ScreenLocation);
                CurrentSprite = CurrentMarioCondition.CurrentStateSprite;
                RestrictedMovementDirections.Clear();
            }
            else
                animationController.RunAnimation(gameTime);

            currentGameTime = gameTime;

            CurrentMarioCondition.Update(CurrentState, gameTime);
            CurrentSprite = CurrentMarioCondition.CurrentStateSprite;

            if(update)
                base.Update(gameTime);

            if (!firstUpdateCalled)
                firstUpdateCalled = true;

            if(scoreToDraw > -1 && currentGameTime.TotalGameTime.Ticks - startScorePopUpDrawTime > drawScoreTimeInTicks)
                scoreToDraw = -1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (firstUpdateCalled)
            {
                CurrentSprite.Draw(ScreenLocation, spriteBatch);

                if (scoreToDraw > -1)
                {
                    int popUpLocationXOffset = 5;
                    int popUpLocationYOffset = -25;

                    spriteBatch.DrawString(FontManager.ScoreFont, "" + scoreToDraw, new Vector2(ScreenLocation.X + popUpLocationXOffset, ScreenLocation.Y + popUpLocationYOffset), Color.NavajoWhite);
                }
            }
        }

        public void StartEndGameSequence()
        {
            if(!endingGame)
            {
                endingGame = true;
                Music.Event();
                SoundEffects.Instance.PlayFlagpole();
                animationController = new MarioEndLevelAnimation(this, ScreenLocation);
            }
        }

        public bool IsMarioEndGame()
        {
            return endingGame;
        }

        public bool CurrentStateIsCrouchedState()
        {
            return CurrentState.Equals(MarioState.CrouchingRight) || CurrentState.Equals(MarioState.CrouchingLeft);
        }

        public bool CurrentConditionIsStarCondition()
        {
            return CurrentMarioCondition.PlayerConditionType.Equals(PlayerCondition.StarFire) || CurrentMarioCondition.PlayerConditionType.Equals(PlayerCondition.StarSmall) || CurrentMarioCondition.PlayerConditionType.Equals(PlayerCondition.StarSuper);
        }

        public bool CurrentConditionIsSmallCondtion()
        {
            return CurrentMarioCondition.PlayerConditionType.Equals(PlayerCondition.Small) || CurrentMarioCondition.PlayerConditionType.Equals(PlayerCondition.StarSmall);
        }

        public override void Collide(Entity entity, RectangleCollisions collisions)
        {
            RestrictedMovementDirections.UnionWith(marioCollisionHandler.Collide(entity, collisions));
        }

        void LoseStarState()
        {
            Music.Event();

            if (CurrentMarioCondition.PlayerConditionType.Equals(PlayerCondition.StarFire))
                CurrentMarioCondition = new FireMario(PlayerTexture.FirePlayer);
            if (CurrentMarioCondition.PlayerConditionType.Equals(PlayerCondition.StarSmall))
                CurrentMarioCondition = new SmallMario(PlayerTexture.SmallPlayer);
            if (CurrentMarioCondition.PlayerConditionType.Equals(PlayerCondition.StarSuper))
                CurrentMarioCondition = new SuperMarioEntity(PlayerTexture.SuperPlayer);
        }

        public void DrawScorePopUp(long score)
        {
            scoreToDraw = score;
            startScorePopUpDrawTime = currentGameTime.TotalGameTime.Ticks;
        }

        public void Warp()
        {
            Music.Event();
            var pipeXLocationMax = 1295;
            var pipeXLocationMin = 1275;
            var undergroundSpawnLocation = new Vector2(220, -420);

            if (ScreenLocation.X < pipeXLocationMax && ScreenLocation.X > pipeXLocationMin)
            {
                PlayerUnderground = true;
                Game1.BackgroundColor = Color.Black;
                ScreenLocation = undergroundSpawnLocation;
                CurrentState = MarioState.FacingRight;
                Grounded = false;
                inUnderground = true;
                SoundEffects.Instance.PlayPipe();
            }
        }

        public void WarpBack()
        {
            Music.Event();
            SoundEffects.Instance.PlayPipe();
            inUnderground = false;
            var yMinForWarpingBack = -150;
            var spawnAboveGroundLocation = new Vector2(2936, 170);

            if (ScreenLocation.Y > yMinForWarpingBack)
            {
                ScreenLocation = spawnAboveGroundLocation;
                PlayerUnderground = false;
                Game1.BackgroundColor = Color.CornflowerBlue;
                CurrentState = MarioState.FacingRight;
            }
        }

        public void ToggleUpdate()
        {
            update = !update;
        }

        public bool IsMarioUnderGround()
        {
            return inUnderground;
        }
    }
}