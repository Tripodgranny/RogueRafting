using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using RogueRafting.GameEngine.CoreModule.Entities;
using RogueRafting.RogueRaftingContent.Scripts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting.RogueRaftingContent.Scenes
{
    public class LevelEditorScene : Scene
    {
        public Color backgroundColor = Color.White;

        public override void BuildSceneFromResources()
        {
            Debug.WriteLine("In Level Editor Scene.");

            GameObject switchScene = new GameObject();
            switchScene.AddComponent<SwitchBackToTestLevelScript>();

            Scene.AddGameObjectToScene(switchScene);

        }

        public override Color GetBackgroundColor()
        {
            return backgroundColor;
        }
    }
}
