using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Nodemaker : MonoBehaviour {

    //Objects Required
    public Grid thegrid;
    public Tilemap tmap;
    public List<Tilemap> objectlayers;
    public GameObject Nodefab;

    //Map Bounds
    public int scanStartX;
    public int scanEndX;
    public int scanStartY;
    public int scanEndY;

    //Nodes that Interact
    public List<GameObject> allnodes;
    public GameObject[,] nodegrid;
	// Use this for initialization
	void Awake () {
        //initialize allnodes
        allnodes = new List<GameObject>();
	}
	
    public void generateNodes()
    {
        //what you call to actually make nodes
        //createNodes();
    }

	// Update is called once per frame
	void Update () {
		
	}

    void createNodes()
    {

    }
}
