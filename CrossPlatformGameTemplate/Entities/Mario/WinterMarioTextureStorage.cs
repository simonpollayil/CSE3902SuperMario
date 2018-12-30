using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Mario
{
    public static class WinterMarioTextureStorage
    {
        public static Texture2D WinterFireMarioLeftMove { get; private set; }
        public static Texture2D WinterFireMarioRightMove { get; private set; }
        public static Texture2D WinterFireMarioStandStillLeft { get; private set; }
        public static Texture2D WinterFireMarioStandStillRight { get; private set; }
        public static Texture2D WinterFireMarioCrouchedRight { get; private set; }
        public static Texture2D WinterFireMarioCrouchedLeft { get; private set; }
        public static Texture2D WinterFireMarioJumpingLeft { get; private set; }
        public static Texture2D WinterFireMarioJumpingRight { get; private set; }

        public static Texture2D WinterSmallMarioLeftMove { get; private set; }
        public static Texture2D WinterSmallMarioRightMove { get; private set; }
        public static Texture2D WinterSmallMarioStandStillLeft { get; private set; }
        public static Texture2D WinterSmallMarioStandStillRight { get; private set; }
        public static Texture2D WinterSmallMarioJumpingLeft { get; private set; }
        public static Texture2D WinterSmallMarioJumpingRight { get; private set; }

        public static Texture2D WinterSuperMarioLeftMove { get; private set; }
        public static Texture2D WinterSuperMarioRightMove { get; private set; }
        public static Texture2D WinterSuperMarioStandStillLeft { get; private set; }
        public static Texture2D WinterSuperMarioStandStillRight { get; private set; }
        public static Texture2D WinterSuperMarioCrouchedRight { get; private set; }
        public static Texture2D WinterSuperMarioCrouchedLeft { get; private set; }
        public static Texture2D WinterSuperMarioJumpingLeft { get; private set; }
        public static Texture2D WinterSuperMarioJumpingRight { get; private set; }

        public static Texture2D WinterDeadMario { get; private set; }

        public static void LoadAllTextures(ContentManager content)
        {
            WinterFireMarioLeftMove = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/fireMarioLeftMoveWinter");
            WinterFireMarioRightMove = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/fireMarioRightMoveWinter");
            WinterFireMarioStandStillLeft = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/fireMarioLeftStandWinter");
            WinterFireMarioStandStillRight = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/fireMarioRightStandWinter");
            WinterFireMarioCrouchedRight = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/fireMarioRightCrouchWinter");
            WinterFireMarioCrouchedLeft = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/fireMarioLeftCrouchWinter");
            WinterFireMarioJumpingLeft = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/fireMarioJumpLeftWinter");
            WinterFireMarioJumpingRight = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/fireMarioJumpRightWinter");

            WinterSmallMarioLeftMove = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/smallMarioLeftMoveWinter");
            WinterSmallMarioRightMove = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/smallMarioRightMoveWinter");
            WinterSmallMarioStandStillLeft = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/smallMarioLeftStandWinter");
            WinterSmallMarioStandStillRight = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/smallMarioRightStandWinter");
            WinterSmallMarioJumpingLeft = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/smallMarioLeftJumpWinter");
            WinterSmallMarioJumpingRight = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/smallMarioRightJumpWinter");

            WinterSuperMarioLeftMove = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/superMarioMoveLeftWinter");
            WinterSuperMarioRightMove = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/superMarioMoveRightWinter");
            WinterSuperMarioStandStillLeft = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/superMarioLeftStandWinter");
            WinterSuperMarioStandStillRight = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/superMarioRightStandWinter");
            WinterSuperMarioCrouchedLeft = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/superMarioLeftCrouchWinter");
            WinterSuperMarioCrouchedRight = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/superMarioRightCrouchWinter");
            WinterSuperMarioJumpingLeft = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/superMarioJumpLeftWinter");
            WinterSuperMarioJumpingRight = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/superMarioJumpRightWinter");
            WinterDeadMario = content.Load<Texture2D>("WinterSkin/MarioWinterSprites/deadMarioWinter");
        }
    }
}
