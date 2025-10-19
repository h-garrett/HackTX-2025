using UnityEngine;

public class Star : MonoBehaviour
{
    public float x;
    public float y;
    public string task;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        x = transform.position.x;
        y = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTask(string task)
    {
        this.task = task;
        StarList.Instance.AddStar(this);
    }

    public void wasClicked()
    {
        Debug.Log("This Star was clicked!");
    }
}
