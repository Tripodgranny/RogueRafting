using System;
using System.Collections.Generic;

namespace RogueRafting.Entities
{
    public class Entity
    {
        public String name = "";
        private int instanceID = 0;
        private bool persistent = false;
        protected bool active = true;

        private static List<Entity> entities = new List<Entity>();

        public Entity()
        {
            instanceID = GenerateID();
            entities.Add(this);
        }

        public bool isPersistent() { return persistent; }
        public void setPersistent(bool p) { persistent = p; }
        public int GetInstanceID() { return instanceID; }
        public static List<Entity> GetEntities() { return entities; }

        public T FindFirstObjectByType<T> (bool listInactiveObjects) where T : Entity
        {
            foreach (Entity entity in entities)
            {
                bool isType = (entity.GetType() == typeof(T));
                if (isType)
                {
                    if (entity.active)
                    {
                        return (T)entity;
                    }
                    else if (listInactiveObjects)
                    {
                        return (T)entity;
                    }
                }
            }
            return null;
        }

        public static Entity Instantiate(Entity entity)
        {
            return null;
        }

        public static void Destroy(Entity entity) 
        {
            entity = null;
        }

        private int GenerateID()
        {
            return Util.RandomNumberGenerator.getInt();
        }

    }
}
