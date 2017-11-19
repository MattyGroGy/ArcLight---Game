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

        }

        public virtual void UnloadContent()
        {

        }

        

        public virtual void Update(GameTime gameTime)
        {
           
        }

        public virtual void Draw(GameTime gameTime)
        {

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
