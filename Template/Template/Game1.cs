using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player p;
        List<FrånHöger> list;
        Stopwatch time;
        Random ypos = new Random();
        Random randomFH = new Random();

        enum StartPos
        {
            X = 200,
            Y = 300
        }

        //KOmentar
        public Game1()
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

            // TODO: use this.Content to load your game content here 
            time = new Stopwatch();
            time.Start();
            p = new Player(Content.Load<Texture2D>("xwing"), new Rectangle((int)StartPos.X, (int)StartPos.Y, 50, 50), Content.Load<SpriteFont>("Text"));
            list = new List<FrånHöger>();

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

            // TODO: Add your update logic here
            p.Update(gameTime);
            if (p.Lives == 0)
                Exit();
            if (time.ElapsedMilliseconds >= 450)
            {
                time.Stop();
                time.Reset();
                int r = randomFH.Next(1, 101);
                if (r < 76)
                    list.Add(new Enemy(Content.Load<Texture2D>("square"), new Rectangle(800, ypos.Next(10, 400), 40, 40)));
                else if (r > 75 && r < 93)
                    list.Add(new Life(Content.Load<Texture2D>("heart"), new Rectangle(800, ypos.Next(10, 400), 40, 40)));
                else
                    list.Add(new Point(Content.Load<Texture2D>("star"), new Rectangle(800, ypos.Next(10, 400), 40, 40)));
                time.Start();
            }
            foreach (FrånHöger element in list)
            {
                element.Update(gameTime);
                if (element.Rec.Intersects(p.Rec))
                {
                    if (element is Enemy)
                    {
                        p.RemoveLife();
                        element.RemoveObject();
                    }
                    else if (element is Life)
                    {
                        p.AddLife();
                        p.AddPoint();
                        element.RemoveObject();
                    }
                    else
                    {
                        for(int i = 0; i < 10; i++)
                        {
                            p.AddPoint();
                        }
                        element.RemoveObject();
                    }
                }
                else if (element.Rec.X < 200 && element.Rec.X > 190)
                {
                    if (element is Enemy)
                        p.AddPoint();
                }
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

            // TODO: Add your drawing code here.
            spriteBatch.Begin();
            p.Draw(spriteBatch);
            foreach (FrånHöger element in list)
            {
                element.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}