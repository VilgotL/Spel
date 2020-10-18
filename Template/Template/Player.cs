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

        public Player(Texture2D tex, Rectangle rec) : base(tex, rec)
        {
            this.tex = tex;
            this.rec = rec;
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
                rec.Y -= 3;
            if (kstate.IsKeyDown(Keys.Down))
                rec.Y += 3;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, rec, Color.White);
        }
    }
}