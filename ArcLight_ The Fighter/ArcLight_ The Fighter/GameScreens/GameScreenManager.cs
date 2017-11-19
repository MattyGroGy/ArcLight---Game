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
    public class GameScreenManager : DrawableGameComponent
    {

        SpriteBatch spriteBatch;
        SpriteFont font;
       // Texture2D blankTexture;

        List<GameScreen> screens = new List<GameScreen>();

        bool isInitialized;



        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }

        public SpriteFont Font
        {
            get { return font; }
        }

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

            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = content.Load<SpriteFont>("menufont");
            //blankTexture = content.Load<Texture2D>("blank");

            
            foreach (GameScreen screen in screens)
            {
                screen.LoadContent();
            }
        }


        protected override void UnloadContent()
        {
            foreach (GameScreen screen in screens)
            {
                screen.UnloadContent();
            }
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            
        }

        public void AddScreen(GameScreen screen, PlayerIndex? controllingPlayer)
        {
           

            if (isInitialized)
            {
                screen.LoadContent();
            }

            screens.Add(screen);
        }

        public void RemoveScreen(GameScreen screen)
        {
            // If we have a graphics device, tell the screen to unload content.
            if (isInitialized)
            {
                screen.UnloadContent();
            }

            screens.Remove(screen);
            
        }
    }
}
