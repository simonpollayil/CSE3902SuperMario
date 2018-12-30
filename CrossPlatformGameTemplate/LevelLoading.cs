using System;
using System.Xml;
using Microsoft.Xna.Framework;
using SuperMario.Entities.Blocks;
using SuperMario.Entities.Mario;

namespace SuperMario
{
    public class LevelLoading
    {
        public LevelData LevelObjectsData { get; private set; }

        public void LoadLevel()
        {
            using (XmlReader levelFile = XmlReader.Create("Content/MarioTestAreaLevel.xml"))
            {
                levelFile.ReadToFollowing("LevelHeight");
                int levelHeight = levelFile.ReadElementContentAsInt();
                levelFile.ReadToNextSibling("LevelWidth");
                int levelWidth = levelFile.ReadElementContentAsInt();
                LevelObjectsData = new LevelData(levelHeight, levelWidth);
                levelFile.ReadToFollowing("ObjectData");
                while (!levelFile.EOF)
                {
                    LevelObject levelObject = new LevelObject();
                    levelFile.ReadToDescendant("ObjectType");
                    levelObject.ObjectType = levelFile.ReadElementContentAsString();
                    levelFile.ReadToNextSibling("ObjectName");
                    levelObject.ObjectName = levelFile.ReadElementContentAsString();
                    levelFile.ReadToNextSibling("Location");
                    string location = levelFile.ReadElementContentAsString();
                    int i = location.IndexOf(' ');
                    int xPos = int.Parse(location.Substring(0, i));
                    int yPos = int.Parse(location.Substring(i));
                    levelObject.Location = new Vector2(xPos, yPos);
                    if (levelObject.ObjectType == "Blocks")
                    {
                        levelFile.ReadToNextSibling("BlockItemType");
                        levelObject.BlockItemType = (BlockItemType)Enum.Parse(typeof(BlockItemType), levelFile.ReadElementContentAsString());
                    }
                    if (levelObject.ObjectType.Equals("Mario"))
                    {
                        levelFile.ReadToNextSibling("Lives");
                        levelObject.Lives = levelFile.ReadElementContentAsInt();
                        levelFile.ReadToNextSibling("PlayerType");
                        levelObject.PlayerType = (PlayerSkin)Enum.Parse(typeof(PlayerSkin), levelFile.ReadElementContentAsString());
                    }
                    LevelObjectsData.ObjectData.Add(levelObject);
                    levelFile.ReadToFollowing("Item");
                }
            }
            EntityStorage.Instance.PopulateEntityList(LevelObjectsData);
        }
    }
}
