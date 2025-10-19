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

	private bool _isStart;
	private bool _isEnd;

	public GridSquare(Vector2 position, Point gridPosition, Rectangle drawBox, bool isStart, bool isEnd)
	{
		_position = position;
		_gridPosition = gridPosition;
		_drawBox = drawBox;

		_texture = AssetManager.Octagons;
		_isStart = isStart;
		_isEnd = isEnd;
	}

	public void Draw(SpriteBatch spriteBatch)
	{
		spriteBatch.Draw(_texture, _position, _drawBox, Color.White);
	}

	public void Update(GameTime gameTime)
	{
		
	}
}
