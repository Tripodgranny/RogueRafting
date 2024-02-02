using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueRafting.RogueRaftingContent.Scenes;
using RogueRafting.Util;
using System;
using System.Collections.Generic;

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

        private List<Scene> scenes = new List<Scene> 
        { 
            
        };

        public RogueRafting()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize(); // This method calls LoadContent();

            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
            graphics.ApplyChanges();

            //camera = new Camera(graphics.GraphicsDevice.Viewport);
            
            GameState.state = GameState.State.Running;

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            renderTarget = new RenderTarget2D(GraphicsDevice, 1280, 1080);
            Assets.Load(Content);
            Scene.ChangeScene<TestScene>();
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
            Scene.Process(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            scale = viewScale / (width / graphics.GraphicsDevice.Viewport.Height);
            graphics.GraphicsDevice.SetRenderTarget(renderTarget);
            graphics.GraphicsDevice.Clear(Scene.GetScreenColor());

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