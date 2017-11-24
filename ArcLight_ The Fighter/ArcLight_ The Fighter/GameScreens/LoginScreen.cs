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
using MonoGame_Textbox;
using Lidgren.Network;

namespace ArcLight__The_Fighter.GameScreens
{
    class LoginScreen : GameScreen
    {
        ContentManager content;
        GameScreenManager screenManager;

        private SpriteFont MainMenuFont;

        private TextBox PasswordInput;
        private TextBox UsernameInput;

        private Rectangle LogoPos;
        private Rectangle PasswordInputPos = new Rectangle((int)(Game1.graphics.PreferredBackBufferWidth / 2) - 16 - 64, 544, 700, 64);
        private Rectangle UsernameInputPos = new Rectangle((int)(Game1.graphics.PreferredBackBufferWidth / 2) - 16 - 64, 476, 700, 64);
        private Rectangle ButtonExitPos;
        private Rectangle ButtonLoginPos;

        private Texture2D Pozadi;
        private Texture2D Logo;

        private Texture2D TextBoxPozadi;

        private Texture2D buttonExit;
        private Texture2D buttonLogin;

        private SoundEffect ButtonClick;

        private Song song;


        public LoginScreen()
        {
            KeyboardInput.Initialize(Game1.game, 500f, 20);
        }

        public override void LoadContent()
        {
            screenManager = new GameScreenManager(Game1.game);
            content = new ContentManager(screenManager.Game.Content.ServiceProvider, "Content" );

            TextBoxPozadi = content.Load<Texture2D>("textBox");
            buttonLogin = content.Load<Texture2D>("buttons/ButtonLogin0");
            buttonExit = content.Load<Texture2D>("buttons/ButtonExit0");
            ButtonClick = content.Load<SoundEffect>("Sounds/Buttons/ButtonClick");
            Logo = content.Load<Texture2D>("MenuScreen/Logo");
            MainMenuFont = content.Load<SpriteFont>("menuFont");
            song = content.Load<Song>("Sounds/Music/MainMenu");
            Pozadi = content.Load<Texture2D>("MenuScreen/Pozadi");

            MediaPlayer.Play(song);

            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;


            UsernameInput = new TextBox(UsernameInputPos, 32, "Username", screenManager.GraphicsDevice, MainMenuFont, Color.WhiteSmoke, Color.White,1);
            PasswordInput = new TextBox(PasswordInputPos, 32, "Password", screenManager.GraphicsDevice, MainMenuFont, Color.WhiteSmoke, Color.White,1);
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

            KeyboardInput.Update();

            SpriteBatch spriteBatch = new SpriteBatch(screenManager.GraphicsDevice);

            if (MouseClickHandler.MouseButtonClick(UsernameInputPos) == true && UsernameInput.Active == false)
            {
                UsernameInput.Active = true;
                PasswordInput.Active = false;
                
            }

            if (MouseClickHandler.MouseButtonClick(PasswordInputPos) == true && PasswordInput.Active == false)
            {
                UsernameInput.Active = false;
                PasswordInput.Active = true;

            }

            if (MouseClickHandler.MouseButtonClick(ButtonLoginPos) == true)
            {
                ButtonClick.Play();
                var config = new NetPeerConfiguration("Login");
                NetClient client = new NetClient(config);

                string Password = PasswordInput.Text.String;
                NetOutgoingMessage passwordMessage = client.CreateMessage(Password);
                client.Connect("localhost", 18051);
                client.SendMessage(passwordMessage, NetDeliveryMethod.ReliableOrdered);
            }
           
            else if (MouseClickHandler.MouseButtonClick(ButtonExitPos) == true)
            {
                ButtonClick.Play();
                screenManager.Game.Exit();
            }

            

            UsernameInput.Area = UsernameInputPos;
            PasswordInput.Area = PasswordInputPos;

            UsernameInput.Update();
            PasswordInput.Update();

            PasswordInput.EnterDown += PasswordInput_EnterDown;
            UsernameInput.EnterDown += UsernameInput_EnterDown;

        }

        private void UsernameInput_EnterDown(object sender, EventArgs e)
        {
            UsernameInput.Active = false;
            PasswordInput.Active = true;

        }

        private void PasswordInput_EnterDown(object sender, EventArgs e)
        {
            PasswordInput.Active = false;

        }

        public override void Draw(GameTime gameTime)
        {



            ButtonLoginPos = new Rectangle((int)(Game1.graphics.PreferredBackBufferWidth / 2) - (buttonLogin.Width / 4) + 742, 476, buttonLogin.Width / 2, buttonLogin.Height / 2);
            ButtonExitPos = new Rectangle((int)(Game1.graphics.PreferredBackBufferWidth / 2) - (buttonExit.Width / 4) + 742, 544, buttonExit.Width / 2, buttonExit.Height / 2);
           // UsernameInputPos = new Rectangle((int)(Game1.graphics.PreferredBackBufferWidth / 2) - 16 - (buttonExit.Width / 4), 476, 700, 64);
           // PasswordInputPos = new Rectangle((int)(Game1.graphics.PreferredBackBufferWidth / 2) - 16 - (buttonExit.Width / 4), 544, 700, 64);
            LogoPos = new Rectangle((int)(Game1.graphics.PreferredBackBufferWidth / 2) - (Logo.Width / 2), 100, Logo.Width, Logo.Height);

            SpriteBatch spriteBatch = new SpriteBatch(screenManager.GraphicsDevice);
            Viewport viewport = screenManager.GraphicsDevice.Viewport;
            Rectangle fullscreen = new Rectangle(0, 0, viewport.Width, viewport.Height);

            spriteBatch.Begin();

            spriteBatch.Draw(Pozadi, fullscreen,Color.White);
            PasswordInput.Draw(spriteBatch);
            UsernameInput.Draw(spriteBatch);
            spriteBatch.Draw(TextBoxPozadi, UsernameInputPos, Color.White);
            spriteBatch.Draw(TextBoxPozadi, PasswordInputPos, Color.White);
            spriteBatch.Draw(Logo, LogoPos, Color.White);
            spriteBatch.Draw(buttonLogin, ButtonLoginPos, Color.White);
            spriteBatch.Draw(buttonExit, ButtonExitPos, Color.White);

            spriteBatch.End();
            
            

        }


    }
}
