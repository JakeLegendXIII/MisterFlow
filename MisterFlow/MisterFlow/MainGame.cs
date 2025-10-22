using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MisterFlow.Data;
using MisterFlow.Entities;
using MisterFlow.Input;
using MisterFlow.Library;
using System;

namespace MisterFlow
{
	public class MainGame : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private RenderTarget2D _renderTarget;
		private Rectangle _renderDestination;
		private float _scale = 1f;

		private int _nativeWidth = 1280;
		private int _nativeHeight = 800;
		private bool _isResizing;
		bool _isFullscreen = false;
		bool _isBorderless = false;
		int _width = 0;
		int _height = 0;

		private GridManager _gridManager;

		public MainGame()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;

			_graphics.PreferredBackBufferWidth = _nativeWidth;
			_graphics.PreferredBackBufferHeight = _nativeHeight;
			_graphics.ApplyChanges();

			Window.Title = "Mr. Flow";
			Window.AllowUserResizing = true;
			Window.ClientSizeChanged += OnClientSizeChanged;
		}

		protected override void Initialize()
		{
			base.Initialize();

			_renderTarget = new RenderTarget2D(GraphicsDevice, _nativeWidth, _nativeHeight);

			CalculateRenderDestination();		
			
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			AssetManager.Load(Content);

			Level level = CreateLevel();

			_gridManager = new GridManager(level);
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			InputManager.Update(_renderDestination, _scale);

			_gridManager.Update(gameTime);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// Add RenterTarget2D to allow screen resizing
			GraphicsDevice.SetRenderTarget(_renderTarget);

			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin(samplerState: SamplerState.PointClamp);

			_gridManager.Draw(_spriteBatch);

			_spriteBatch.End();

			GraphicsDevice.SetRenderTarget(null);

			_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
			_spriteBatch.Draw(_renderTarget, _renderDestination, Color.White);
			_spriteBatch.End();

			base.Draw(gameTime);
		}

		private Level CreateLevel()
		{
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
				GridPosition = new Point(0,0)
			};
			level.Tiles.Add(tile1);

			TileData tile2 = new TileData
			{
				ImageIndex = 1,
				StartRotation = 90f,
				SolvedRotation = 0f,
				IsEndTile = false,
				IsStartTile = false,
				GridPosition= new Point(0,1)
			};
			level.Tiles.Add(tile2);

			TileData tile3 = new TileData
			{
				ImageIndex = 3,
				StartRotation = 180f,
				SolvedRotation = 90f,
				IsEndTile = false,
				IsStartTile = false,
				GridPosition = new Point(0,2)
			};
			level.Tiles.Add(tile3);

			TileData tile4 = new TileData
			{
				ImageIndex = 1,
				StartRotation = 270f,
				SolvedRotation = 180f,
				IsEndTile = false,
				IsStartTile = false,
				GridPosition = new Point(0,3)
			};
			level.Tiles.Add(tile4);

			// Row 2
			TileData tile5 = new TileData
			{
				ImageIndex = 1,
				StartRotation = 0f,
				SolvedRotation = 270f,
				IsEndTile = false,
				IsStartTile = false,
				GridPosition = new Point(1,0)
			};
			level.Tiles.Add(tile5);

			TileData tile6 = new TileData
			{
				ImageIndex = 1,
				StartRotation = 90f,
				SolvedRotation = 0f,
				IsEndTile = false,
				IsStartTile = false,
				GridPosition= new Point(1,1)
			};
			level.Tiles.Add(tile6);

			TileData tile7 = new TileData
			{
				ImageIndex = 1,
				StartRotation = 180f,
				SolvedRotation = 90f,
				IsEndTile = false,
				IsStartTile = false,
				GridPosition = new Point(1,2)
			};
			level.Tiles.Add(tile7);

			TileData tile8 = new TileData
			{
				ImageIndex = 1,
				StartRotation = 270f,
				SolvedRotation = 180f,
				IsEndTile = false,
				IsStartTile = false,
				GridPosition = new Point(1,3)
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
				GridPosition = new Point(2,0)
			};
			level.Tiles.Add(tile9);

			TileData tile10 = new TileData
			{
				ImageIndex = 3,
				StartRotation = 90f,
				SolvedRotation = 0f,
				IsEndTile = false,
				IsStartTile = false,
				GridPosition = new Point(2,1)
			};
			level.Tiles.Add(tile10);

			TileData tile11 = new TileData
			{
				ImageIndex = 1,
				StartRotation = 180f,
				SolvedRotation = 90f,
				IsEndTile = false,
				IsStartTile = false,
				GridPosition = new Point(2,2)
			};
			level.Tiles.Add(tile11);

			TileData tile12 = new TileData
			{
				ImageIndex = 3,
				StartRotation = 270f,
				SolvedRotation = 180f,
				IsEndTile = false,
				IsStartTile = false,
				GridPosition = new Point(2,3)
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
				GridPosition = new Point(3,0)
			};
			level.Tiles.Add(tile13);

			TileData tile14 = new TileData
			{
				ImageIndex = 1,
				StartRotation = 90f,
				SolvedRotation = 0f,
				IsEndTile = false,
				IsStartTile = false,
				GridPosition = new Point(3,1)
			};
			level.Tiles.Add(tile14);

			TileData tile15 = new TileData
			{
				ImageIndex = 3,
				StartRotation = 180f,
				SolvedRotation = 90f,
				IsEndTile = false,
				IsStartTile = false,
				GridPosition = new Point(3,2)
			};
			level.Tiles.Add(tile15);

			TileData tile16 = new TileData
			{
				ImageIndex = 2,
				StartRotation = 0f,
				SolvedRotation = 0f,
				IsEndTile = true,
				IsStartTile = false,
				GridPosition = new Point(3,3)
			};
			level.Tiles.Add(tile16);

			return level;
		}

		private void OnClientSizeChanged(object sender, EventArgs e)
		{
			if (!_isResizing && Window.ClientBounds.Width > 0 && Window.ClientBounds.Height > 0)
			{
				_isResizing = true;

				CalculateRenderDestination();

				_isResizing = false;
			}
		}

		private void CalculateRenderDestination()
		{
			Point size = GraphicsDevice.Viewport.Bounds.Size;

			float scaleX = (float)size.X / _renderTarget.Width;
			float scaleY = (float)size.Y / _renderTarget.Height;

			_scale = Math.Min(scaleX, scaleY);

			_renderDestination.Width = (int)(_renderTarget.Width * _scale);
			_renderDestination.Height = (int)(_renderTarget.Height * _scale);

			_renderDestination.X = (size.X - _renderDestination.Width) / 2;
			_renderDestination.Y = (size.Y - _renderDestination.Height) / 2;
		}

		// Learn MonoGame how-to Fullscreen and Borderless code
		public void ToggleFullscreen()
		{
			bool oldIsFullscreen = _isFullscreen;

			if (_isBorderless)
			{
				_isBorderless = false;
			}
			else
			{
				_isFullscreen = !_isFullscreen;
			}

			ApplyFullscreenChange(oldIsFullscreen);
		}
		public void ToggleBorderless()
		{
			bool oldIsFullscreen = _isFullscreen;

			_isBorderless = !_isBorderless;
			_isFullscreen = _isBorderless;

			ApplyFullscreenChange(oldIsFullscreen);
		}

		private void ApplyFullscreenChange(bool oldIsFullscreen)
		{
			if (_isFullscreen)
			{
				if (oldIsFullscreen)
				{
					ApplyHardwareMode();
				}
				else
				{
					SetFullscreen();
				}
			}
			else
			{
				UnsetFullscreen();
			}
		}
		private void ApplyHardwareMode()
		{
			_graphics.HardwareModeSwitch = !_isBorderless;
			_graphics.ApplyChanges();
		}
		private void SetFullscreen()
		{
			_width = Window.ClientBounds.Width;
			_height = Window.ClientBounds.Height;

			_graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			_graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
			// _graphics.HardwareModeSwitch = !_isBorderless;
			_graphics.HardwareModeSwitch = false;

			_graphics.IsFullScreen = true;
			_graphics.ApplyChanges();
		}
		private void UnsetFullscreen()
		{
			// Reset to default resolution, but we do have the previous Width and Height just tweaky if somebody resized
			_graphics.PreferredBackBufferWidth = _nativeWidth;
			_graphics.PreferredBackBufferHeight = _nativeHeight;

			_graphics.HardwareModeSwitch = false;
			_graphics.IsFullScreen = false;
			_graphics.ApplyChanges();
		}
	}
}
