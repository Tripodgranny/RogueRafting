﻿using Microsoft.Xna.Framework;
using RogueRafting.GameEngine.CoreModule.Entities.Components;
using RogueRafting.GameEngine.CoreModule.Entities.Components.Behaviors;
using RogueRafting.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace RogueRafting.GameEngine.CoreModule.Entities
{
    // TODO: implement GetChild method, implement Layer Class and methods, implement Tags.
    public class GameObject : Entity
    {
        private Tag tag;
        private bool activeInHierarchy = true;
        private bool activeSelf = true;
        private List<Component> components = new List<Component>();
        private List<GameObject> children = new List<GameObject>();
        public Transform transform;

        private GameObject parent;
        private Scene scene;

        // Layer - unimplemented

        public GameObject()
        {
            transform = AddComponent<Transform>();
            tag = Tag.DEFAULT;
        }

        public GameObject(Vector2 position, float rotation)
        {
            transform = AddComponent<Transform>();
            transform.rotation = rotation;
            transform.position = position;
            tag = Tag.DEFAULT;

        }
        //==========================================================================================
        // SCRIPT METHODS
        //==========================================================================================

        public static void AddScript(MonoBehavior behavior)
        {
            Scene.monobehaviors.Add(behavior);
        }

        public static void RemoveScript(MonoBehavior behavior)
        {
            Scene.monobehaviors.Remove(behavior);
            Debug.WriteLine("Monobehaviors: " + Scene.monobehaviors);
        }

        public static List<MonoBehavior> GetAllScripts() { return Scene.monobehaviors; }

        //==========================================================================================
        // GET/SET METHODS
        //==========================================================================================

        public void SetTag(Tag tag) { this.tag = tag; }
        public bool IsActive() { return activeSelf; }
        public bool IsActiveInHierarchy() { return activeInHierarchy; }
        public void SetActive(bool act)
        {
            if (parent != null && !parent.activeSelf)
                return;

            active = act;
            activeSelf = act;
        }
        public void SetActiveInHierarchy(bool act)
        {
            if (parent != null && !parent.activeSelf)
                return;

            active = act;
            activeInHierarchy = act;
            activeSelf = act;
        }

        public static Scene GetScene(int instanceID)
        {
            foreach (GameObject go in Scene.entities)
            {
                if (go.GetInstanceID() == instanceID)
                    return go.scene;
            }
            return null;
        }

        public GameObject GetParent() { return parent; }
        public int GetChildCount() { return children.Count; }
        public void SetParent(GameObject go) => parent = go;
        public void RemoveParent(GameObject go) => parent = null;

        public void AddChild(GameObject go)
        {
            if (children.Contains(go))
                return;

            children.Add(go);
        }

        /// <summary>
        /// Remove a child object from this game object
        /// </summary>
        public void RemoveChild(GameObject go)
        {
            if (children == null)
                return;
            if (children.Contains(go))
                children.Remove(go);
        }
        //==========================================================================================
        // FIND METHODS
        //==========================================================================================
        /// <summary>
        /// Finds all game objects with the passed in tag name.
        /// <returns>List GameObjects</returns> 
        /// </summary>
        public List<GameObject> FindGameObjectsWithTag(string tag)
        {
            if (Scene.gameObjects.Count <= 0)
                return null;

            List<GameObject> goWithTagList = new List<GameObject>();
            for (int i = 0; i < Scene.gameObjects.Count; i++)
            {   // Compare Tag of object in list to passed in tag.
                if (Scene.gameObjects[i].CompareTag(tag))
                    goWithTagList.Add(Scene.gameObjects[i]);
            }
            return goWithTagList;
        }

        //==========================================================================================
        // COMPONENT METHODS
        //==========================================================================================

        /// <summary>
        /// Start all components attached to this game object
        /// </summary>
        public void Start()
        {
            scene = Scene.currentScene;
            foreach (Component comp in components)
            {
                comp.Init();
            }
        }

        /// <summary>
        /// Update all components attached to this game object
        /// </summary>                                
        public void Update(GameTime gameTime)                                                       // public void Update(GameTime gameTime) To be implemented?
        {
            foreach (Component comp in components)
            {
                comp.Update(gameTime);
            }

            foreach (GameObject o in Scene.entities)
            {
                if (o.children.Count > 0)
                {
                    foreach (GameObject child in children)
                    {
                        child.transform.Translate(child.parent.transform.position.X,
                         child.parent.transform.position.Y);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the list of all components attached to this game object
        /// </summary>
        /// <returns>List<Component></Component></returns>
        public List<Component> GetComponentList() { return components; }

        /// <summary>
        /// Gets all components of type attached to this game object
        /// </summary>
        /// <returns>List T</returns>
        public List<T> GetComponents<T>() where T : Component
        {
            if (components.Count <= 0)
                return null;

            List<T> componentList = new List<T>();
            foreach (Component c in components)
            {
                if (c.GetType() == typeof(T))
                    componentList.Add((T)c);

            }
            return componentList.Count <= 0 ? null : componentList;
        }

        /// <summary>
        /// Gets the component of type attached to this game object
        /// </summary>
        /// <returns>T</returns>
        public T GetComponent<T>() where T : Component
        {
            if (components.Count <= 0)
                return null;

            foreach (Component c in components)
            {
                if (c.GetType() == typeof(T))
                    return (T)c;
            }
            return null;
        }

        /// <summary>
        /// Gets the component of type from children
        /// </summary>
        /// <returns>T</returns>
        public T GetComponentInChildren<T>() where T : Component
        {
            if (children.Count <= 0)
                return null;

            foreach (GameObject go in children)
            {
                if (go.components.Count <= 0)
                    continue;
                foreach (Component c in components)
                {
                    if (c.GetType() == typeof(T))
                        return (T)c;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets all components of type from all children attached
        /// to this game object
        /// </summary>
        /// <returns>T</returns>
        public List<T> GetComponentsInChildren<T>() where T : Component
        {
            if (children.Count <= 0)
                return null;

            List<T> componentList = new List<T>();
            foreach (GameObject go in children)
            {
                if (go.components.Count <= 0)
                    continue;
                foreach (Component c in go.components)
                {
                    if (c.GetType() == typeof(T))
                        componentList.Add((T)c);
                }
            }
            return componentList.Count <= 0 ? null : componentList;
        }

        /// <summary>
        /// Gets the component of type attached to parent game object
        /// </summary>
        /// <returns>T</returns>
        public T GetComponentInParent<T>() where T : Component
        {
            if (parent == null || parent.components.Count <= 0)
                return null;

            foreach (Component c in parent.components)
            {
                if (c.GetType() == typeof(T))
                    return (T)c;
            }
            return null;
        }

        /// <summary>
        /// Gets all components of type from parent game object 
        /// </summary>
        /// <returns>T</returns>
        public List<T> GetComponentsInParent<T>() where T : Component
        {
            if (parent == null || parent.components.Count <= 0)
                return null;

            List<T> componentList = new List<T>();
            foreach (Component c in parent.components)
            {
                if (c.GetType() == typeof(T))
                    componentList.Add((T)c);
            }
            return componentList;
        }

        /// <summary>
        /// Removes the component type attached to this game object
        /// </summary>
        /// <param name="(Component compType)"></param>
        public void RemoveComponent<T>(T compType) where T : Component
        {
            if (components.Count <= 0)
                return;

            for (int i = 0; i < components.Count; i++)
            {
                Component c = components[i];
                if (compType.GetType().IsAssignableFrom(c.GetType()))
                    components.Remove(c);
            }
        }

        /// <summary>
        /// Adds the component type to this game object
        /// </summary>
        public T AddComponent<T>() where T : Component, new()
        {
            Component comp = new T();
            components.Add(comp);
            comp.gameObject = this;
            return (T)comp;
        }

        /// <summary>
        /// Compares this game objects tag name to a string value
        /// </summary>
        /// <param name="(String name)"></param>
        public bool CompareTag(string name)
        {
            return tag.name == name;
        }

        public void BroadcastMessage(string methodName, params object[] args)
        {
            // broadcast to parent
            if (parent != null)
            {
                foreach (Component c in parent.components)
                {
                    if (c.GetType() == typeof(MonoBehavior))
                    {
                        var method = c.GetType().GetMethod(methodName);
                        if (method != null)
                            method.Invoke((MonoBehavior)c, args);
                    }
                }
            }

            // broadcast to children
            if (children.Count <= 0)
                return;

            foreach (GameObject go in children)
            {
                foreach (Component c in go.components)
                {
                    if (c.GetType() == typeof(MonoBehavior))
                    {
                        var method = c.GetType().GetMethod(methodName);
                        if (method != null)
                            method.Invoke((MonoBehavior)c, args);
                    }
                }
            }
        }
    }
}
