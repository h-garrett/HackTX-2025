using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject contextMenuPanel; // assign your panel here

    void Update()
    {
        // Check for right-click (mouse or gamepad equivalent)
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            // Raycast from mouse into the 3D world
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (!Physics.Raycast(ray, out RaycastHit hit))
            {
                // Nothing was hit, open the menu
                contextMenuPanel.SetActive(true);

                // Convert screen position to local position in this canvas
                RectTransform rt = contextMenuPanel.GetComponent<RectTransform>();
                Vector2 localPoint;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    transform as RectTransform,      // the canvas itself
                    Mouse.current.position.ReadValue(),
                    null,                             // null works if canvas is Screen Space - Overlay
                    out localPoint
                );
                rt.localPosition = localPoint;
            }
            else
            {
                // If clicked on an object, optionally close the menu
                contextMenuPanel.SetActive(false);
            }
        }

        if (Mouse.current.leftButton.wasPressedThisFrame && contextMenuPanel.activeSelf)
        {
            contextMenuPanel.SetActive(false);
        }
    }
}
