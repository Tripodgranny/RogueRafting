using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RogueRafting.Components;
using RogueRafting.Components.Behaviors;
using RogueRafting.Entities;
using RogueRafting.Scenes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        protected static List<GameObject> gameObjects = new List<GameObject>();

        public static readonly int LEVEL_EDITOR_SCENE = 0;
        public static readonly int TEST_SCENE = 1;

        public static void Init()
        {

            started = true;
            Awake();
            
        }

        // Called after scene has loaded and every object is initialized
        private static void Awake()
        {
            foreach (MonoBehavior script in GameObject.GetAllScripts())
            {
                if (script.enabled)
                    script.Awake();
            }
        }

        public static void AddGameObjectToScene(GameObject go)
        {
            gameObjects.Add(go);
            go.Start();
        }
        public static void AddGameObjectToScene(GameObject go, Vector2 position, int rotation)
        {
            gameObjects.Add(go);
            go.transform.position = position;
            go.transform.rotation = rotation;
            go.Start();
        }

        public static void Process(GameTime gameTime)
        {
            if (!started)
            Init();

            List<MonoBehavior> scripts = GameObject.GetAllScripts();
            for (int s = 0; s < scripts.Count; s++)
            {
                if (scripts[s] != null)
                {
                    if (scripts[s].enabled)
                        scripts[s].Update(gameTime);
                }
            }
        }

        public abstract void LoadResources(ContentManager content);

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

                    Debug.WriteLine("Rendered Sprite From Object " + renderer.gameObject.name 
                        + " : ID : " + renderer.gameObject.GetInstanceID());
                }
            }

        }

        public static void ChangeScene(int newScene)
        {
            switch (newScene)
            {
                case 0:
                    changingScene = true;
                    RogueRafting.currentScene = new LevelEditorScene();
                    break;
                case 1:
                    changingScene = true;
                    RogueRafting.currentScene = new TestScene();
                    break;
            }

            changingScene = false;
        }
    }
}
