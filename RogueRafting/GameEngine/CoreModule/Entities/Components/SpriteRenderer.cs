using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueRafting.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RogueRafting.GameEngine.CoreModule.Entities.Components
{
    public class SpriteRenderer : Component
    {
        public bool visible = true;
        public Sprite sprite { set; get; }
        public float animationSpeed = 2F;
        private float timer = 0;

        public SpriteRenderer()
        {

        }

        public SpriteRenderer(Sprite sprite)
        {
            this.sprite = sprite;
        }

        public override void Update(GameTime gameTime)
        {
            Play(gameTime);
        }

        private void Play(GameTime gameTime)
        {
            if (animationSpeed <= 0)
                return;

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > animationSpeed)
            {
                SwitchFrame();
            }
        }

        private void SwitchFrame()
        {
            if (sprite.imageIndex >= sprite.imageCount - 1)
            {
                sprite.imageIndex = 0;
            }
            else
            {
                sprite.imageIndex++;
            }

            sprite.currentImage = sprite.images[sprite.imageIndex];
            timer = 0;
        }
    }
}
