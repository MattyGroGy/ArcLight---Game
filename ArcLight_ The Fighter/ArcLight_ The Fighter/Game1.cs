using ArcLight__The_Fighter.GameScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using ArcLight__The_Fighter.Helpers;
using Microsoft.Xna.Framework.Content;

namespace ArcLight__The_Fighter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        GraphicsDevice graphicsDevice;
        private GameScreenManager screenManager;


        public static Game game;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080; 
            graphics.ApplyChanges();
            //graphics.ToggleFullScreen();
            this.IsMouseVisible = true;
            game = this;
           // spriteBatch = new SpriteBatch(GraphicsDevice);
            Content.RootDirectory = "Content";
            
            screenManager = new GameScreenManager(this);
            Components.Add(screenManager);

            screenManager.AddScreen(new MainMenu(), null);
         //   screenManager.AddScreen(new TestScreen(), null);


            
        }

        


       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}
