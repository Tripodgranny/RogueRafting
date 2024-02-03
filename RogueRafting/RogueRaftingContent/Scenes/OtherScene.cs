using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueRafting.Application.Scripts;
using RogueRafting.GameEngine.CoreModule.Entities.Components;
using RogueRafting.GameEngine.CoreModule.Entities;
using RogueRafting.Graphics;
using RogueRafting.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting.RogueRaftingContent.Scenes
{
    public class OtherScene : Scene
    {
        private Color backgroundColor = Color.White;
        public override void BuildSceneFromResources()
        {
            GameObject player = new GameObject(new Vector2(100, 100), 0);


            player.name = "Player";
            player.AddComponent<SpriteRenderer>();
            

            player.AddComponent<PlayerMovement>();

            AddGameObjectToScene(player, new Vector2(100, 100), 0);
        }

        public override Color GetBackgroundColor()
        {
            return backgroundColor;
        }
    }
}
