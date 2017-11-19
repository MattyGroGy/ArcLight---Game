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
    class MainMenu : GameScreen
    {
        ContentManager content;

        protected Texture2D Pozadi;

        public MainMenu()
        {
        }


        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services);

            Pozadi = content.Load<Texture2D>("MenuScreen/Pozadi");

            base.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.Draw(Pozadi, new Rectangle(0, 0, 1920, 1080), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
