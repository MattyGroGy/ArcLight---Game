using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcLight__The_Fighter.GameScreens
{
    public abstract class GameScreen
    {

        


        public virtual void LoadContent()
        {
            Console.WriteLine("Content Loaded!");
        }

        public virtual void UnloadContent()
        {
            Console.WriteLine("Content UnLoaded!");
        }

        

        public virtual void Update(GameTime gameTime)
        {
            Console.WriteLine("Content Updated!");
        }

        public virtual void Draw(GameTime gameTime)
        {
            Console.WriteLine("Content Drawed!");
        }



        public GameScreenManager ScreenManager
        {
            get { return screenManager; }
            internal set { screenManager = value; }
        }

        GameScreenManager screenManager;



        public void ExitScreen()
        {
            

                ScreenManager.RemoveScreen(this);
        }
    }
}
