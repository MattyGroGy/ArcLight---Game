using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

public class GameScreenBase
{
    protected ContentManager Content;


	public virtual void Update(GameTime gameTime)
	{
	}

    public virtual void Draw(SpriteBatch spriteBatch)
    {

    }

    public virtual void LoadContent()
    {
    }

    public virtual void UnloadContent()
    {
    }
}
