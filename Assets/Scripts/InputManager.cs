using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask interactableLayerMask;
    private Vector3 lastPos;

    public Vector3 GetSelectedPathPosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = camera.nearClipPlane;

        Ray ray = camera.ScreenPointToRay(mousePos);
        RaycastHit raycast;

        if (Physics.Raycast(ray, out raycast, 500, interactableLayerMask))
        {
            lastPos = raycast.point;
        }

        return lastPos;
    }
}
