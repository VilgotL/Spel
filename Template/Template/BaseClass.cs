using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class BaseClass
    {
        protected Texture2D tex;
        protected Rectangle rec;

        public BaseClass(Texture2D tex, Rectangle rec)
        {
            this.tex = tex;
            this.rec = rec;
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
        public Texture2D Tex
        {
            get { return tex; }
        }
        public Rectangle Rec
        {
            get { return rec; }
            set { rec = value; }
        }
    }
}