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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace RushHour {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class RushHour : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont levelFont, authorFont;
        LevelManager levelManager;
        Texture2D bg;
        int offSet = 0;

        public RushHour() {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 600;
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
            this.Window.Title = "Rush Hour";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            levelManager = new LevelManager(this);
            Components.Add(levelManager);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            levelFont = Content.Load<SpriteFont>("LevelName");
            authorFont = Content.Load<SpriteFont>("LevelAuthor");
            bg = Content.Load<Texture2D>("Background");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // Allows the game to exit
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);

            if(!levelManager.CurrentLevel.Paused)
                offSet += 1;

            spriteBatch.Begin();
            for(int i = -bg.Height; i < graphics.PreferredBackBufferHeight; i += bg.Height) {
                for(int j = -bg.Width; j < graphics.PreferredBackBufferWidth; j += bg.Width) {
                    spriteBatch.Draw(bg, new Rectangle(j + offSet, i + offSet, bg.Width, bg.Height), Color.White);
                    if(offSet > 33)
                        offSet = 0;
                }
            }

            if(levelManager.CurrentLevel != null) {
                GameLevel l = levelManager.CurrentLevel;

                Vector2 levelName = levelFont.MeasureString(l.Name);
                Vector2 levelCenter = new Vector2(GraphicsDevice.Viewport.Width / 2, 35f);

                Vector2 levelAuthor = authorFont.MeasureString(l.Author);
                Vector2 authorCenter = new Vector2(GraphicsDevice.Viewport.Width / 2, 60f);

                spriteBatch.DrawString(levelFont, l.Name, levelCenter - (levelName / 2), Color.Black);
                spriteBatch.DrawString(authorFont, l.Author, authorCenter - (levelAuthor / 2), Color.Black);
                spriteBatch.DrawString(authorFont, "Elapsed Time", new Vector2(9, l.BoardBounds.Top - 15), Color.Black);
                spriteBatch.DrawString(authorFont, "Moves", new Vector2(l.BoardBounds.Right + 32, l.BoardBounds.Top - 15), Color.Black);

                string time = string.Format("{0:00}:{1:00}",
                    levelManager.CurrentLevel.ElapsedTime.Minutes,
                    levelManager.CurrentLevel.ElapsedTime.Seconds);
                spriteBatch.DrawString(levelFont, time, new Vector2(16, l.BoardBounds.Top + 1), Color.Black, 0f, Vector2.Zero, 0.7f, SpriteEffects.None, 0);
                spriteBatch.DrawString(levelFont, time, new Vector2(15, l.BoardBounds.Top), Color.Firebrick, 0f, Vector2.Zero, 0.7f, SpriteEffects.None, 0);

                spriteBatch.DrawString(levelFont, l.TotalMoves.ToString("000"), new Vector2(l.BoardBounds.Right + 30, l.BoardBounds.Top + 1), Color.Black, 0f, Vector2.Zero, 0.7f, SpriteEffects.None, 0);
                spriteBatch.DrawString(levelFont, l.TotalMoves.ToString("000"), new Vector2(l.BoardBounds.Right + 29, l.BoardBounds.Top), Color.Firebrick, 0f, Vector2.Zero, 0.7f, SpriteEffects.None, 0);
            } else {
                spriteBatch.DrawString(levelFont, "Invalid Level!", Vector2.One, Color.Crimson);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
