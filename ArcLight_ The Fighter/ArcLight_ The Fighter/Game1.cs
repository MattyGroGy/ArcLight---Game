using ArcLight__The_Fighter.GameScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using ArcLight__The_Fighter.Helpers;
using ConsoleTester;

namespace ArcLight__The_Fighter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Song song;

        int Button = 0;


        public Rectangle ButtonExitPos = new Rectangle(896, 836, 256, 64);
        public Rectangle ButtonLogoutPos = new Rectangle(896, 656, 256, 64);
        public Rectangle ButtonOptionsPos = new Rectangle(896, 476, 256, 64);
        public Rectangle ButtonStartPos = new Rectangle(896, 296, 256, 64);



        private Texture2D background;
        private Texture2D buttonExitSel;
        private Texture2D buttonExitDSel;
        private Texture2D buttonLogoutSel;
        private Texture2D buttonLogoutDSel;
        private Texture2D buttonOptionsSel;
        private Texture2D buttonOptionsDSel;
        private Texture2D buttonStartSel;
        private Texture2D buttonStartDSel;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080; 
            graphics.ApplyChanges();
            //graphics.ToggleFullScreen();
            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";


            

        }

        


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("MenuScreen/Pozadi");
            buttonExitSel = Content.Load<Texture2D>("Buttons/ButtonExit1");
            buttonExitDSel = Content.Load<Texture2D>("Buttons/ButtonExit0");
            buttonLogoutSel = Content.Load<Texture2D>("Buttons/ButtonLogout1");
            buttonLogoutDSel = Content.Load<Texture2D>("Buttons/ButtonLogout0");
            buttonOptionsSel = Content.Load<Texture2D>("Buttons/ButtonOptions1");
            buttonOptionsDSel = Content.Load<Texture2D>("Buttons/ButtonOptions0");
            buttonStartSel = Content.Load<Texture2D>("Buttons/ButtonStart1");
            buttonStartDSel = Content.Load<Texture2D>("Buttons/ButtonStart0");
            this.song = Content.Load<Song>("Sounds/Music/MainMenu");
            
            MediaPlayer.Play(song);

            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }



        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            MediaPlayer.Volume -= 0.1f;
            MediaPlayer.Play(song);
            
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                ConsoleTester.Program.SendToConsole("Up pressed!");
                spriteBatch.Begin();
                if (Button == 0)
                {
                    Button = 3;
                    spriteBatch.Draw(buttonStartDSel, ButtonStartPos, Color.White);
                    spriteBatch.Draw(buttonExitSel, ButtonExitPos, Color.White);
                }
                else if (Button == 3)
                {
                    Button = 2;
                    spriteBatch.Draw(buttonExitDSel, ButtonExitPos, Color.White);
                    spriteBatch.Draw(buttonLogoutSel, ButtonLogoutPos, Color.White);
                }
                else if (Button == 2)
                {
                    Button = 1;
                    spriteBatch.Draw(buttonLogoutDSel, ButtonLogoutPos, Color.White);
                    spriteBatch.Draw(buttonOptionsSel, ButtonOptionsPos, Color.White);
                }
                else if (Button == 1)
                {
                    Button = 0;
                    spriteBatch.Draw(buttonOptionsDSel, ButtonOptionsPos, Color.White);
                    spriteBatch.Draw(buttonStartSel, ButtonStartPos, Color.White);
                }
                spriteBatch.End();
            }

           
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            int ScreenWidth = graphics.PreferredBackBufferWidth;
            int ScreenHeight = graphics.PreferredBackBufferHeight;
            int ButtonSizeX = buttonExitSel.Width;
            int ButtonSizeY = buttonExitSel.Height;

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, ScreenWidth,ScreenHeight), Color.White);
            spriteBatch.Draw(buttonExitDSel, ButtonExitPos, Color.White);
            spriteBatch.Draw(buttonLogoutDSel, ButtonLogoutPos, Color.White);
            spriteBatch.Draw(buttonOptionsDSel, ButtonOptionsPos, Color.White);
            spriteBatch.Draw(buttonStartSel, ButtonStartPos, Color.White);



            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
