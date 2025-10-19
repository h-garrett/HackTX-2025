using UnityEngine;

public class Star : MonoBehaviour
{
    public float x;
    public float y;
    public string task;
    public bool hovered;

    private Material mat;
    private Color baseEmissionColor;
    public float glowIntensity = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        baseEmissionColor = mat.GetColor("_EmissionColor");
    }
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

    public void setHovered(bool hovered)
    {
        if (hovered)
        {
            mat.SetColor("_EmissionColor", baseEmissionColor * Mathf.LinearToGammaSpace(glowIntensity));
        }
        else
        {
            mat.SetColor("_EmissionColor", baseEmissionColor);
        }
    }
}
