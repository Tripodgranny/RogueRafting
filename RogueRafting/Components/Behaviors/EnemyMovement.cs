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
    public class EnemyMovement : MonoBehavior
    {

        public override void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            gameObject.transform.Translate(delta * 20F, 0F);
            gameObject.GetComponent<SpriteRenderer>().animationSpeed = 0.1F;

            Debug.WriteLine("EnemyMovement");
        }
    }
}
