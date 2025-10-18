using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace MisterFlow.Library;

internal static class AssetManager
{
	public static SpriteFont ArmadaFont { get; private set; }
	public static SpriteFont AramdaFont64 { get; private set; }
	public static SpriteFont FarawayFont { get; private set; }

	public static Texture2D Octagons { get; set; }

	public static void Load(ContentManager content)
	{
		ArmadaFont = content.Load<SpriteFont>("Fonts/ArmadaBold16");
		AramdaFont64 = content.Load<SpriteFont>("Fonts/Armada64");
		FarawayFont = content.Load<SpriteFont>("Fonts/Faraway16");

		Octagons = content.Load<Texture2D>("Sprites/Octagons");
	}
}
