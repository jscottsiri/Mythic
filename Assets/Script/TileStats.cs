using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileStats : MonoBehaviour {
    //States
    public bool current = false;
    public bool target = false;
    public bool walkable = false;
    public int gridX, gridY;

    public int movementweight;

    public GameObject Selector;

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (current)
        {
        }
        else if (target)
        {

        }
        else if (walkable)
        {

        }
        else
        {

        }
	}
}
