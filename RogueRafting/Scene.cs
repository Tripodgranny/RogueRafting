using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RogueRafting.GameEngine.CoreModule.Entities;
using RogueRafting.GameEngine.CoreModule.Entities.Components;
using RogueRafting.GameEngine.CoreModule.Entities.Components.Behaviors;
using RogueRafting.RogueRaftingContent.Scenes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting
{

    public abstract class Scene
    {

        protected Camera camera;
        private bool isRunning = false;
        private static bool changingScene = false;
        private static bool started = false;

        public static Scene currentScene = null;
        public static List<GameObject> gameObjects = new List<GameObject>();
        public static List<MonoBehavior> monobehaviors = new List<MonoBehavior>();
        public static List<Entity> entities = new List<Entity>();

        /// <summary>
        /// Called after the scene is loaded and every object is initialized.
        /// <para>Executes all Awake funtions in all scripts in the scene.</para>
        /// </summary>
        private static void Awake()
        {
            foreach (MonoBehavior script in GameObject.GetAllScripts())
            {
                if (script.enabled)
                    script.Awake();
            }
            started = true;
        }

        /// <summary>
        /// Adds a game object to the scene.
        /// </summary>
        public static void AddGameObjectToScene(GameObject go)
        {
            gameObjects.Add(go);
            go.Start();
        }

        /// <summary>
        /// Adds a game object to the scene and set its position and rotation.
        /// </summary>
        public static void AddGameObjectToScene(GameObject go, Vector2 position, int rotation)
        {
            gameObjects.Add(go);
            go.transform.position = position;
            go.transform.rotation = rotation;
            go.Start();
        }

        /// <summary>
        /// This method updates the scene.
        /// <para>This includes all game objects, their components, and engine systems.</para>
        /// </summary>
        public static void Process(GameTime gameTime)
        {
            if (currentScene == null)
                return;

            if (!started)
                Awake();

            List<MonoBehavior> scripts = GameObject.GetAllScripts();
            for (int s = 0; s < scripts.Count; s++)
            {
                if (scripts[s] != null)
                {
                    if (scripts[s].enabled && scripts.Contains(scripts[s]))
                        scripts[s].Update(gameTime);
                }
            }
        }

        /// <summary>
        /// This method is used to load scene specific resources that aren't already in memory.
        /// </summary>
        //public abstract void LoadResources(ContentManager content);

        /// <summary>
        /// Creates the scene from loaded resources.
        /// <para>All game objects or assets must be added using <see cref="AddGameObjectToScene"/>
        /// in this method.</para>
        /// <para>This method can be thought of as a load scene method.</para>
        /// </summary>
        public abstract void BuildSceneFromResources();

        public static void Render(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //if (gameObjects.Count == 0)
               // return;

            foreach (GameObject go in gameObjects)
            {
                SpriteRenderer renderer = go.GetComponent<SpriteRenderer>();
                Transform transform = go.GetComponent<Transform>();
                if (renderer!=null && transform!=null)
                {
                    if (renderer.visible)
                    {
                        spriteBatch.Draw(renderer.sprite.currentImage,
                                         transform.position,
                                         Color.White);
                        renderer.Update(gameTime);
                    }

                    //Debug.WriteLine("Rendered Sprite From Object " + renderer.gameObject.name 
                    //    + " : ID : " + renderer.gameObject.GetInstanceID());
                }
            }

        }

        private static void DeleteNonPersistentObjects()
        {
            gameObjects.Clear();
            entities.Clear();
            monobehaviors.Clear();
        }

        /// <summary>
        /// Used to change the current scene in game
        /// </summary>
        public static void ChangeScene<T>() where T : Scene, new()
        {
            changingScene = true;
            DeleteNonPersistentObjects();
            currentScene = new T();

            currentScene.BuildSceneFromResources();
            changingScene = false;

            started = false;
        }

        public abstract Color GetBackgroundColor();

        public static Color GetScreenColor()
        {
            if (currentScene == null)
                return Color.Black;
            else
                return currentScene.GetBackgroundColor();
        }
        
    }
}
