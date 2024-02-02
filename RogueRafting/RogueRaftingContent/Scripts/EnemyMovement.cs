using Microsoft.Xna.Framework;
using RogueRafting.GameEngine.CoreModule.Entities.Components;
using RogueRafting.GameEngine.CoreModule.Entities.Components.Behaviors;
using RogueRafting.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting.Application.Scripts
{
    public class EnemyMovement : MonoBehavior
    {
        float i = 0;

        public override void Awake()
        {
            //enabled = false;
            //gameObject.GetComponent<SpriteRenderer>().visible = false;
            //FindFirstObjectByType<EnemyMovement>(true).enabled = true;
            Debug.WriteLine("Awake Called For: " + "EnemyMovement on " 
                            + gameObject.name);
        }

        public override void Update(GameTime gameTime)
        {
            i += 0.04f;
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float sin = (float)Math.Sin(i) * (delta * 80F);
            gameObject.transform.Translate(delta * 20F, sin);
            gameObject.GetComponent<SpriteRenderer>().animationSpeed = 0.1F;

            //Debug.WriteLine("EnemyMovement");
        }
    }
}
