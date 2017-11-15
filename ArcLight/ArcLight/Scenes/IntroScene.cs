using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nez;
using Microsoft.Xna.Framework;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;

namespace ArcLight.Scenes
{
    class IntroScene
    {
        public static void IntroSceneBase()
        {
            var scene = Scene.create( Color.White);
            var Render1 = scene.addRenderer<Renderer>(Renderer);
            //Entity Creation
            var SSPS = scene.createEntity("SSPS");

            //Textures
            var SSPS_Texture = scene.content.Load<Texture2D>("IntroScene/IntroImages/SSPS");

            //Entity Component Loader
            SSPS.addComponent(new Sprite( SSPS_Texture ));

            //Entity Transform
            SSPS.transform.position = new Vector2(960, 540);
            SSPS

            Core.scene = scene;
        }
    }
}
