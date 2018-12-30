using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Entities.Mario
{
    public static class MarioTextureStorage
    {
        public static Texture2D FireMarioLeftMove { get; private set; }
        public static Texture2D FireMarioRightMove { get; private set; }
        public static Texture2D FireMarioStandStillLeft { get; private set;}
        public static Texture2D FireMarioStandStillRight { get; private set; } 
        public static Texture2D FireMarioCrouchedRight { get; private set; }
        public static Texture2D FireMarioCrouchedLeft { get; private set; }
        public static Texture2D FireMarioJumpingLeft { get; private set; }
        public static Texture2D FireMarioJumpingRight { get; private set; }

        public static Texture2D SmallMarioLeftMove { get; private set; }
        public static Texture2D SmallMarioRightMove { get; private set; }
        public static Texture2D SmallMarioStandStillLeft { get; private set; }
        public static Texture2D SmallMarioStandStillRight { get; private set; }
        public static Texture2D SmallMarioJumpingLeft { get; private set; }
        public static Texture2D SmallMarioJumpingRight { get; private set; }

        public static Texture2D SuperMarioLeftMove { get; private set; }
        public static Texture2D SuperMarioRightMove { get; private set; }
        public static Texture2D SuperMarioStandStillLeft { get; private set; }
        public static Texture2D SuperMarioStandStillRight { get; private set; }
        public static Texture2D SuperMarioCrouchedRight { get; private set; }
        public static Texture2D SuperMarioCrouchedLeft { get; private set; }
        public static Texture2D SuperMarioJumpingLeft { get; private set; }
        public static Texture2D SuperMarioJumpingRight { get; private set; }

        public static Texture2D DeadMario { get; private set; }

        public static void LoadAllTextures(ContentManager content)
        {
            FireMarioLeftMove = content.Load<Texture2D>("MarioSprites/fireMarioLeftMove");
            FireMarioRightMove = content.Load<Texture2D>("MarioSprites/fireMarioRightMove");
            FireMarioStandStillLeft = content.Load<Texture2D>("MarioSprites/fireMarioLeftStand");
            FireMarioStandStillRight = content.Load<Texture2D>("MarioSprites/fireMarioRightStand");
            FireMarioCrouchedRight = content.Load<Texture2D>("MarioSprites/fireMarioRightCrouch");
            FireMarioCrouchedLeft = content.Load<Texture2D>("MarioSprites/fireMarioLeftCrouch");
            FireMarioJumpingLeft = content.Load<Texture2D>("MarioSprites/fireMarioJumpLeft");
            FireMarioJumpingRight = content.Load<Texture2D>("MarioSprites/fireMarioJumpRight");

            SmallMarioLeftMove = content.Load<Texture2D>("MarioSprites/smallMarioLeftMove");
            SmallMarioRightMove = content.Load<Texture2D>("MarioSprites/smallMarioRightMove");
            SmallMarioStandStillLeft = content.Load<Texture2D>("MarioSprites/smallMarioLeftStand");
            SmallMarioStandStillRight = content.Load<Texture2D>("MarioSprites/smallMarioRightStand");
            SmallMarioJumpingLeft = content.Load<Texture2D>("MarioSprites/smallMarioLeftJump");
            SmallMarioJumpingRight = content.Load<Texture2D>("MarioSprites/smallMarioRightJump");

            SuperMarioLeftMove = content.Load<Texture2D>("MarioSprites/superMarioMoveLeft");
            SuperMarioRightMove = content.Load<Texture2D>("MarioSprites/superMarioMoveRight");
            SuperMarioStandStillLeft = content.Load<Texture2D>("MarioSprites/superMarioLeftStand");
            SuperMarioStandStillRight = content.Load<Texture2D>("MarioSprites/superMarioRightStand");
            SuperMarioCrouchedLeft = content.Load<Texture2D>("MarioSprites/superMarioLeftCrouch");
            SuperMarioCrouchedRight = content.Load<Texture2D>("MarioSprites/superMarioRightCrouch");
            SuperMarioJumpingLeft = content.Load<Texture2D>("MarioSprites/superMarioJumpLeft");
            SuperMarioJumpingRight = content.Load<Texture2D>("MarioSprites/superMarioJumpRight");

            DeadMario = content.Load<Texture2D>("MarioSprites/deadMario");
        }
    }
}
