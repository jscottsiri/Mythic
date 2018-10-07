using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileCheck : MonoBehaviour {

    public Tile Normal;
    public Tile On;
    public Tilemap tmap;

    public GameObject Selector;

    public Vector3Int cellpos;
    public Vector3Int oldcellpos;

	// Use this for initialization
	void Start() { 

	}
	
	// Update is called once per frame
	void Update () {
        revertile();
        changetile();
	}
    void getpos()
    {
        cellpos = tmap.WorldToCell(Selector.transform.position);
    }
    void changetile()
    {
        
        getpos();
        tmap.SetTile(cellpos, On);
    }
    void revertile()
    {
        oldcellpos = cellpos;
        tmap.SetTile(oldcellpos, Normal);
    }

}
