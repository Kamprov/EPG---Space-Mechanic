using UnityEngine;
using System.Collections;

//Level is a basic logic class behind each scene
public class Level
{
	//
	//Resources:
	private int metal = 0;
	//private int batteries = 0;
	//private int electronics = 0;

	public Tile[,] levelTiles;


	public Level(int width, int height)
	{
		levelTiles = new Tile[width,height];

		initTiles(width, height);
	}

	public void AddMetal()
	{
		metal++;
	}

	public int GetMetalQuantity()
	{
		return this.metal;
	}

	public void DisplayTiles()
	{
		for(int x = 0; x < levelTiles.GetLength(0); x++)
		{
			for(int y = 0; y < levelTiles.GetLength(1); y++)
			{
				Debug.Log(levelTiles[x, y].GetTileInformation());
			}
		}
	}

	//Method used to initialize all map tiles
	//TODO: check what sprite is located at given tile and pass this information with tile initialization
	private void initTiles(int width, int height)
	{
		Collider2D tempCollider;

		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				levelTiles[x, y] = new Tile(x, y);

				tempCollider = Physics2D.OverlapCircle(new Vector2(x + 0.5f, y + 0.5f), 0.0001f);

				if(tempCollider == null)
				{
					levelTiles[x, y].tileType = Tile.TileType.OuterSpace;
				}
				else if(tempCollider.tag.Equals("Floor"))
				{
					levelTiles[x, y].tileType = Tile.TileType.FloorTile;
				}
				else if(tempCollider.tag.Equals("Wall"))
				{
					levelTiles[x, y].tileType = Tile.TileType.WallTile;
				}
			}
		}
	}
}
