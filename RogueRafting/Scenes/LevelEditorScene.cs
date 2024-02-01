using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting.Scenes
{
    internal class LevelEditorScene : Scene
    {
        public override void LoadResources(ContentManager content)
        {
            Debug.WriteLine("LevelEditorScene Loaded");
        }

        public override void BuildSceneFromResources()
        {
            throw new NotImplementedException();
        }

    }
}
