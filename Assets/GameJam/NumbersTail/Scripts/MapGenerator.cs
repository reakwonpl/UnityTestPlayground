using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public Transform tilePrefab;
	public Vector2 gridMapSize;    
    public Transform obstacePrefab;
    [Range(0, 2)]
    public float outline;
    public int seed;

    List<Coordinates> allTilesCoords;
    Queue<Coordinates> shuffledTileCoords;

    private void Start()
    {
        GenerateMap();    
    }

   
    public void GenerateMap()
	{
        allTilesCoords = new List<Coordinates>();

        for(int x = 0; x < gridMapSize.x;x++)
        {
            for (int y = 0; y < gridMapSize.y; y++)
            {
                allTilesCoords.Add(new Coordinates(x,y));
            }
        }
        shuffledTileCoords = new Queue<Coordinates>(Utility.ShuffleArray(allTilesCoords.ToArray(),seed));

        string holderName = "Generated Grid";
        if(transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }
        Transform gridHolder = new GameObject(holderName).transform;
        gridHolder.parent = transform;

		for(int x = 0; x < gridMapSize.x; x++)
        {
            for(int y = 0; y < gridMapSize.y;y++)
            {
                Vector3 tilePos = CoordToPosition(x,y);
                Transform nTile = Instantiate(tilePrefab, tilePos, Quaternion.Euler(Vector3.right * 90)) as Transform;
                nTile.localScale = Vector3.one * (1 - outline);
                nTile.parent = gridHolder;
            }
        }

        int obstacleCount = 10;
        for (int i = 0; i < obstacleCount; i++)
        {
            Coordinates rndCoord = GetRandomCoordinate();
            Vector3 obstaclePosition = CoordToPosition(rndCoord.x, rndCoord.y);
            Transform newObstacle = Instantiate(obstacePrefab,obstaclePosition + Vector3.up * 0.5f,Quaternion.identity) as Transform;
            newObstacle.parent = gridHolder;
        }
	}

    public Vector3 CoordToPosition(int x,int y)
    {
        return new Vector3(-gridMapSize.x / 2 + 0.5f + x, 0, -gridMapSize.y + 0.5f + y);
    }

    public Coordinates GetRandomCoordinate()
    {
        Coordinates rndCoordinate = shuffledTileCoords.Dequeue();
        shuffledTileCoords.Enqueue(rndCoordinate);
        return rndCoordinate;
    }

    public struct Coordinates
    {
        public int x;
        public int y;
        public Coordinates(int _x,int _y)
        {
            x = _x;
            y = _y;
        }
    }

}