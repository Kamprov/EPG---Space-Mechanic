using UnityEngine;
using System.Collections;

//Each 1x1 unity unit is a tile
//This class holds information about each tile
//What it holds, is it passable, and so on
public class Tile
{
	//Tile types, basic building blocks of a scene, possibly no ModuleTile in the future(Module might be better of as entity)
	//All entities such as Player, Robots, Fire, Spawned resources itd reside on a tile
	public enum TileType
	{
		FloorTile,
		WallTile,
		ModuleTile,
		OuterSpace
	}

	public TileType tileType;

	//Coordinates of a tile in our scene
	//It should be aware of its position on map
	private int x;
	private int y;

	public Tile(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public Vector2 getTilePosition()
	{
		return new Vector2(this.x, this.y);
	}

	public string GetTileInformation()
	{
		return this.tileType + " Tile:[" + this.x + "," + this.y + "]";
	}
}
