using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcLight__The_Fighter;
using MonoGame;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ArcLight__The_Fighter.Helpers
{
    class ButtonHandler
    {
        

        public static void CreateButton(ContentManager Content,Texture2D textureDSel,Texture2D textureSel ,Rectangle rectangle, String buttonName, SpriteBatch spriteBatch)
        {
            textureDSel = LoadButtonTextureNoPressed(Content, textureDSel, buttonName);
            textureSel = LoadButtonTexturePressed(Content, textureSel, buttonName);

            DrawButton(spriteBatch,rectangle, textureDSel, textureDSel);
        }

        public static Texture2D LoadButtonTextureNoPressed(ContentManager Content, Texture2D textureDSel,String buttonName)
        {
            textureDSel = Content.Load<Texture2D>("Buttons/" + buttonName + "0");
            return textureDSel;
        }

        public static Texture2D LoadButtonTexturePressed(ContentManager Content, Texture2D textureSel, String buttonName)
        {
            textureSel = Content.Load<Texture2D>("Buttons/" + buttonName + "1");
            return textureSel;
        }

        public static void UpdateButton()
        {

        }

        public static void DrawButton(SpriteBatch spriteBatch,Rectangle rectangle, Texture2D TextureDSel,Texture2D drawed)
        {
            
            spriteBatch.Begin();
            spriteBatch.Draw(drawed, rectangle, Color.White);
            spriteBatch.End();
        }
    }
}
