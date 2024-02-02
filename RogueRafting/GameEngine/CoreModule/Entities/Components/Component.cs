using Microsoft.Xna.Framework;
using RogueRafting.GameEngine.CoreModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting.GameEngine.CoreModule.Entities.Components
{
    public abstract class Component : Entity
    {
        /// <summary>
        /// The GameObject this component is attached to.
        /// </summary>
        public GameObject gameObject;
        public Transform transform;

        /// <summary>
        /// Abstract method used for starting a component.
        /// </summary>
        public virtual void Init()
        {
            transform = gameObject.transform;
        }

        /// <summary>
        /// Abstract method used for updating the component.
        /// </summary>
        public abstract void Update(GameTime gameTime);

    }
}
