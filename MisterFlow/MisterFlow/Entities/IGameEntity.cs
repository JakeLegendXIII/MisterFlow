using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MisterFlow.Entities;

internal interface IGameEntity
{
	void Update(GameTime gameTime);
	void Draw(SpriteBatch spriteBatch);
}

