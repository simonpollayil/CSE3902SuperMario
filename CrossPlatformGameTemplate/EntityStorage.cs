using SuperMario.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using SuperMario.Collision;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Entities.Blocks;
using SuperMario.Entities.Enemies;

namespace SuperMario
{
    public sealed class EntityStorage
    {
        public IList<Entity> BackgroundEntityList { get; private set; }
        public IList<Entity> BlockEntityList { get; private set; }
        public IList<Entity> EnemyEntityList { get; private set; }
        public IList<Entity> ItemEntityList { get; private set; }
        public IList<Entity> PlayerEntityList { get; private set; }
        public IList<Entity> EntityList { get; private set; }

        IList<Entity> queuedEntitiesToRemove = new List<Entity>();
        IList<Entity> ItemsToAdd { get; } = new List<Entity>();

        public static EntityStorage Instance { get; } = new EntityStorage();

        private EntityStorage() {}

        public void SetEntityList(IList<Entity> value)
        {
            EntityList = value;
        }

        private static Entity CreateEntity(LevelObject levelObject)
        {
            string typeName = "SuperMario.Entities." + levelObject.ObjectType + "." + levelObject.ObjectName;
            Type entityType = Type.GetType(typeName);
            if (levelObject.ObjectType == "Blocks")
                if (levelObject.ObjectName.Equals("ShinyBlock") || levelObject.ObjectName.Equals("GravelBlock") || levelObject.ObjectName.Equals("HitBlock") || levelObject.ObjectName.Equals("BlueGravelBlock"))
                    return Activator.CreateInstance(entityType, levelObject.Location) as Entity;
                else
                    return Activator.CreateInstance(entityType, levelObject.Location, levelObject.BlockItemType) as Entity;
            if (levelObject.ObjectType.Equals("Mario"))
                return Activator.CreateInstance(entityType, levelObject.Location, levelObject.Lives, levelObject.PlayerType) as Entity;

            return Activator.CreateInstance(entityType, levelObject.Location) as Entity;
        }

        public void PopulateEntityList(LevelData levelData)
        {
            BackgroundEntityList = new List<Entity>();
            BlockEntityList = new List<Entity>();
            EnemyEntityList = new List<Entity>();
            ItemEntityList = new List<Entity>();
            PlayerEntityList = new List<Entity>();
            SetEntityList(new List<Entity>());
           
            foreach (LevelObject levelObject in levelData.ObjectData)
            {
                Entity entity = CreateEntity(levelObject);
                EntityList.Add(entity);
                if (levelObject.ObjectType.Equals("BackgroundElements"))
                    BackgroundEntityList.Add(entity);
                else if (levelObject.ObjectType.Equals("Blocks"))
                    BlockEntityList.Add(entity);
                else if (levelObject.ObjectType.Equals("Enemies"))
                {
                    if (entity is MovingEntity)
                        MasterCollider.Colliders.Add(entity);
                    EnemyEntityList.Add(entity);
                }
                else if (levelObject.ObjectType.Equals("Items"))
                {
                    if (entity is MovingEntity)
                        MasterCollider.Colliders.Add(entity);
                    ItemEntityList.Add(entity);
                }
                else
                {
                    if (entity is MovingEntity)
                        MasterCollider.Colliders.Add(entity);
                    PlayerEntityList.Add(entity);
                }
            }
        }

        public void PopulateEntityListNotPlayers(LevelData levelData)
        {
            BackgroundEntityList = new List<Entity>();
            BlockEntityList = new List<Entity>();
            EnemyEntityList = new List<Entity>();
            ItemEntityList = new List<Entity>();
            SetEntityList(new List<Entity>());

            foreach (LevelObject levelObject in levelData.ObjectData)
            {
                if(!levelObject.ObjectType.Equals("Mario"))
                {
                    Entity entity = CreateEntity(levelObject);
                    EntityList.Add(entity);
                    if (levelObject.ObjectType.Equals("BackgroundElements"))
                        BackgroundEntityList.Add(entity);
                    else if (levelObject.ObjectType.Equals("Blocks"))
                        BlockEntityList.Add(entity);
                    else if (levelObject.ObjectType.Equals("Enemies"))
                    {
                        if (entity is MovingEntity)
                            MasterCollider.Colliders.Add(entity);
                        EnemyEntityList.Add(entity);
                    }
                    else if (levelObject.ObjectType.Equals("Items"))
                    {
                        if (entity is MovingEntity)
                            MasterCollider.Colliders.Add(entity);
                        ItemEntityList.Add(entity);
                    }
                }
            }
        }

        void RemoveEntity(Entity entityToRemove)
        {
            if (entityToRemove is IEnemy)
                EnemyEntityList.Remove(entityToRemove);
            else if (entityToRemove is IHitUpAndDownBlock)
                BlockEntityList.Remove(entityToRemove);
            else
                ItemEntityList.Remove(entityToRemove);

            queuedEntitiesToRemove.Add(entityToRemove);
            MasterCollider.Colliders.Remove(entityToRemove);
        }

        public void UpdateAllEntities(GameTime gameTime)
        {
            foreach (Entity entityToRemove in queuedEntitiesToRemove)
                EntityList.Remove(entityToRemove);
            queuedEntitiesToRemove.Clear();

            foreach (Entity entity in EntityList)
            {
                if (entity.Remove)
                    RemoveEntity(entity);
                else
                    entity.Update(gameTime);
            }
        }

        public void DrawAllEntities(SpriteBatch spriteBatch)
        {
            //Set draw order; Background entities must draw before all other entities
            foreach (Entity entity in BackgroundEntityList)
                entity.Draw(spriteBatch);
            foreach (Entity entity in BlockEntityList)
                entity.Draw(spriteBatch);
            foreach (Entity entity in EnemyEntityList)
                entity.Draw(spriteBatch);
            foreach (Entity entity in ItemEntityList)
                entity.Draw(spriteBatch);
            foreach (Entity entity in PlayerEntityList)
                entity.Draw(spriteBatch);
        }

        public void QueueItemEntity(Entity item) {
            ItemsToAdd.Add(item);
        }

        public void AddQueuedItems()
        {
            foreach(Entity item in ItemsToAdd)
            {
                ItemEntityList.Add(item);
                EntityList.Add(item);
                MasterCollider.Colliders.Add(item);
            }

            ItemsToAdd.Clear();
        }
    }
}
