
#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TilemapLibrary;
using Platformer.Controller;

#endregion

namespace Platformer
{
    public enum GameState
    {
        Start,
        Play,
        Win,
        Lose,
        Pause
    }

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class PlatformerGame : Microsoft.Xna.Framework.Game
    {
        #region Fields

        Controller.Controller control;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Tilemap tilemap;
        Player player;
        Camera camera;

        //Texture2D heart;
        //List<Enemy> enemies;
        //List<Gem> gems;
        //Song bgSong;

        SpriteFont spriteFont;

        GameState gameState;

        #endregion

        #region Properties

        public GameState GameState
        {
            get { return gameState; }
            set { gameState = value; }
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public Camera Camera
        {
            get { return camera; }
            set { camera = value; }
        }

        #endregion

        #region Initalization

        public PlatformerGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            control = new Controller.Controller(this);

            control.Show();            

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

            //load tilemap
            tilemap = Content.Load<Tilemap>("testlevel");

            //load player
            player = new Player();
            player.LoadContent(Content);
            player.Tilemap = tilemap;
            player.LayerIndex = tilemap.PlayerStart.Layer;
            player.Position = tilemap.PlayerStart.Position;
        
            
            //heart = Content.Load<Texture2D>("heart");
            
            //load camera
            camera = new Camera(GraphicsDevice, tilemap);
            camera.Target = player;

            //enemies = new List<Enemy>();
            //if (tilemap.EnemyLocations != null)
            //{
            //    foreach (EnemyStart e in tilemap.EnemyLocations)
            //    {
            //        enemies.Add(new Enemy(e.MonsterType, e.Layer, e.Position));
            //    }
            //}

            //gems = new List<Gem>();
            //if (tilemap.Gems != null)
            //{
            //    foreach (GemLocation g in tilemap.Gems)
            //    {
            //        gems.Add(new Gem(g.GemType, g.Layer, g.Position));
            //    }
            //}

            //Licensed under Creative Commons Attribution - from freemusicarchive.org
            //bgSong = Content.Load<Song>("Sounds/Rolemusic - Leafless_Quince_Tree");

            spriteFont = Content.Load<SpriteFont>("SpriteFont1");

            //MediaPlayer.Play(bgSong);

            gameState = GameState.Start;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            control.Hide();
        }

        #endregion

        #region Update and Draw

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    this.Exit();

            control.Update(gameTime);
            if (control.StopGame) gameState = GameState.Start;

            switch (gameState)
            {
                case GameState.Play:

                    //if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    //{
                    //    gameState = GameState.Pause;
                    //    return;
                    //}

                    player.Update(gameTime);
                    camera.Update(gameTime);

                    if (player.Dead) gameState = GameState.Lose;
                    if (player.Win) gameState = GameState.Win;

                    //foreach (Enemy e in enemies)
                    //{
                    //    e.Update(gameTime, player);
                    //}
                    //foreach (Gem g in gems)
                    //{
                    //    g.Update(player);
                    //}

                    break;

                case GameState.Pause:
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        gameState = GameState.Play;
                    }
                    break;
                case GameState.Start:
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        gameState = GameState.Play;
                    }
                    break;
                default:
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (gameState == GameState.Play || gameState == GameState.Pause)
            {
                // Draw the world
                spriteBatch.Begin(0, null, null, null, null, camera.Effect);
                tilemap.Draw(spriteBatch);
                player.Draw(spriteBatch);
                spriteBatch.End();

                // Draw the GUI
                spriteBatch.Begin();
                //for (int i = 0; i < player.Health; i++)
                //{
                //    spriteBatch.Draw(heart, new Vector2(10 + 20 * i, 10), Color.White);
                //}

                if (gameState == GameState.Pause)
                {
                    spriteBatch.DrawString(spriteFont, "PAUSED", new Vector2(350, 200), Color.White);
                }
                spriteBatch.End();
            }
            else if(gameState == GameState.Start)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(spriteFont, "Start Game from Form Window", new Vector2(100, 200), Color.White);
                spriteBatch.End();
            }
            else if (gameState == GameState.Lose)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(spriteFont, "FAIL", new Vector2(100, 200), Color.White);
                spriteBatch.End();
            }
            else if (gameState == GameState.Win)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(spriteFont, "A WINRAR IS YOU", new Vector2(100, 200), Color.White);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        #endregion

    }
}
