using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using ArcLight__The_Fighter.Helpers;
using System.Threading;

namespace ArcLight__The_Fighter.GameScreens
{
    class MainMenu : GameScreen
    {
        ContentManager content;
        GameScreenManager screenManager;

        private SpriteFont MainMenuFont;

        private Rectangle LogoPos;
        private Rectangle ButtonExitPos;
        private Rectangle ButtonLogoutPos;
        private Rectangle ButtonOptionsPos;
        private Rectangle ButtonStartPos;

        private Texture2D Pozadi;
        private Texture2D Logo;

        private Texture2D buttonExit;
        private Texture2D buttonLogout;
        private Texture2D buttonOptions;
        private Texture2D buttonStart;

        private SoundEffect ButtonClick;

        private Song song;

        public MainMenu()
        {
        }


        public override void LoadContent()
        {
            screenManager = new GameScreenManager(Game1.game);
            content = new ContentManager(screenManager.Game.Content.ServiceProvider, "Content" );

            ButtonClick = content.Load<SoundEffect>("Sounds/Buttons/ButtonClick");
            Logo = content.Load<Texture2D>("MenuScreen/logo");
            MainMenuFont = content.Load<SpriteFont>("menuFont");
            song = content.Load<Song>("Sounds/Music/MainMenu");
            Pozadi = content.Load<Texture2D>("MenuScreen/Pozadi");
            buttonExit = content.Load<Texture2D>("Buttons/ButtonExit0");
            buttonLogout = content.Load<Texture2D>("Buttons/ButtonLogout0");
            buttonOptions = content.Load<Texture2D>("Buttons/ButtonOptions0");
            buttonStart = content.Load<Texture2D>("Buttons/ButtonStart0");

            MediaPlayer.Play(song);

            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;

        }

      

        private void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
        {
            MediaPlayer.Volume -= 0.1f;
            MediaPlayer.Play(song);

        }

        public override void UnloadContent()
        {

        }


        public override void Update(GameTime gameTime)
        {
            SpriteBatch spriteBatch = new SpriteBatch(screenManager.GraphicsDevice);
            spriteBatch.Begin();
            if (MouseClickHandler.MouseButtonClick(ButtonStartPos) == true)
            {
                ButtonClick.Play();
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            spriteBatch.End();
        }

        public override void Draw(GameTime gameTime)
        {



            ButtonStartPos = new Rectangle((int)(Game1.graphics.PreferredBackBufferWidth / 2) - (buttonStart.Width / 4), 400, buttonStart.Width / 2, buttonStart.Height / 2);
            ButtonOptionsPos = new Rectangle((int)(Game1.graphics.PreferredBackBufferWidth / 2) - (buttonOptions.Width / 4), 500, buttonOptions.Width / 2, buttonOptions.Height / 2);
            ButtonLogoutPos = new Rectangle((int)(Game1.graphics.PreferredBackBufferWidth / 2) - (buttonLogout.Width / 4), 600, buttonLogout.Width / 2, buttonLogout.Height / 2);
            ButtonExitPos = new Rectangle((int)(Game1.graphics.PreferredBackBufferWidth / 2) - (buttonExit.Width / 4), 700, buttonExit.Width / 2, buttonExit.Height / 2);
            LogoPos = new Rectangle((int)(Game1.graphics.PreferredBackBufferWidth / 2) - ((Logo.Width) / 2), 100, Logo.Width*5, Logo.Height*5);

            SpriteBatch spriteBatch = new SpriteBatch(screenManager.GraphicsDevice);
            Viewport viewport = screenManager.GraphicsDevice.Viewport;
            Rectangle fullscreen = new Rectangle(0, 0, viewport.Width, viewport.Height);

            spriteBatch.Begin();

            spriteBatch.Draw(Pozadi, fullscreen,Color.White);

            spriteBatch.Draw(Logo, LogoPos, Color.White);
            spriteBatch.Draw(buttonStart, ButtonStartPos, Color.White);
            spriteBatch.Draw(buttonExit, ButtonExitPos, Color.White);
            spriteBatch.Draw(buttonLogout, ButtonLogoutPos, Color.White);
            spriteBatch.Draw(buttonOptions, ButtonOptionsPos, Color.White);

            spriteBatch.End();
            
            

        }


    }
}
