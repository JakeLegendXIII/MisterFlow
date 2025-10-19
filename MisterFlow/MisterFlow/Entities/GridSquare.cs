using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MisterFlow.Library;

namespace MisterFlow.Entities;
internal class GridSquare : IGameEntity
{
	private Vector2 _position;
	private Point _gridPosition;
	private Rectangle _drawBox;

	private Texture2D _texture;

	public GridSquare(Vector2 position, Point gridPosition, Rectangle drawBox)
	{
		_position = position;
		_gridPosition = gridPosition;
		_drawBox = drawBox;

		_texture = AssetManager.Octagons;
	}

	public void Draw(SpriteBatch spriteBatch)
	{
		spriteBatch.Draw(_texture, _position, _drawBox, Color.White);
	}

	public void Update(GameTime gameTime)
	{
		
	}
}
