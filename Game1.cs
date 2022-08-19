using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using RC_Framework;

namespace Assignment
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static bool showbb = false;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 1000;
            graphics.PreferredBackBufferWidth = 800;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LineBatch.init(GraphicsDevice);

            Global.gameStateManager = new RC_GameStateManager();
            Global.gameStateManager.AddLevel(0, new SplashScreen());
            Global.gameStateManager.getLevel(0).InitializeLevel(GraphicsDevice, spriteBatch, Content, Global.gameStateManager);
            Global.gameStateManager.getLevel(0).LoadContent();
            

            Global.gameStateManager.AddLevel(1, new Pause());
            Global.gameStateManager.getLevel(1).InitializeLevel(GraphicsDevice, spriteBatch, Content, Global.gameStateManager);
            Global.gameStateManager.getLevel(1).LoadContent();


            Global.gameStateManager.AddLevel(2, new EndGame());
            Global.gameStateManager.getLevel(2).InitializeLevel(GraphicsDevice, spriteBatch, Content, Global.gameStateManager);
            Global.gameStateManager.getLevel(2).LoadContent();
            

            Global.gameStateManager.AddLevel(3, new Loading());
            Global.gameStateManager.getLevel(3).InitializeLevel(GraphicsDevice, spriteBatch, Content, Global.gameStateManager);
            Global.gameStateManager.getLevel(3).LoadContent();
            

            Global.gameStateManager.AddLevel(4, new HelpScreen());
            Global.gameStateManager.getLevel(4).InitializeLevel(GraphicsDevice, spriteBatch, Content, Global.gameStateManager);
            Global.gameStateManager.getLevel(4).LoadContent();


            Global.gameStateManager.AddLevel(5, new PlayLevel1());
            Global.gameStateManager.getLevel(5).InitializeLevel(GraphicsDevice, spriteBatch, Content, Global.gameStateManager);
            Global.gameStateManager.getLevel(5).LoadContent();
            Global.gameStateManager.setLevel(5);
            //Global.gameStateManager.AddLevel(6, new PlayLevel2());
            //Global.gameStateManager.getLevel(6).InitializeLevel(GraphicsDevice, spriteBatch, Content, Global.gameStateManager);
            //Global.gameStateManager.getLevel(6).LoadContent();

            //Global.gameStateManager.AddLevel(7, new PlayLevel3());
            //Global.gameStateManager.getLevel(7).InitializeLevel(GraphicsDevice, spriteBatch, Content, Global.gameStateManager);
            //Global.gameStateManager.getLevel(7).LoadContent();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Global.keyState.IsKeyDown(Keys.B) && Global.prevKeyState.IsKeyUp(Keys.B)) // B key is for showing the boundary infor and hotspot like a switch
            {
                showbb = !showbb;
            }

            
            Global.gameStateManager.getCurrentLevel().Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Global.gameStateManager.getCurrentLevel().Draw(gameTime);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
