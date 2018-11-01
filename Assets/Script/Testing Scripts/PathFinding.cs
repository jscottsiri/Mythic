using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour {
    public Transform seeker, target;
    Grid grid;
    int diagonal = 14;
    int straight = 10;
    void Awake()
    {
        grid = GetComponent<Grid>();
    }
    void Update()
    {
        FindPath(seeker.position, target.position);
    }

    void FindPath( Vector3 startpos,Vector3 targetpos)
    {
        TileStats startNode = grid.NodeFromWorldPoint(startpos);
        TileStats targetNode = grid.NodeFromWorldPoint(targetpos);

        List<TileStats> openSet = new List<TileStats>();
        HashSet<TileStats> closedSet = new HashSet<TileStats>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            TileStats currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost==currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                return;
            }
            foreach (TileStats neighbour in grid.GetNeighbors(currentNode))
            {
                if (!neighbour.walkable || closedSet.Contains(neighbour))
                {
                    continue;
                }
                int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
                
            }
        }
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
        grid.path = path;
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
