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
	public float Rotation { get; init; }
}