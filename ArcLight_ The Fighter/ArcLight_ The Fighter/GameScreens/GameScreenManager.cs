using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArcLight__The_Fighter.GameScreens
{
    public class GameScreenManager : DrawableGameComponent
    {
        GraphicsDevice graphicsDevice;
        SpriteBatch spriteBatch;
        // SpriteFont font;
        // Texture2D blankTexture;

        List<GameScreen> screens = new List<GameScreen>();

        bool isInitialized = false;



        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }

        // public SpriteFont Font
        // {
        //     get { return font; }
        // }

        public GameScreenManager(Game game) : base(game)
        {

        }


        public override void Initialize()
        {
            base.Initialize();
            isInitialized = true;
        }

        protected override void LoadContent()
        {
            ContentManager content = Game.Content;
            
            SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);
            //font = content.Load<SpriteFont>("menufont");
            //blankTexture = content.Load<Texture2D>("blank");


            foreach (GameScreen screen in screens)
            {
                screen.LoadContent();
                 Console.WriteLine(": ContentLoaded: " + screen);
            }
        }


        protected override void UnloadContent()
        {
            foreach (GameScreen screen in screens)
            {
                screen.UnloadContent();
                //   Console.WriteLine("Content UnLoaded for: " + screen);
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameScreen screen in screens)
            {
                screen.Update(gameTime);
                //   Console.WriteLine("Content Updated for: " + screen);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (GameScreen screen in screens)
            {
                screen.Draw(gameTime);
                Console.WriteLine(gameTime + ": Drawed: " + screen);
                //   Console.WriteLine("Content Drawed for: " + screen);
            }
        }

        public void AddScreen(GameScreen screen, PlayerIndex? controllingPlayer)
        {
            //if (isInitialized == true)
            //{
            //    screen.LoadContent();

            //    Console.WriteLine("Screen Added: " + screen);
            //}
            //else { Console.WriteLine("Error while adding screen: " + screen); }
            screens.Add(screen);
        }

        public void RemoveScreen(GameScreen screen)
        {
            screen.UnloadContent();
            
            screens.Remove(screen);
            
        }

        public void ChangeScreen(GameScreen screen, GameScreen oldscreen)
        {
            oldscreen.UnloadContent();
            screens.Add(screen);
            screen.LoadContent();
            screens.Remove(oldscreen);
        }
    }
}
