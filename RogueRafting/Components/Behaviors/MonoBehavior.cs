﻿using Microsoft.Xna.Framework;
using RogueRafting.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting.Components.Behaviors
{
    public class MonoBehavior : Behavior
    {
        public override void Init()
        {
            GameObject.AddScript(this);
            base.Init();
        }

        public override void Update(GameTime gameTime)
        {

        }

        public virtual void Start()
        {

        }

        public virtual void FixedUpdate()
        {

        }

        public virtual void LateUpdate()
        {

        }

        public virtual void OnGUI()
        {

        }

        public virtual void OnDisable()
        {

        }

        public virtual void OnEnable()
        {

        }

    }
}
