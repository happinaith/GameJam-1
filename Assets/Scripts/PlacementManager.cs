using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] GameObject mouseIndicator, cellIndicator;
    [SerializeField] InputManager inputManager;
    [SerializeField] Grid grid;

    void Update()
    {
        Vector3 mousePos = inputManager.GetSelectedPathPosition();
        Vector3Int cellPos = grid.WorldToCell(mousePos);
        mouseIndicator.transform.position = mousePos;
        cellIndicator.transform.position = grid.CellToWorld(cellPos);
    }
}
