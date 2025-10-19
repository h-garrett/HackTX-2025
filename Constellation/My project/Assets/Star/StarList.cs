using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class StarList : MonoBehaviour
{
    public List<StarData> stars;
    public static StarList Instance;
    private string jsonPath;
    public PyStar py;
    private Coroutine LoadCoroutine;

    [System.Serializable]
    public class StarDataList
    {
        public List<StarData> starsData = new List<StarData>();
    }


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // Save JSON in Assets folder (editor only) or use persistentDataPath for builds
        jsonPath = @"C:\Users\garre\GitHub\HackTX-2025\data\starData.json";
        Debug.Log("saved to" + jsonPath);
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
        if (LoadCoroutine != null)
        {
            StopCoroutine(LoadDelayed());
        }
        StartCoroutine(LoadDelayed());
    }

    private IEnumerator LoadDelayed()
    {
        yield return new WaitForSeconds(0.1f);
        LoadFromJson();
    }


    private void SaveToJson()
    {
        StarDataList wrapper = new StarDataList();
        foreach (StarData starData in stars)
        {
            wrapper.starsData.Add(new StarData
            {
                x = starData.x,
                y = starData.y,
                task = starData.task
            });
        }

        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(jsonPath, json);
        Debug.Log("Stars saved to JSON at " + jsonPath);
    }

    public void LoadFromJson()
    {
        if (!File.Exists(jsonPath)) return;

        py.RunPythonScript(); // Optional: run Python first

        string json = File.ReadAllText(jsonPath);

        // Deserialize into the plain wrapper class, NOT the MonoBehaviour
        StarDataList wrapper = JsonUtility.FromJson<StarDataList>(json);

        // Assign the deserialized data back to your stars list
        stars = wrapper.starsData;
    }

}

