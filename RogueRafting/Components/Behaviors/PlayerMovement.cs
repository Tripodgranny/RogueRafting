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

        public override void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            gameObject.transform.Translate(delta * 20F, delta * 20F);

            Debug.WriteLine("PlayerMovement");
        }
    }
}
