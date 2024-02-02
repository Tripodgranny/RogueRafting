using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting.Util
{
    public class Assets
    {

        public static Texture2D playerTexture_1;
        public static Texture2D playerTexture_2;
        public static Texture2D playerTexture_3;

        public static void Load(ContentManager content)
        {
            playerTexture_1 = content.Load<Texture2D>("test1");
            playerTexture_2 = content.Load<Texture2D>("test2");
            playerTexture_3 = content.Load<Texture2D>("test3");
        }

        /*
        public static Sprite playerWalkSprite;

        public static void LoadSprites(ContentManager content)
        {
            playerWalkSprite = new Sprite();
            Texture2D test = content.Load<Texture2D>("TestSprite");
            playerWalkSprite.images.Add(test);
        }
        */
    }
}
