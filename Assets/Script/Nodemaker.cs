using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Nodemaker : MonoBehaviour {

    //Objects Required
    public Grid thegrid;
    public Tilemap tmap;
    public GameObject Nodefab;

    //Map Scanning Bounds
    public int scanStartX=-100, scanEndX=100, scanStartY=-100, scanEndY= 100;

    //Nodes that Interact
    public List<GameObject> allnodes;
    public GameObject[,] nodegrid;

	void Awake () {
        //initialize allnodes
        allnodes = new List<GameObject>();
	}

    void Start()
    {
        makeNodes();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void makeNodes()
    {
        //go through each spot in the scanning range and establish which tiles are tiles and which aren't
        int mapx=0, mapy = 0;
        for (int x = scanStartX; x < scanEndX; x++)
        {
            for (int y = scanStartY; y < scanEndY; y++)
            {
                TileBase currenttile = tmap.GetTile(new Vector3Int(x, y, 0));
                if (currenttile != null)
                {
                    GameObject node = (GameObject)Instantiate(Nodefab, new Vector3(x + 0.5f + thegrid.transform.position.x, y + 0.5f +
                        thegrid.transform.position.y, 0), Quaternion.Euler(0, 0, 0));

                    allnodes.Add(node);

                    node.name = "Node " + x.ToString() + " : " + y.ToString();
                    Debug.Log(node.name);
                }
            }
        }
    }
    public List<TileBase> getBorderingTiles(int x, int y, Tilemap t)
    {
        List<TileBase> borderList = new List<TileBase>();

        return borderList;
    }
}
