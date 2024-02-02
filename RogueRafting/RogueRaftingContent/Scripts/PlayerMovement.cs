using Microsoft.Xna.Framework;
using RogueRafting.GameEngine.CoreModule.Entities;
using RogueRafting.GameEngine.CoreModule.Entities.Components;
using RogueRafting.GameEngine.CoreModule.Entities.Components.Behaviors;
using RogueRafting.RogueRaftingContent.Scenes;
using RogueRafting.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting.Application.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))] // <- require components not implemented yet
    public class PlayerMovement : MonoBehavior
    {
        float timer = 0;

        public override void Awake()
        {
            //enabled = false;
            //gameObject.GetComponent<SpriteRenderer>().visible = false;
            //FindFirstObjectByType<EnemyMovement>(true).enabled = true;
            Debug.WriteLine("Awake Called For: " + "PlayerMovement on " + gameObject.name);
        }

        public override void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            gameObject.transform.Translate(delta * 20F, delta * 20F);


            // TESTS - Just uncomment the code of each test to view, script must be attached to obj.
            ///-------------------------------------------------------------------------------------
            //--- CHANGE SCENE AFTER 5 SECONDS TEST

            timer++;
            if (timer >= 600)
            {
                Debug.WriteLine("Changed Scene : " + Scene.currentScene.ToString());


                Scene.ChangeScene<LevelEditorScene>(); // pass a scene in here to change to
            }
            

            ///-------------------------------------------------------------------------------------
            // DESTROY TESTS
            ///-------------------------------------------------------------------------------------

            ///-- destroy all game objects with tag
            // DestroyGameObjects(gameObject.FindGameObjectsWithTag(Tag.DEFAULT.name));

            ///-- destroy this game object
            // Destroy(gameObject); 

            ///-- destroy this script
            // Destroy(this); 

            ///-- destroy the sprite renderer
            //if (gameObject.GetComponent<SpriteRenderer>() != null) 
            //    Destroy(gameObject.GetComponent<SpriteRenderer>());

        }
    }
}
