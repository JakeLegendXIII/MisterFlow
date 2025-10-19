using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MisterFlow.Graphics;
using MisterFlow.Input;
using MisterFlow.Library;
using System;

namespace MisterFlow.Entities;
internal class GridSquare : IGameEntity
{
	private Vector2 _position;
	private Point _gridPosition;
	private Rectangle _drawBox;
	private Rectangle _positionRectangle;

	private Texture2D _texture;

	private bool _isStart;
	private bool _isEnd;
	private float _rotation; // Rotation in radians
	private Vector2 _origin; // Origin point for rotation

	public GridSquare(Vector2 position, Point gridPosition, Rectangle drawBox, bool isStart, bool isEnd)
	{
		_position = position;
		_positionRectangle = new Rectangle((int)position.X, (int)position.Y, drawBox.Width, drawBox.Height);
		_gridPosition = gridPosition;
		_drawBox = drawBox;

		_texture = AssetManager.Octagons;
		_isStart = isStart;
		_isEnd = isEnd;
		_rotation = 0f;
		// Set origin to center of the sprite for rotation
		_origin = new Vector2(drawBox.Width / 2f, drawBox.Height / 2f);
	}

	public void Draw(SpriteBatch spriteBatch)
	{
		Vector2 squareMousePosition = InputManager.GetTransformedMousePosition(_positionRectangle.X, _positionRectangle.Y);

		if (squareMousePosition.X >= 0 && squareMousePosition.X <= 64 &&
				squareMousePosition.Y >= 0 && squareMousePosition.Y <= 64)
		{
			RectangleSprite.DrawRectangle(spriteBatch, _positionRectangle, Color.White, 5);
		}

		// Draw with rotation - adjust position to account for origin offset
		Vector2 drawPosition = _position + _origin;
		spriteBatch.Draw(_texture, drawPosition, _drawBox, Color.White, _rotation, _origin, 1f, SpriteEffects.None, 0f);
	}

	public void Update(GameTime gameTime)
	{
		// Check if mouse is over this square and left button is clicked
		if (!_isStart && !_isEnd)
		{
			Vector2 squareMousePosition = InputManager.GetTransformedMousePosition(_positionRectangle.X, _positionRectangle.Y);

			if (squareMousePosition.X >= 0 && squareMousePosition.X <= 64 &&
				squareMousePosition.Y >= 0 && squareMousePosition.Y <= 64)
			{
				if (InputManager.IsLeftMouseButtonDown())
				{
					// Rotate 90 degrees clockwise (PI/2 radians)
					_rotation += MathHelper.PiOver2;
					
					// Keep rotation within 0 to 2*PI range (optional, for cleaner values)
					if (_rotation >= MathHelper.TwoPi)
					{
						_rotation -= MathHelper.TwoPi;
					}
				}
			}
		}
	}
}
