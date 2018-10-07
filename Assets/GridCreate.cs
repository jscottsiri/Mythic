using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GridCreate : MonoBehaviour {

    //Grid Size
    int GridMaxX = 8;
    int GridMaxY = 8;

    //Grid Create
    int[,] mapgrid;

    public Tilemap Tilemaker;
    public Tile UseTile;
    public GameObject Selector;
    Vector3 posit;
	// Use this for initialization
	void Start () {
        mapgrid = new int[GridMaxX, GridMaxY];
        for (int x = 0; x<GridMaxX; x++)
        {
            for (int y=0; y<GridMaxY; y++)
            {
                mapgrid[x, y] = 0;
            }
        }
        
        GenerateMap();
	}
    void GenerateMap()
    {
        for (int x= 0; x < GridMaxX; x++)
        {
            for (int  y = 0; y < GridMaxY; y++)
            {
                Tilemaker.SetTile(new Vector3Int(x, y, 0), UseTile);
            }
        }
    }
    void OnMouseDown()
    {
        //get mouse position
        posit = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //convert to proper placement
        posit.x = Mathf.Floor(posit.x) + 0.5f;
        posit.y = Mathf.Floor(posit.y) + 0.5f;
        posit.z = 0;

        //move selector
        Selector.transform.position=posit;
        Debug.Log(posit.x + ", "+posit.y);
    } 

}
