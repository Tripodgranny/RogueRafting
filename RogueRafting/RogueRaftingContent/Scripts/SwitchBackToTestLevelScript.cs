using Microsoft.Xna.Framework;
using RogueRafting.GameEngine.CoreModule.Entities.Components.Behaviors;
using RogueRafting.RogueRaftingContent.Scenes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting.RogueRaftingContent.Scripts
{
    public class SwitchBackToTestLevelScript : MonoBehavior
    {
        float timer = 0;
        public override void Update(GameTime gameTime)
        {
            timer++;
            if (timer >= 600)
            {
                Debug.WriteLine("Changed Scene : " + Scene.currentScene.ToString());


                Scene.ChangeScene<TestScene>(); // pass a scene in here to change to
            }
        }
    }
}
