using UnityEngine;
using System.Collections.Generic;

    public class Node:MonoBehaviour
    {
        // node starting params
        public int gridX;
        public int gridY;
        public float penalty;
    public bool walkable;
        // calculated values while finding path
        public int gCost;
        public int hCost;
        public int terraincost;
        public Node parent;

        // create the node
        // _price - how much does it cost to pass this tile. less is better, but 0.0f is for non-walkable.
        // _gridX, _gridY - tile location in grid.
        public Node(float _price, int _gridX, int _gridY)
        {
            penalty = _price;
            gridX = _gridX;
            gridY = _gridY;
        if (penalty <= 0.0f)
        {
            walkable = false;
        }
        else
        {
            walkable = true;
        }
        }

        public int fCost
        {
            get
            {
                return gCost + hCost;
            }
        }
    }