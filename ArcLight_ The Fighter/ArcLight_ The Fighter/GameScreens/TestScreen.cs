using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcLight__The_Fighter.GameScreens
{
    class TestScreen : GameScreen
    {
        ContentManager content;
        GameScreenManager screenManager;
        private Texture2D Pozadi;
        private Song song;
        

        public TestScreen()
        {
        }


        public override void LoadContent()
        {
            screenManager = new GameScreenManager(Game1.game);
            if (content == null)
                content = new ContentManager(screenManager.Game.Content.ServiceProvider, "Content");

            this.song = content.Load<Song>("Sounds/Music/MainMenu");
            this.Pozadi = content.Load<Texture2D>("MenuScreen/Pozadi");
            MediaPlayer.Play(song);

            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
            base.LoadContent();
        }

        private void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
        {
            MediaPlayer.Volume -= 0.1f;
            MediaPlayer.Play(song);

        }

        public override void UnloadContent()
        {
           // base.UnloadContent();
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = screenManager.SpriteBatch;

         //   spriteBatch.Begin();
         //   spriteBatch.Draw(Pozadi, new Rectangle(0, 0, 1920, 1080), Color.White);
          //  spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
