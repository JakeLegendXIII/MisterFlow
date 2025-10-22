using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MisterFlow.Data;
using System.Collections.Generic;

namespace MisterFlow.Entities;

internal class LevelManager : IGameEntity
{
    private List<Level> _levels;
    private GridManager _gridManager;

    public LevelManager()
    {
        _levels = CreateLevels();
        _gridManager = new GridManager(_levels[0]);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _gridManager.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
        _gridManager.Update(gameTime);
    }

    private List<Level> CreateLevels()
    {
        List<Level> levels = new List<Level>();

        Level level = new Level(64, 64, 4);

        // Setup Tiles - 4x4 grid = 16 tiles

        // Row 1
        TileData tile1 = new TileData
        {
            ImageIndex = 2,
            StartRotation = 270f,
            SolvedRotation = 270f,
            IsEndTile = false,
            IsStartTile = true,
            GridPosition = new Point(0, 0)
        };
        level.Tiles.Add(tile1);

        TileData tile2 = new TileData
        {
            ImageIndex = 3,
            StartRotation = 90f,
            SolvedRotation = 0f,
            IsEndTile = false,
            IsStartTile = false,
            GridPosition = new Point(0, 1)
        };
        level.Tiles.Add(tile2);

        TileData tile3 = new TileData
        {
            ImageIndex = 1,
            StartRotation = 180f,
            SolvedRotation = 90f,
            IsEndTile = false,
            IsStartTile = false,
            GridPosition = new Point(0, 2)
        };
        level.Tiles.Add(tile3);

        TileData tile4 = new TileData
        {
            ImageIndex = 3,
            StartRotation = 270f,
            SolvedRotation = 180f,
            IsEndTile = false,
            IsStartTile = false,
            GridPosition = new Point(0, 3)
        };
        level.Tiles.Add(tile4);

        // Row 2
        TileData tile5 = new TileData
        {
            ImageIndex = 3,
            StartRotation = 0f,
            SolvedRotation = 270f,
            IsEndTile = false,
            IsStartTile = false,
            GridPosition = new Point(1, 0)
        };
        level.Tiles.Add(tile5);

        TileData tile6 = new TileData
        {
            ImageIndex = 3,
            StartRotation = 90f,
            SolvedRotation = 0f,
            IsEndTile = false,
            IsStartTile = false,
            GridPosition = new Point(1, 1)
        };
        level.Tiles.Add(tile6);

        TileData tile7 = new TileData
        {
            ImageIndex = 3,
            StartRotation = 180f,
            SolvedRotation = 90f,
            IsEndTile = false,
            IsStartTile = false,
            GridPosition = new Point(1, 2)
        };
        level.Tiles.Add(tile7);

        TileData tile8 = new TileData
        {
            ImageIndex = 3,
            StartRotation = 270f,
            SolvedRotation = 180f,
            IsEndTile = false,
            IsStartTile = false,
            GridPosition = new Point(1, 3)
        };
        level.Tiles.Add(tile8);

        // Row 3
        TileData tile9 = new TileData
        {
            ImageIndex = 1,
            StartRotation = 90f,
            SolvedRotation = 270f,
            IsEndTile = false,
            IsStartTile = false,
            GridPosition = new Point(2, 0)
        };
        level.Tiles.Add(tile9);

        TileData tile10 = new TileData
        {
            ImageIndex = 3,
            StartRotation = 90f,
            SolvedRotation = 0f,
            IsEndTile = false,
            IsStartTile = false,
            GridPosition = new Point(2, 1)
        };
        level.Tiles.Add(tile10);

        TileData tile11 = new TileData
        {
            ImageIndex = 3,
            StartRotation = 180f,
            SolvedRotation = 90f,
            IsEndTile = false,
            IsStartTile = false,
            GridPosition = new Point(2, 2)
        };
        level.Tiles.Add(tile11);

        TileData tile12 = new TileData
        {
            ImageIndex = 1,
            StartRotation = 270f,
            SolvedRotation = 180f,
            IsEndTile = false,
            IsStartTile = false,
            GridPosition = new Point(2, 3)
        };
        level.Tiles.Add(tile12);

        // Row 4
        TileData tile13 = new TileData
        {
            ImageIndex = 3,
            StartRotation = 0f,
            SolvedRotation = 270f,
            IsEndTile = false,
            IsStartTile = false,
            GridPosition = new Point(3, 0)
        };
        level.Tiles.Add(tile13);

        TileData tile14 = new TileData
        {
            ImageIndex = 3,
            StartRotation = 90f,
            SolvedRotation = 0f,
            IsEndTile = false,
            IsStartTile = false,
            GridPosition = new Point(3, 1)
        };
        level.Tiles.Add(tile14);

        TileData tile15 = new TileData
        {
            ImageIndex = 1,
            StartRotation = 180f,
            SolvedRotation = 90f,
            IsEndTile = false,
            IsStartTile = false,
            GridPosition = new Point(3, 2)
        };
        level.Tiles.Add(tile15);

        TileData tile16 = new TileData
        {
            ImageIndex = 2,
            StartRotation = 0f,
            SolvedRotation = 0f,
            IsEndTile = true,
            IsStartTile = false,
            GridPosition = new Point(3, 3)
        };
        level.Tiles.Add(tile16);

        levels.Add(level);

        return levels;
    }
}
