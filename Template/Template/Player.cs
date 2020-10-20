using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Player : BaseClass
    {
        protected int lives = 3;
        protected int points = 0;
        protected SpriteFont font;

        public Player(Texture2D tex, Rectangle rec, SpriteFont font) : base(tex, rec)
        {
            this.tex = tex;
            this.rec = rec;
            this.font = font;
        }
        public int Lives
        {
            get { return lives; }
        }
        public int Points
        {
            get { return points; }
            set { points = value; }
        }
        public void AddLife()
        {
            if (lives < 3)
                lives++;
        }
        public void RemoveLife()
        {
            lives--;
        }
        public void AddPoint()
        {
            points++;
        }
        public override void Update(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up))
                rec.Y -= 4;
            if (kstate.IsKeyDown(Keys.Down))
                rec.Y += 4;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Lives: " + lives.ToString(), new Vector2(30, 30), Color.Black);
            spriteBatch.DrawString(font, "Points: " + points.ToString(), new Vector2(30, 60), Color.Black);
            spriteBatch.Draw(tex, rec, Color.White);
        }
    }
}