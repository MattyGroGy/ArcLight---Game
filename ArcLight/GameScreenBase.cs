using System;
using Microsoft.Xna

public class GameScreenBase
{
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
