using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RogueRafting.Components;
using RogueRafting.Scenes;
using RogueRafting.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RogueRafting
{
    public class RogueRafting : Game
    {
        private int width = 1280;
        private int height = 720;
        public float scale = 0.44444F;
        public float viewScale = 1f;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Input inputManager;
        //private Camera camera;
        private RenderTarget2D renderTarget;

        private Texture2D testSprite;

        public static Scene currentScene = null;

        public RogueRafting()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
            graphics.ApplyChanges();

            //camera = new Camera(graphics.GraphicsDevice.Viewport);
            
            GameState.state = GameState.State.Running;

            currentScene.BuildSceneFromResources();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            renderTarget = new RenderTarget2D(GraphicsDevice, 1280, 1080);
            Scene.ChangeScene(Scene.TEST_SCENE);
            currentScene.LoadResources(Content);
        }

        protected override void Update(GameTime gameTime)
        {

            Input.getInput();
            //camera.UpdateCamera(graphics.GraphicsDevice.Viewport);

            if (Input.A)
            Exit();

            if (Input.B)
            {
                GameState.state = GameState.State.Paused;
                viewScale += 0.01F;
                viewScale = Math.Clamp(viewScale, 1F, 2F);
            } else
            {
                GameState.state = GameState.State.Running;
            }

            // TODO: Add your update logic here
            base.Update(gameTime);

            //if (GameState.state != GameState.State.Paused)
                //Input.log();

            // UPDATE SCENE
            if (currentScene != null)
            {
                currentScene.Process(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            scale = viewScale / (width / graphics.GraphicsDevice.Viewport.Height);
            graphics.GraphicsDevice.SetRenderTarget(renderTarget);
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //spriteBatch.Draw(testSprite, Vector2.Zero, Color.White);
            Scene.Render(gameTime, spriteBatch);
            spriteBatch.End();

            graphics.GraphicsDevice.SetRenderTarget(null);
           // GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(renderTarget, Vector2.Zero, null, Color.White, 0F, Vector2.Zero, scale, SpriteEffects.None, 0F);
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}