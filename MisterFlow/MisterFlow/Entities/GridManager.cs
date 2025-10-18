using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MisterFlow.Entities;

internal class GridManager : IGameEntity
{
	private int _gridWidth = 8;
	private int _gridHeight = 8;
	private int _cellSize = 64;

	private List<GridSquare> _gridSquares = new List<GridSquare>();

	public GridManager()
	{
		InitializeGrid();
	}

	public void Draw(SpriteBatch spriteBatch)
	{
		
	}

	public void Update(GameTime gameTime)
	{
		
	}


	private void InitializeGrid()
	{
		for (int x = 0; x < _gridWidth; x++)
		{
			for (int y = 0; y < _gridHeight; y++)
			{				
				Vector2 position = new Vector2(x * _cellSize, y * _cellSize);
				Point gridPosition = new Point(x, y);

				GridSquare gridSquare = new GridSquare(position, gridPosition);
				_gridSquares.Add(gridSquare);
			}
		}
	}
}
