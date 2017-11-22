using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcLight__The_Fighter.Helpers
{
    class MouseClickHandler
    {


        public static bool IsMouseButtonPressed(int buttonNumber)
        {
            MouseState mouseState = Mouse.GetState();
            if (buttonNumber == 1)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    return true;
                }
                else
                    return false;
            }
            else if (buttonNumber == 2)
            {
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    return true;
                }
                else
                    return false;
            }
            else if (buttonNumber == 3)
            {
                if (mouseState.MiddleButton == ButtonState.Pressed)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }


        public static bool MouseButtonClick(Rectangle button)
        {
            MouseState mouseState = Mouse.GetState();
            
            int x = mouseState.Position.X;
            int y = mouseState.Position.Y;
            Rectangle mousePlace = new Rectangle(x, y, 10, 10);
            if (mousePlace.Intersects(button) && mouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }
    }
}
