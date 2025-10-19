using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MisterFlow.Entities;

internal class GridManager : IGameEntity
{
	private int _gridWidth = 4;
	private int _gridHeight = 4;
	private int _cellSize = 64;

	private List<GridSquare> _gridSquares = new List<GridSquare>();

	private Random _random;

	public GridManager()
	{
		_random = new Random();

		InitializeGrid();
	}

	public void Draw(SpriteBatch spriteBatch)
	{
		foreach (var square in _gridSquares)
		{
			square.Draw(spriteBatch);
		}
	}

	public void Update(GameTime gameTime)
	{
		foreach (var square in _gridSquares)
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
				Rectangle drawBox = CalculateDrawBox(gridPosition);
				// Rectangle drawBox = new Rectangle(0, 0, _cellSize, _cellSize);

				GridSquare gridSquare = new GridSquare(position, gridPosition, drawBox);
				_gridSquares.Add(gridSquare);
			}
		}
	}

	private Rectangle CalculateDrawBox(Point gridPosition)
	{
		// Check if this is the first square (top-left corner)
		if (gridPosition.X == 0 && gridPosition.Y == 0)
		{
			// Third image in sequence (index 2)
			return new Rectangle(_cellSize * 2, 0, _cellSize, _cellSize);
		}
		// Check if this is the last square (bottom-right corner)
		else if (gridPosition.X == _gridWidth - 1 && gridPosition.Y == _gridHeight - 1)
		{
			// Third image in sequence (index 2)
			return new Rectangle(_cellSize * 2, 0, _cellSize, _cellSize);
		}
		else
		{
			// Randomly choose between second (index 1) or fourth (index 3) image
			int tile = _random.Next(1, 3); // Returns 1 or 2

			if (tile == 1)
			{
				// Second image in sequence (index 1)
				return new Rectangle(_cellSize, 0, _cellSize, _cellSize);
			}
			else // tile == 2
			{
				// Fourth image in sequence (index 3)
				return new Rectangle(_cellSize * 3, 0, _cellSize, _cellSize);
			}
		}
	}
}
