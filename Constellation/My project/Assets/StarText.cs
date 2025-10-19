using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StarText : MonoBehaviour
{
    private TMP_Text taskLabel;
    private string task;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        taskLabel = GetComponent<TMP_Text>();
        task = GetComponent<Star>().task;
        taskLabel.text = task;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
