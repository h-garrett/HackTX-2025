using UnityEngine;
using UnityEngine.InputSystem; // if you’re using the new Input System
using UnityEngine.UI;
using TMPro;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab; // Assign in Inspector
    public GameObject contextMenuPanel;
    public GameObject taskInputPanel;
    public GameObject eventSystem;
    public TMP_InputField taskInput;
    private string task;
    private bool typing;

    private bool isPlacing = false;

    // Called by the UI Button
    public void EnablePlacement()
    {
        taskInputPanel.SetActive(false); // called after a task is entered.
        isPlacing = true;
        Debug.Log("Placement mode activated!");
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (taskInputPanel.activeSelf)
            {
                EnablePlacement();
            }

            // Call your submit function here
        }

        if (isPlacing && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject newStarGO = Instantiate(starPrefab, hit.point, Quaternion.identity);
                Star newStar = newStarGO.GetComponent<Star>();
                newStar.setTask(taskInput.text);
                isPlacing = false; 
                Debug.Log("Star placed!");
            }
        }
    }

    public void getTask()
    {
        contextMenuPanel.SetActive(false);
        taskInput.text = "";
        typing = true;
        taskInputPanel.SetActive(true);
        taskInput.ActivateInputField();
        isPlacing = false;
    }



}
