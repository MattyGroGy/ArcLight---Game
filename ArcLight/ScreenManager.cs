using System;
using System.Collections;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace ArcLight
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null) { }
            }
        }

        public void LoadnContent(ContentManager Content)
        {
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}