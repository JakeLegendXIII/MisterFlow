using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MisterFlow.Entities;

internal class GridManager : IGameEntity
{
	private int _gridWidth = 4;
	private int _gridHeight = 4;
	private int _cellSize = 64;

	private List<GridSquare> _gridSquares = new List<GridSquare>();

	public GridManager()
	{
		InitializeGrid();
	}

	public void Draw(SpriteBatch spriteBatch)
	{
		foreach(var square in _gridSquares)
		{
			square.Draw(spriteBatch);
		}
	}

	public void Update(GameTime gameTime)
	{
		foreach(var square in _gridSquares)
		{
			square.Update(gameTime);
		}
	}


	private void InitializeGrid()
	{
		for (int x = 0; x < _gridWidth; x++)
		{
			for (int y = 0; y < _gridHeight; y++)
			{				
				Vector2 position = new Vector2(x * _cellSize, y * _cellSize);
				Point gridPosition = new Point(x, y);

				// TODO : Need to use Level Data to determine Drawbox eventually
				Rectangle drawBox = new Rectangle(0, 0, _cellSize, _cellSize);

				GridSquare gridSquare = new GridSquare(position, gridPosition, drawBox);
				_gridSquares.Add(gridSquare);
			}
		}
	}
}
