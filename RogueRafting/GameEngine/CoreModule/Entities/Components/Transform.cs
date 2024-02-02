using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting.GameEngine.CoreModule.Entities.Components
{
    public class Transform : Component
    {
        public Vector2 position;
        public float rotation;

        public Transform()
        {
            position = new Vector2(0, 0);
            rotation = 0;
        }

        public Transform(Vector2 position, float rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }

        public void Translate(float xTranslation, float yTranslation)
        {
            position.X += xTranslation;
            position.Y += yTranslation;
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
