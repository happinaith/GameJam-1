using UnityEngine;

public class Node
{
    public int type = 0; // 0 - проходимая нода, 1 - препятствие
    public Vector3 worldPosition;

    public Node fromNode;

    public int gCost;
    public int hCost;
    public float fCost()
    {
        return gCost + hCost;
    }

    public Node(int type, Vector3 worldPosition)
    {
        this.type = type;
        this.worldPosition = worldPosition;
    }
}
