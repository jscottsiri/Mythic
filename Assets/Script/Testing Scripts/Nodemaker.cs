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
    public int gridboundX = 0, gridboundY = 0, gridendX = 7, gridendY=7;
    //Nodes that Interact
    public List<GameObject> allnodes;
    public GameObject[,] nodegrid;

    int diagonal = 14;
    int straight = 10;

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
        for (int x = scanStartX; x < scanEndX; x++)
        {
            for (int y = scanStartY; y < scanEndY; y++)
            {
                TileBase currenttile = tmap.GetTile(new Vector3Int(x, y, 0));
                if (currenttile != null)
                {
                    GameObject node = (GameObject)Instantiate(Nodefab, new Vector3(x + 0.5f + tmap.transform.position.x, y + 0.5f +
                        tmap.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
                    Node Describe = new Node(1.0f, x, y);
                    //node.AddComponent<Node(1.0f, x, y)>;

                    allnodes.Add(node);

                    node.name = "Node " + x.ToString() + " : " + y.ToString();
                    Debug.Log(node.name);
                }
            }
        }
    }
    public List<TileStats> getBorderingTiles(int x, int y, int width, int height)
    {
        List<TileStats> borderList = new List<TileStats>();
        nodegrid = new GameObject[gridboundX+1,gridboundY+1];
        foreach (GameObject g in allnodes)
        {
            //turns nodes into a list
            TileStats TS = g.GetComponent<TileStats>();
            Debug.Log(TS.gridX + " " + TS.gridY);
            nodegrid[TS.gridX, TS.gridY] = g;
        }
        if (x > 0 && x < width -1 ) // left and right
        {
            if (y> 0 && y < height -1 ) // top and bottom
            {
                //Go through each neighboring node and add it to a borderlist
               if (nodegrid[x+1,y]!= null)
                {
                    TileStats TS1 = nodegrid[x + 1, y].GetComponent<TileStats>();
                    if (TS1 != null)
                    {
                        borderList.Add(TS1);
                    }
                }
               if (nodegrid[x-1,y] != null)
                {
                    TileStats TS2 = nodegrid[x - 1, y].GetComponent<TileStats>();
                    if (TS2 != null)
                    {
                        borderList.Add(TS2);
                    }
                }
               if (nodegrid[x,y+1] != null)
                {
                    TileStats TS3 = nodegrid[x, y + 1].GetComponent<TileStats>();
                    if (TS3 != null)
                    {
                        borderList.Add(TS3);
                    }
                }
               if (nodegrid[x, y - 1] != null)
                {
                    TileStats TS4 = nodegrid[x, y - 1].GetComponent<TileStats>();
                    if (TS4 != null)
                    {
                        borderList.Add(TS4);
                    }
                }
               else if (y == 0)
                {
                    if (nodegrid [x +1, y] != null)
                    {
                        TileStats TS1 = nodegrid[x + 1, y].GetComponent<TileStats>();
                        if (TS1 != null)
                        {
                            borderList.Add(TS1);
                        }
                    }
                    if (nodegrid[x-1,y]!= null)
                    {
                        TileStats TS2 = nodegrid[x - 1, y].GetComponent<TileStats>();
                        if (TS2 != null)
                        {
                            borderList.Add(TS2);
                        }
                    }
                    if (nodegrid[x, y + 1] != null)
                    {
                        TileStats TS3 = nodegrid[x, y+1].GetComponent<TileStats>();
                        if (TS3 != null)
                        {
                            borderList.Add(TS3);
                        }
                    }
                    if (nodegrid[x, y -1] != null)
                    {
                        TileStats TS4 = nodegrid[x, y - 1].GetComponent<TileStats>();
                        if (TS4 != null)
                        {
                            borderList.Add(TS4);
                        }
                    }
                }
               else if (y == height - 1)
                {
                    if (nodegrid[x, y-1] != null)
                    {
                        TileStats TS4 = nodegrid[x, y - 1].GetComponent<TileStats>();
                        if (TS4 != null)
                        {
                            borderList.Add(TS4);
                        }
                    }
                    if (nodegrid[x+1,y] != null)
                    {
                        TileStats TS1 = nodegrid[x + 1, y].GetComponent<TileStats>();
                        if (TS1 != null)
                        {
                            borderList.Add(TS1);
                        }
                    }
                    if (nodegrid[x-1,y] != null)
                    {
                        TileStats TS2 = nodegrid[x - 1,y].GetComponent<TileStats>();
                        if (TS2 != null)
                        {
                            borderList.Add(TS2);
                        }
                    }
                }

            }
            else if (x == 0)
            {
                if (y>0 && y< height - 1)
                {
                    if (nodegrid[x+1,y]!= null)
                    {
                        TileStats TS1 = nodegrid[x + 1, y].GetComponent<TileStats>();
                        if (TS1 != null)
                        {
                            borderList.Add(TS1);
                        }
                    }
                    if (nodegrid[x,y-1] != null)
                    {
                        TileStats TS4 = nodegrid[x, y - 1].GetComponent<TileStats>();
                        if (TS4 != null)
                        {
                            borderList.Add(TS4);
                        }
                    }
                    if (nodegrid[x,y+1] != null)
                    {
                        TileStats TS3 = nodegrid[x, y + 1].GetComponent<TileStats>();
                        if (TS3 != null)
                        {
                            borderList.Add(TS3);
                        }
                    }
                }
                else if (y == 0)
                {
                    if (nodegrid[x+1,y]!= null)
                    {
                        TileStats TS1 = nodegrid[x + 1, y].GetComponent<TileStats>();
                        if (TS1 != null)
                        {
                            borderList.Add(TS1);
                        }
                    }
                    if (nodegrid[x,y+1] != null)
                    {
                        TileStats TS3 = nodegrid[x, y = 1].GetComponent<TileStats>();
                        if (TS3 != null)
                        {
                            borderList.Add(TS3);
                        }
                    }

                }
                else if (y== height - 1)
                {
                    if (nodegrid[x+1,y]!= null)
                    {
                        TileStats TS1 = nodegrid[x + 1, y].GetComponent<TileStats>();
                        if (TS1 != null)
                        {
                            borderList.Add(TS1);
                        }
                    }
                    if (nodegrid[x, y - 1] != null)
                    {
                        TileStats TS4 = nodegrid[x, y - 1].GetComponent<TileStats>();
                        if (TS4 != null)
                        {
                            borderList.Add(TS4);
                        }
                    }

                }
            }
            else if (x == width - 1)
            {
                if (y>0 && y <height - 1)
                {
                    if (nodegrid[x - 1, y] != null)
                    {
                        TileStats TS2 = nodegrid[x - 1, y].GetComponent<TileStats>();
                        if (TS2 != null)
                        {
                            borderList.Add(TS2);
                        }
                    }
                    if (nodegrid[x,y+1]!= null)
                    {
                        TileStats TS3 = nodegrid[x, y + 1].GetComponent<TileStats>();
                        if (TS3 != null)
                        {
                            borderList.Add(TS3);
                        }
                    }
                    if (nodegrid [x,y-1] != null){
                        TileStats TS4 = nodegrid[x, y - 1].GetComponent<TileStats>();
                        if (TS4 != null)
                        {
                            borderList.Add(TS4);
                        }
                    }

                }
                else if (y == 0)
                {
                    if (nodegrid [x-1,y] != null)
                    {
                        TileStats TS2 = nodegrid[x - 1,y].GetComponent<TileStats>();
                        if (TS2 != null)
                        {
                            borderList.Add(TS2);
                        }
                    }
                    if (nodegrid[x,y+1] != null)
                    {
                        TileStats TS3 = nodegrid[x, y + 1].GetComponent<TileStats>();
                        if (TS3 != null)
                        {
                            borderList.Add(TS3);
                        }
                    }
                }
                else if (y == height - 1)
                {
                    if (nodegrid[x - 1, y] != null)
                    {
                        TileStats TS2 = nodegrid[x - 1, y].GetComponent<TileStats>();
                        if (TS2 != null)
                        {
                            borderList.Add(TS2);
                        }
                    }
                    if (nodegrid[x,y-1]!= null)
                    {
                        TileStats TS4 = nodegrid[x, y - 1].GetComponent<TileStats>();
                        if (TS4 != null)
                        {
                            borderList.Add(TS4);
                        }
                    }
                }
            }

        }
        return borderList;
    }
    public void Astar(List<TileStats> bordertiles, Vector3Int select, Vector3Int charpos)
    {
        
        
        
    }
    void RetracePath(TileStats startnode, TileStats endnode)
    {
        List<TileStats> path = new List<TileStats>();
        TileStats currentNode = endnode;

        while (currentNode != startnode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();
        thegrid.path = path;
    }
    int GetDistance(TileStats a, TileStats b)
    {
        int distx = Mathf.Abs(a.gridX - b.gridX);
        int disty = Mathf.Abs(a.gridY - b.gridY);
        if (distx > disty)
            return diagonal * disty + straight * (distx - disty);
        return diagonal * distx + straight * (disty - distx);
    }
}
