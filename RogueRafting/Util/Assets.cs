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

        private static SpriteGroup spriteGroup;

        public static Texture2D playerTexture_1;
        public static Texture2D playerTexture_2;
        public static Texture2D playerTexture_3;

        public static Texture2D player_walk_down_1;
        public static Texture2D player_walk_down_2;
        public static Texture2D player_walk_down_3;

        public static Texture2D player_walk_left_1;
        public static Texture2D player_walk_left_2;
        public static Texture2D player_walk_left_3;

        public static Texture2D player_walk_right_1;
        public static Texture2D player_walk_right_2;
        public static Texture2D player_walk_right_3;

        public static Texture2D player_walk_up_1;
        public static Texture2D player_walk_up_2;
        public static Texture2D player_walk_up_3;

        public static Texture2D player_walk_down;

        public static void Load(ContentManager content)
        {
            playerTexture_1 = content.Load<Texture2D>("test1");
            playerTexture_2 = content.Load<Texture2D>("test2");
            playerTexture_3 = content.Load<Texture2D>("test3");

            player_walk_down_1 = content.Load<Texture2D>("player_walk_down_1");
            player_walk_down_2 = content.Load<Texture2D>("player_walk_down_2");
            player_walk_down_3 = content.Load<Texture2D>("player_walk_down_3");

            player_walk_left_1 = content.Load<Texture2D>("player_walk_left_1");
            player_walk_left_2 = content.Load<Texture2D>("player_walk_left_2");
            player_walk_left_3 = content.Load<Texture2D>("player_walk_left_3");

            player_walk_right_1 = content.Load<Texture2D>("player_walk_right_1");
            player_walk_right_2 = content.Load<Texture2D>("player_walk_right_2");
            player_walk_right_3 = content.Load<Texture2D>("player_walk_right_3");

            player_walk_up_1 = content.Load<Texture2D>("player_walk_up_1");
            player_walk_up_2 = content.Load<Texture2D>("player_walk_up_2");
            player_walk_up_3 = content.Load<Texture2D>("player_walk_up_3");

            spriteGroup = new SpriteGroup();
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

        public static SpriteGroup GetSpriteGroup()
        {
            return spriteGroup;
        }

        public class SpriteGroup
        {
            public List<Texture2D> playerStanding = new List<Texture2D>
            { player_walk_down_1 };

            public List<Texture2D> playerWalkDown = new List<Texture2D>
            { player_walk_down_1, player_walk_down_2, player_walk_down_3 };

            public List<Texture2D> playerWalkLeft = new List<Texture2D>
            { player_walk_left_1, player_walk_left_2, player_walk_left_3 };

            public List<Texture2D> playerWalkRight = new List<Texture2D>
            { player_walk_right_1, player_walk_right_2, player_walk_right_3 };


            public List<Texture2D> playerWalkUp = new List<Texture2D>
            { player_walk_up_1, player_walk_up_2, player_walk_up_3 };
        }

    }
}
