using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MisterFlow.Entities;

internal class GridManager : IGameEntity
{
	private int _gridWidth = 8;
	private int _gridHeight = 8;
	private int _cellSize = 64;

	public GridManager()
	{

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

				//GridSquare gridSquare = new GridSquare(GetObstacleData(x, y), position, _cellSize, gridPosition,
				//	IsWalkablePoint(x, y), IsWater(x, y), IsWinPosition(x, y), IsDestructable(x, y));
				//_gridSquares.Add(gridSquare);
			}
		}
	}
}
