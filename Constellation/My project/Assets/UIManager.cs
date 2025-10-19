using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    public GameObject optionsMenuPanel; // assign your panel here
    public GameObject inputBlock;
    public GameObject hoverPanel;
    public TMP_Text hoverText;
    private RectTransform hoverPanelRect;


    private void Start()
    {
        hoverPanelRect = hoverPanel.GetComponent<RectTransform>();
        hoverPanel.SetActive(false);
    }
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Physics.Raycast(ray, out RaycastHit hit);
        // Check for right-click (mouse or gamepad equivalent)
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            // Raycast from mouse into the 3D world

            if (!(hit.collider.CompareTag("Star")))
            {
                // Nothing was hit, open the menu
                optionsMenuPanel.SetActive(true);

                // Convert screen position to local position in this canvas
                RectTransform rt = optionsMenuPanel.GetComponent<RectTransform>();
                Vector2 localPoint;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    transform as RectTransform,      // the canvas itself
                    Mouse.current.position.ReadValue(),
                    null,
                    out localPoint
                );
                rt.localPosition = localPoint;
            }

        }

        if (hoverPanel.activeSelf)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            hoverPanelRect.position = mousePos + new Vector2(10, -10);
        }

        


    }

    public void CloseMenuNextFrame()
    {
        StartCoroutine(CloseMenuDelayed());
    }

    private IEnumerator CloseMenuDelayed()
    {
        yield return null; // wait one frame
        yield return new WaitForEndOfFrame();
        optionsMenuPanel.SetActive(false);
    }

    public void blockMouse()
    {
        inputBlock.SetActive(true);
    }

    public void unblockInput()
    {
        inputBlock.SetActive(false);
    }

    public void ShowTask(string text)
    {
        hoverText.text = text;
        hoverPanel.SetActive(true);
    }

    public void HideTask()
    {
        hoverPanel.SetActive(false);
    }

}
