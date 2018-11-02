using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arraybuild : MonoBehaviour {
    public int gridx;
    public int gridy;
    public Node[,] theArray;

    float thePrice = 0f;
    int tileType = 0;

    void buildArray(int tileType)
    {
        for (int x = 0; x <= gridx; x++)
{
            for (int y = 0; y <= (gridy) ; y++)
          {

                if (x == 1 && y == 1)
                {
                    tileType = 0;
                    Node theNode = new Node(theCost(tileType), x, y, canWalk(tileType));
                    theArray[x, y] = theNode;
                }

                if (x == 2 && y == 2)
                {
                    tileType = 0;
                    Node theNode = new Node(theCost(tileType), x, y, canWalk(tileType));
                    theArray[x, y] = theNode;
                }
                else
                {
                    tileType = 1;
                    Node theNode = new Node(theCost(tileType), x, y, canWalk(tileType));
                    theArray[x, y] = theNode;
                }


                
            }
        }
    }


    bool canWalk(int tileType)
    {
        bool walk = false;
        if (tileType == 0)
        {
            walk = false;
        }
        else if (tileType == 1)
        {
            walk = true;
        }
        else if (tileType == 2)
        {
            walk = true;
        }
        return walk;
    }

    float theCost(int tileType)
    {
        float cost = 0f;
        if (tileType == 0)
        {
            cost = 0.0f;
        }
        else if (tileType == 1)
        {
            cost = 1.0f;
        }
        else if (tileType == 2)
        {
            cost = 2.0f;
        }
        return cost;
    }
}
