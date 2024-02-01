using Microsoft.Xna.Framework;
using RogueRafting.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting.Components.Behaviors
{
    public class PlayerMovement : MonoBehavior
    {

        public override void Awake()
        {
            //enabled = false;
            //gameObject.GetComponent<SpriteRenderer>().visible = false;
            FindFirstObjectByType<EnemyMovement>(true).enabled = true;
            Debug.WriteLine("Awake Called For: " + gameObject.name);
            
        }

        public override void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            gameObject.transform.Translate(delta * 20F, delta * 20F);
            Debug.WriteLine("Player Movement");

            //Destroy(gameObject); // destroy this game object
            //Destroy(this); // destroy this script
            //if (gameObject.GetComponent<SpriteRenderer>() != null) // destroy the sprite renderer
            //    Destroy(gameObject.GetComponent<SpriteRenderer>());
        }
    }
}
