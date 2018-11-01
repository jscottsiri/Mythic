using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileStats {
    //States
    public int gridX, gridY;
    public int gCost, hCost;
    public int movementweight;
    public Vector3 worldPosition;
    public bool walkable;
    public TileStats parent;

    public GameObject Selector;

    public int fCost
    {
        get
        {
            return gCost+hCost;
        }
    }

    public TileStats(bool _walkable, Vector3Int _worldPos, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }
    // Use this for initialization
    void Start () {
		
	}
}
