using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class StarList : MonoBehaviour
{
    public List<StarData> stars = new List<StarData>();
    public static StarList Instance;
    private string jsonPath;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // Save JSON in Assets folder (editor only) or use persistentDataPath for builds
        jsonPath = Path.Combine(Application.dataPath, "starData.json");
        Debug.Log("saved to" + Application.dataPath);
    }

    public void AddStar(Star star)
    {
        StarData data = new StarData();
        data.x = star.x;
        data.y = star.y;
        data.task = star.task;
        stars.Add(data);
        Debug.Log("Star added: " + star.task);

        SaveToJson();
    }


    private void SaveToJson()
    {
        StarList wrapper = new StarList { stars = stars };
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(jsonPath, json);
        Debug.Log("Stars saved to JSON at " + jsonPath);
    }

    public void LoadFromJson()
    {
        if (!File.Exists(jsonPath)) return;

        string json = File.ReadAllText(jsonPath);
        StarList wrapper = JsonUtility.FromJson<StarList>(json);
        stars = wrapper.stars;
    }

}

