using UnityEngine;
using System.Collections;

public enum GameBoardTile
{
	EMPTY,
	FULL,
	GOAL,
	START,
}

[System.Serializable]
public class TilePrefab
{
	public GameBoardTile Key;
	public GameObject Value;
}

public class GameBoardTester : MonoBehaviour
{
	public GameObject playerObject = null;

	[SerializeField]
	[HideInInspector]
	private int sizeX;

	[SerializeField]
	[HideInInspector]
	private int sizeY;

	public int SizeX
	{
		get
		{
			return sizeX;
		}

		set
		{
			int oldSizeX = sizeX;
			sizeX = value;
			if (oldSizeX != sizeX) ResizeTileArray(oldSizeX, SizeY);
		}
	}

	public int SizeY
	{
		get
		{
			return SizeY;
		}

		set
		{
			int oldSizeX = sizeX;
			sizeX = value;
			if (oldSizeX != sizeX) ResizeTileArray(oldSizeX, SizeY);
		}
	}

	public void ResizeTileArray(int oldSizeX, int sizeY)
	{

	}
}
