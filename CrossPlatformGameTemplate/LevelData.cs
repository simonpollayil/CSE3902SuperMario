using Microsoft.Xna.Framework;
using SuperMario.Entities.Blocks;
using SuperMario.Entities.Mario;
using System.Collections.Generic;

namespace SuperMario
{
    public class LevelData
    {
        public IList<LevelObject> ObjectData { get; private set; }
        public int LevelHeight { get; private set; }
        public int LevelWidth { get; private set; }

        public void SetObjectData(IList<LevelObject> value)
        {
            ObjectData = value;
        }

        public LevelData(int levelHeight, int levelWidth)
        {
            LevelHeight = levelHeight;
            LevelWidth = levelWidth;
            SetObjectData(new List<LevelObject>());
        }
    }

    public class LevelObject
    {
        public string ObjectType { get; set; }
        public string ObjectName { get; set; }
        public Vector2 Location { get; set; }
        public BlockItemType BlockItemType { get; set; }
        public int Lives { get; set; }
        public PlayerSkin PlayerType { get; set; }
    }
}
