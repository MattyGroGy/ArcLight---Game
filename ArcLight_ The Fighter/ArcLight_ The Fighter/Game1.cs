using ArcLight__The_Fighter.GameScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using ArcLight__The_Fighter.Helpers;


namespace ArcLight__The_Fighter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        private GameScreenManager screenManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080; 
            graphics.ApplyChanges();
            //graphics.ToggleFullScreen();
            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";

            screenManager = new GameScreenManager(this);
            Components.Add(screenManager);

            screenManager.AddScreen(new MainMenu(), null);
        }

        


       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}
