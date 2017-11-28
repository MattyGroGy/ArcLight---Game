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
    class LoadingScreen : GameScreen
    {
        NetClient client;

        ContentManager content;
        GameScreenManager screenManager;

        private SpriteFont MainMenuFont;

        private Texture2D Pozadi;

        private Song song;


        private int Time = 0;
        private int TimeLimit = 20000;
        public LoadingScreen()
        {
        }

        public override void LoadContent()
        {
            screenManager = new GameScreenManager(Game1.game);
            content = new ContentManager(screenManager.Game.Content.ServiceProvider, "Content");

            song = content.Load<Song>("Sounds/Music/MainMenu");
            Pozadi = content.Load<Texture2D>("MenuScreen/Pozadi");

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

            NetIncomingMessage inc;
            while ((inc = client.ReadMessage()) != null)
            {

                switch (inc.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        string ServerMSG;
                        string Msg = inc.ReadString();
                        if (Msg == "x")
                        {
                            screenManager.AddScreen(new LoginScreen(), null);
                            LoginScreen.ShowError("Username and password does not match!");
                            screenManager.RemoveScreen(new LoadingScreen());
                        }
                        else
                        {
                            
                        }
                        ServerMSG = ("Server on andress " + inc.SenderEndPoint + " responded with token: " + inc.ReadString());
                        Console.WriteLine(ServerMSG);
                        break;

                }

            }
            
            Console.WriteLine(Time);
            /*  if (Time == TimeLimit)
              {
                  Console.WriteLine("Connection Timeout");
                  screenManager.AddScreen(new LoginScreen(), null);
                  screenManager.RemoveScreen(this);
             }
             */
        }

        public override void Draw(GameTime gameTime)
        {


            SpriteBatch spriteBatch = new SpriteBatch(screenManager.GraphicsDevice);
            Viewport viewport = screenManager.GraphicsDevice.Viewport;
            Rectangle fullscreen = new Rectangle(0, 0, viewport.Width, viewport.Height);

            spriteBatch.Begin();

            spriteBatch.Draw(Pozadi, fullscreen, Color.White);

            spriteBatch.End();



        }


    }
}
