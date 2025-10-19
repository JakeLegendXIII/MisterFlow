using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MisterFlow.Input;

internal static class InputManager
{
	private static MouseState mouseState, lastMouseState;
	private static KeyboardState keyboardState, lastKeyboardState;
	private static GamePadState gamePadState, lastGamePadState;

	// Game world awareness things
	private static Rectangle _renderTarget;
	private static float _scale;

	public static InputStates CurrentInputState { get; set; }

	public static void Update(Rectangle renderTarget, float scale)
	{
		lastMouseState = mouseState;
		mouseState = Mouse.GetState();
		lastKeyboardState = keyboardState;
		keyboardState = Keyboard.GetState();
		lastGamePadState = gamePadState;
		gamePadState = GamePad.GetState(PlayerIndex.One);

		_renderTarget = renderTarget;
		_scale = scale;
	}

	public static bool IsKeyPressed(Keys key)
	{
		return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key);
	}

	public static bool IsButtonPressed(Buttons button)
	{
		return gamePadState.IsButtonDown(button) && lastGamePadState.IsButtonUp(button);
	}

	public static bool IsLeftMouseButtonDown()
	{
		return mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton != ButtonState.Pressed;
	}

	public static Vector2 GetTransformedMousePosition(int startX, int startY)
	{
		Vector2 transformedMousePosition = new Vector2((mouseState.X - (_renderTarget.X + (startX * _scale))) / _scale,
																	(mouseState.Y - (_renderTarget.Y + (startY * _scale))) / _scale);
		return transformedMousePosition;
	}

	internal static Point GetMousePosition()
	{
		return mouseState.Position;
	}
}

public enum InputStates
{
	MouseKeyboard,
	GamePad
}
