using ArcLight.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace ArcLight
{
    
    public class Game1 : Core
    {
       
        public Game1() : base( 1920, 1080, true, true, "ArcLight")
        {

        }

        protected override void Initialize()
        {
            IntroScene.IntroSceneBase();

            
            base.Initialize();
        }

        
    }
}
