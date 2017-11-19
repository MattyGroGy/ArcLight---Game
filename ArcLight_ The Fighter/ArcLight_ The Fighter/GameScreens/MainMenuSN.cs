using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcLight__The_Fighter.GameScreens
{
    class MainMenuSN : Game1
    {
        public static void Buttons(SpriteBatch spriteBatch, ContentManager Content, int SelectedButton)
        {
            var ButtonSkipTexture = Content.Load<Texture2D>("MenuScreen/logo");
            spriteBatch.Begin();
            spriteBatch.Draw(ButtonSkipTexture, new Rectangle(250, 250, 32, 128), Color.White);
            spriteBatch.End();
            if (SelectedButton == 0)
            {
                
            }
        }
    }
}
