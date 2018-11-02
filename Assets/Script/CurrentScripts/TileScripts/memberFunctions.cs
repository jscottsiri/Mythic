using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memberFunctions : MonoBehaviour {
    public int sizeX;
    public int sizeY;
    public static Node[,] noderay;

    void Awake()
    {
        noderay = new Node[sizeX,sizeY];
    }
    // Use this for initialization
    void Start () {
		for (int x = 0; x > sizeX; x++)
        {
            for (int y = 0; y > sizeY; y++)
            {
                if (x != 5 && y != 5)
                {
                    noderay[x, y] = new Node(1.0f, sizeX, sizeY, true);
                }
                else
                {
                    noderay[x, y] = new Node(0.0f, sizeX, sizeY, true);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
