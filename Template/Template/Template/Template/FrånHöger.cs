using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class FrånHöger : BaseClass
    {
        public FrånHöger(Texture2D tex, Rectangle rec) : base(tex, rec)
        {
        }
        protected int speed = 10;

        public void RemoveObject()
        {
            rec.Y = -100;
            rec.X = 1000;
            speed = -10;
        }
        public override void Update(GameTime gameTime)
        {
            rec.X -= speed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, rec, Color.White);
        }
    }
}