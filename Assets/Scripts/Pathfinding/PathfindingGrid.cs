using NUnit.Framework.Internal;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class PathfindingGrid : MonoBehaviour
{
    // настройки визуализации
    public bool ShowGrid = true;
    public float VisualisedNodeSize = .25f;

    //
    public Grid UnityGrid;
    public GameObject MouseIndicator;
    public Vector2Int[] neighPos = new Vector2Int[] {
        new Vector2Int(0,1),
        new Vector2Int(1,1),
        new Vector2Int(1,0),
        new Vector2Int(1,-1),
        new Vector2Int(0,-1),
        new Vector2Int(-1,-1),
        new Vector2Int(-1,0),
        new Vector2Int(-1,1)
    };

    //
    public LayerMask UnwalkableMask;
    public Vector2Int WorldGridSize;
    public float NodeSize;
    Node[,] grid;


    public int Test;
    public Node NodeFromWorldPoint(Vector3 worldPoint)
    {
        int percentX = Mathf.FloorToInt((-worldPoint.x / (transform.position.x - WorldGridSize.x)) / NodeSize * WorldGridSize.x);
        int percentY = Mathf.FloorToInt((-worldPoint.z / (transform.position.z - WorldGridSize.y)) / NodeSize * WorldGridSize.y);
        Test = percentX;
        return grid[percentX + WorldGridSize.x/2, percentY + WorldGridSize.y/2];
    }

    private Node[] GetNeighbours(Vector2Int nodePos)
    {
        Node[] neighbours = new Node[8];

        for (int i = 0; i < 9; i++)
        {
            Vector2Int neighp = neighPos[i];
            int neighX = nodePos.x + neighp.x;
            int neighY = nodePos.y + neighp.y;
            if ((0 <= neighX & neighX <= WorldGridSize.x) & (0 <= neighY & neighY <= WorldGridSize.y))
            {
                neighbours[i] = grid[neighX, neighY];
            }
        }
        
        return neighbours;
    }

    public void GenerateGrid()
    {
        grid = new Node[WorldGridSize.x, WorldGridSize.y];
        for (int x = 0; x < WorldGridSize.x; x++)
        {
            for (int y = 0; y < WorldGridSize.y; y++)
            {
                Vector3 pos = new Vector3(x - WorldGridSize.x / 2 + NodeSize / 2, 0, y - WorldGridSize.y / 2 + NodeSize / 2);
                int type = Physics.CheckSphere(pos, NodeSize, UnwalkableMask) ? 1 : 0;
                grid[x,y] = new Node(type, pos);
            }
        }
    }

    public void Path(Vector3 start, Vector3 end)
    {
        Node startNode = NodeFromWorldPoint(start);
        Node EndNode = NodeFromWorldPoint(end);

        Node[] neighbours = GetNeighbours(startNode);
        for (int i = 0; i < 9; i++)
        {
            
        }
    }

    public void Start()
    {
        GenerateGrid();
    }

    private void OnDrawGizmos()
    {
        if (grid == null) { return; }
        foreach (Node node in grid)
        {
            Gizmos.color = node.type == 0 ? Color.green : Color.red;
            Gizmos.color = NodeFromWorldPoint(MouseIndicator.transform.position) == node ? Color.blueViolet : Gizmos.color; 
            Gizmos.DrawCube(node.worldPosition, VisualisedNodeSize*Vector3.one);
        }
    }
}
