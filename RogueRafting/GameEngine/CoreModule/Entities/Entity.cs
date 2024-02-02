using RogueRafting.GameEngine.CoreModule.Entities.Components;
using RogueRafting.GameEngine.CoreModule.Entities.Components.Behaviors;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RogueRafting.GameEngine.CoreModule.Entities
{

    ///@author adf
    /// <summary>
    /// Entity is the top level class of all GameObjects, Components, ect...
    /// </summary>
    public class Entity
    {
        // TODO: Instantiate method
        //       Destroy method needs implementation to destroy components, and children

        public string name = "";
        private int instanceID = 0;
        private bool persistent = false;
        protected bool active = true;

        public Entity()
        {
            instanceID = GenerateID();
            Scene.entities.Add(this);
        }

        /// <summary>
        /// Return if this entity is persistent between scenes
        /// </summary>
        public bool isPersistent() { return persistent; }

        /// <summary>
        /// Set this entities persistence
        /// <para>If the entity is persistent it isn't destroyed upon switching scenes</para> 
        /// </summary>
        public void setPersistent(bool p) { persistent = p; }

        /// <summary>
        /// Return the instance ID of this entity
        /// </summary>
        public int GetInstanceID() { return instanceID; }

        /// <summary>
        /// Find first entity of type T
        /// <example>
        /// <code>
        /// GameObject obj = FindFirstObjectByType&lt;GameObject&gt;(false);
        /// PlayerMovement script = FindFirstObjectByType&lt;PlayerMovement&gt;(false);
        /// </code>
        /// </example>
        /// </summary>
        public static T FindFirstObjectByType<T>(bool listInactiveObjects) where T : Entity
        {
            foreach (Entity entity in Scene.entities)
            {
                bool isType = entity.GetType() == typeof(T);
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

        /// <summary>
        /// Find all entities of type T
        /// <example>
        /// <code>
        /// List&lt;GameObject&gt; obj = FindAllObjectsByType&lt;GameObject&gt;(false);
        /// List&lt;SpriteRenderer&gt; script = FindAllObjectsByType&lt;SpriteRenderer&gt;(false);
        /// </code>
        /// </example>
        /// </summary>
        public static List<T> FindAllObjectsByType<T>(bool listInactiveObjects) where T : Entity
        {
            List<T> entityList = new List<T>();
            foreach (Entity entity in Scene.entities)
            {
                bool isType = entity.GetType() == typeof(T);
                if (isType)
                {
                    if (entity.active)              // Add to list if active
                    {
                        entityList.Add((T)entity);
                    }
                    else if (listInactiveObjects)   // Add to list if inactive entites are added
                    {
                        entityList.Add((T)entity);
                    }
                }
            }
            return entityList.Count > 0 ? entityList : null;
        }

        public static Entity Instantiate(Entity entity)
        {
            return null;
        }


        /// <summary>
        /// Destroy any entity
        /// <code>
        /// Destroy(gameObject);
        /// Destroy(this);
        /// </code>
        /// </summary>
        public static void Destroy(Entity entity)
        {
            Debug.WriteLine("Destroyed " + entity.name);
            var type = entity.GetType();
            if (type == typeof(GameObject))
                DestroyGameObject((GameObject)entity);
            if (typeof(MonoBehavior).IsAssignableFrom(type))
                DestroyScript((MonoBehavior)entity);
            if (typeof(Component).IsAssignableFrom(type))
                DestroyComponentsOfTypeOnGameObject(((Component)entity).gameObject, entity);

            Debug.WriteLine("Destroyed " + entity.name);

        }

        /// <summary>
        /// Destroy the game object including all of its components and children
        /// </summary>
        public static void DestroyGameObject(GameObject go)
        {
            DestroyAllComponentsOnGameObject(go);
            Scene.entities.Remove(go);
            go = null;
        }

        /// <summary>
        /// Destroy the game objects including all of its components and children 
        /// </summary>
        public static void DestroyGameObjects(List<GameObject> go)
        {
            if (go == null || go.Count <= 0)
                return;
            for (int i = 0; i < go.Count; i++)
            {
                if (go[i] == null) return;
                DestroyAllComponentsOnGameObject(go[i]);
                Scene.entities.Remove(go[i]);
                go[i] = null;
            }
        }

        /// <summary>
        /// Destroy all components on a gameobject
        /// </summary>
        private static void DestroyAllComponentsOnGameObject(GameObject go)
        {
            if (go.GetComponentList() == null)
                return; 

            List<Component> componentList = go.GetComponentList();
            if (go.GetComponentList().Count >= 0)
            {
                for (int i = 0; i < componentList.Count; i++)
                {
                    var type = componentList[i].GetType();
                    if (typeof(MonoBehavior).IsAssignableFrom(type))
                        GameObject.RemoveScript((MonoBehavior)componentList[i]);

                    Scene.entities.Remove(componentList[i]);
                    go.GetComponentList().Remove(componentList[i]);
                }
            }
        }

        /// <summary>
        /// Destroy all components of a particular type on a gameobject.
        /// Can't destroy Transform.
        /// </summary>
        private static void DestroyComponentsOfTypeOnGameObject(GameObject go, Entity entity)
        {
            if (entity.GetType() == typeof(Transform)) // cannot destroy a transform.
                return;

            List<Component> componentList = go.GetComponentList();
            if (go.GetComponentList().Count >= 0)
            {
                for (int i = 0; i < componentList.Count; i++)
                {
                    var type = componentList[i].GetType();
                    if (componentList[i].GetType().IsAssignableFrom(entity.GetType()))
                    {
                        Scene.entities.Remove(componentList[i]);
                        go.GetComponentList().Remove(componentList[i]);
                    }
                }
            }
        }

        private static void DestroyScript(MonoBehavior script)
        {
            GameObject go = script.gameObject;
            List<Component> componentList = go.GetComponentList();
            if (componentList.Contains(script))
            {
                GameObject.RemoveScript(script);
                Scene.entities.Remove(script);
                go.GetComponentList().Remove(script);
            }
        }

        /// <summary>
        /// Generate unique instance ID 
        /// </summary>
        private int GenerateID()
        {
            return Util.RandomNumberGenerator.getInt();
        }

    }
}
