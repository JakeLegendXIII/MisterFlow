using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MisterFlow.Data;

internal class Level
{
	public int Width { get; init; }
	public int Height { get; init; }
	public int Size { get; init; }

	public List<TileData> Tiles { get; init; } = new List<TileData>();

	public Level(int width, int height, int size)
	{
		Width = width;
		Height = height;
		Size = size;
	}
}

internal class TileData
{
	public int ImageIndex { get; init; }
	public float StartRotation { get; init; }
	public float SolvedRotation { get; init; }
	public bool IsStartTile { get; init; }
	public bool IsEndTile { get; init; }
	public Point GridPosition { get; init; }
}