using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcLight__The_Fighter.GameScreens
{
    class MainMenuSN : Game1
    {
        private Texture2D background;
        private IServiceProvider serviceProvider;
        public static void LoadMM(ContentManager Content)
        {
           var background = Content.Load<Texture2D>("MenuScreen/Pozadi");
        }
    }
}
