using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RogueRafting.GameEngine.CoreModule.Entities;
using RogueRafting.GameEngine.CoreModule.Entities.Components;
using RogueRafting.GameEngine.CoreModule.Entities.Components.Behaviors;
using RogueRafting.Graphics;
using RogueRafting.RogueRaftingContent.Scenes;
using RogueRafting.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace RogueRafting.Application.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))] // <- require components not implemented yet
    public class PlayerMovement : MonoBehavior
    {
        float timer = 0;
        float speed = 110F;
        bool moving = false;

        Sprite playerStandingSprite;
        Sprite playerWalkDownSprite;
        Sprite playerWalkLeftSprite;
        Sprite playerWalkRightSprite;
        Sprite playerWalkUpSprite;

        public override void Awake()
        {
            createSprites();
            gameObject.GetComponent<SpriteRenderer>().sprite = playerStandingSprite;

            //enabled = false;
            //gameObject.GetComponent<SpriteRenderer>().visible = false;
            //FindFirstObjectByType<EnemyMovement>(true).enabled = true;
            Debug.WriteLine("Awake Called For: " + "PlayerMovement on " + gameObject.name);
        }

        public override void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //gameObject.transform.Translate(delta * 20F, delta * 20F);
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Input.LEFT_ANALOG_VECTOR2.X < -0.2f)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = playerWalkLeftSprite;
                gameObject.transform.Translate(delta * -speed, 0);
                moving = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Input.LEFT_ANALOG_VECTOR2.X > 0.2f)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = playerWalkRightSprite;
                gameObject.transform.Translate(delta * speed, 0);
                moving = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Input.LEFT_ANALOG_VECTOR2.Y < -0.2f)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = playerWalkDownSprite;
                gameObject.transform.Translate(0, delta * speed);
                moving = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Input.LEFT_ANALOG_VECTOR2.Y > 0.2f)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = playerWalkUpSprite;
                gameObject.transform.Translate(0, delta * -speed);
                moving = true;
            }
            if (moving)
                gameObject.GetComponent<SpriteRenderer>().animationSpeed = 0.18f;

            if (!(Keyboard.GetState().IsKeyDown(Keys.W) || Input.LEFT_ANALOG_VECTOR2.Y > 0.2f) 
                && !(Keyboard.GetState().IsKeyDown(Keys.S) || Input.LEFT_ANALOG_VECTOR2.Y < -0.2f)
                && !(Keyboard.GetState().IsKeyDown(Keys.D) || Input.LEFT_ANALOG_VECTOR2.X > 0.2f)
                && !(Keyboard.GetState().IsKeyDown(Keys.A) || Input.LEFT_ANALOG_VECTOR2.X < -0.2f))
            { 
                moving = false;
                gameObject.GetComponent<SpriteRenderer>().animationSpeed = 0;
                gameObject.GetComponent<SpriteRenderer>().sprite = playerStandingSprite;
            }

            // TESTS - Just uncomment the code of each test to view, script must be attached to obj.
            ///-------------------------------------------------------------------------------------
            //--- CHANGE SCENE AFTER 5 SECONDS TEST

            /*
            timer++;
            if (timer >= 600)
            {
                Debug.WriteLine("Changed Scene : " + Scene.currentScene.ToString());


                Scene.ChangeScene<LevelEditorScene>(); // pass a scene in here to change to
            }
            */

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

        private void createSprites()
        {
            playerStandingSprite = new Sprite(Assets.GetSpriteGroup().playerStanding,
                new Vector2(16, 16));

            playerWalkDownSprite = new Sprite(Assets.GetSpriteGroup().playerWalkDown,
                new Vector2(16, 16));

            playerWalkLeftSprite = new Sprite(Assets.GetSpriteGroup().playerWalkLeft,
                new Vector2(16, 16));

            playerWalkRightSprite = new Sprite(Assets.GetSpriteGroup().playerWalkRight,
                new Vector2(16, 16));

            playerWalkUpSprite = new Sprite(Assets.GetSpriteGroup().playerWalkUp,
                new Vector2(16, 16));
        }
    }
}
