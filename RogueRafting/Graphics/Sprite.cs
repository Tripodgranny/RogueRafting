using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RogueRafting.Graphics
{
    public class Sprite
    {

        public Texture2D currentImage = null;
        public List<Texture2D> images;
        public Vector2 origin;

        public int spriteWidth = 0;
        public int spriteHeight = 0;

        public float imageAlpha = 1F;
        public int imageIndex = 0;
        public int imageCount;
        public int imageXScale = 1;
        public int imageYScale = 1;
        public int rotation = 0;

        public Sprite(List<Texture2D> textures, Vector2 origin)
        {
            images = textures;
            currentImage = textures[0];
            imageCount = images.Count;
            spriteWidth = textures[0].Width;
            spriteHeight = textures[0].Height;
            this.origin = origin;
        }

        public void SetImageIndex(int index)
        {
            currentImage = images[index];
        }

    }
}
