using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RogueRafting.Components;
using RogueRafting.Components.Behaviors;
using RogueRafting.Entities;
using RogueRafting.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting.Scenes
{
    internal class TestScene : Scene
    {

        Texture2D playerTexture_1;
        Texture2D playerTexture_2;
        Texture2D playerTexture_3;

        public override void LoadResources(ContentManager content)
        {
            playerTexture_1 = content.Load<Texture2D>("test1");
            playerTexture_2 = content.Load<Texture2D>("test2");
            playerTexture_3 = content.Load<Texture2D>("test3");
        }

        public override void BuildSceneFromResources()
        {
            GameObject player = new GameObject(new Vector2(100, 100), 0);

            List<Texture2D> playerWalkImages = new List<Texture2D> 
            { playerTexture_1 , playerTexture_2 , playerTexture_3 };

            Sprite playerSprite = new Sprite(playerWalkImages, new Vector2(16, 16));
            Sprite playerSprite2 = new Sprite(playerWalkImages, new Vector2(16, 16));

            player.name = "Player";
            player.AddComponent<SpriteRenderer>();
            player.GetComponent<SpriteRenderer>().sprite = playerSprite;
            player.AddComponent<PlayerMovement>();


            GameObject player2 = new GameObject();

            player2.name = "Player 2";
            player2.AddComponent<SpriteRenderer>();
            player2.GetComponent<SpriteRenderer>().sprite = playerSprite2;
            player2.GetComponent<SpriteRenderer>().animationSpeed = 2F;
            player2.AddComponent<EnemyMovement>();

            GameObject player3 = new GameObject();

            player3.name = "Player 3";
            player3.AddComponent<SpriteRenderer>();
            player3.GetComponent<SpriteRenderer>().sprite = playerSprite2;
            player3.GetComponent<SpriteRenderer>().animationSpeed = 2F;
            // player3.AddComponent<EnemyMovement>();
            //player3.SetParent(player);

            AddGameObjectToScene(player, new Vector2(100, 100), 0);
            AddGameObjectToScene(player2, new Vector2(100, 500), 0);
            AddGameObjectToScene(player3, new Vector2(160, 100), 0);

        }

    }
}
