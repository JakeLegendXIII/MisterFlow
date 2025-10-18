using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MisterFlow.Entities;
internal class GridSquare : IGameEntity
{
	private Vector2 _position;
	private Point _gridPosition;

	public GridSquare(Vector2 position, Point gridPosition)
	{
		_position = position;
		_gridPosition = gridPosition;
	}

	public void Draw(SpriteBatch spriteBatch)
	{
		
	}

	public void Update(GameTime gameTime)
	{
		
	}
}
