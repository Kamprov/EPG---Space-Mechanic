using UnityEngine;
using System.Collections;

//Controller responsible for level Level logic initialization
public class LevelController : MonoBehaviour
{
	//Public fields responsible for setting level dimension, remember that first tile is [0,0] and last one is [Width-1, Height - 1]
	public int Width;
	public int Height;

	private static Level level;

	public void Start()
	{
		if(level != null)
		{
			return;
		}

		level = new Level(Width, Height);

		level.DisplayTiles();
	}

	public static Level GetLevel()
	{
		return level;
	}
}
