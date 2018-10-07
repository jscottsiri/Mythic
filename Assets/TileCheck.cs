using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileCheck : MonoBehaviour {

    public Tile Normal;
    public Tile On;
    public Tilemap tmap;

    public GameObject Selector;

    public bool ison = false;

    public Vector3Int pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        checkpos();
	}
    void checkpos()
    {
        Vector3Int cellpos = tmap.WorldToCell(Selector.transform.position);
        string ttype= tmap.GetTile(cellpos).name;
        if (ttype == Normal.name)
        {
            tmap.SetTile(cellpos, On);
        }
        
        }

}
