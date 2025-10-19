using System.Collections.Generic;
using UnityEngine;
using System.IO;

// Wrapper class for JsonUtility to handle lists at the root level
[System.Serializable]
public class ConstellationDataWrapper
{
    public List<StarData> stars = new List<StarData>();
}

public class ConstellationManager 
{
    // Data fields
    public string Name { get; private set; } = "";
    public List<StarData> StarList { get; private set; } = new List<StarData>();

    // Constructor equivalent to __init__
    public ConstellationManager() 
    {
        // Initialization done above
    }

    // Equivalent to __repr__
    public override string ToString()
    {
        return $"Constellation Name: {Name} with Stars: {StarList.Count} stars";
    }
    
    // Equivalent to add_star
    public void AddStar(StarData star)
    {
        StarList.Add(star);
        // Apply the sort after adding
        StarList = StarSorter.SortStars(StarList);
    }
    
    // Equivalent to remove_star
    public void RemoveStar(StarData star)
    {
        if (!StarList.Contains(star))
        {
            Debug.Log($"Star {star} not found in constellation.");
            return;
        }
        StarList.Remove(star);
        // Apply the sort after removing
        StarList = StarSorter.SortStars(StarList);
    }
    
    // Equivalent to get_star
    public StarData GetStar(int index)
    {
        if (index < 0 || index >= StarList.Count)
        {
            throw new IndexOutOfRangeException("Star index out of range");
        }
        return StarList[index];
    }
    
    // Equivalent to get_all_stars
    public List<StarData> GetAllStars()
    {
        return StarList;
    }
    
    // Equivalent to set_name
    public void SetName(string name)
    {
        Name = name;
    }
    
    // Equivalent to to_dict (C# serialization via the wrapper class)
    public ConstellationDataWrapper ToWrapper()
    {
        return new ConstellationDataWrapper { stars = StarList };
    }

    // Equivalent to save_to_json
    public void SaveToJson(string filename)
    {
        ConstellationDataWrapper wrapper = ToWrapper();
        string json = JsonUtility.ToJson(wrapper, true);
        
        try
        {
            File.WriteAllText(filename, json);
            Debug.Log($"✅ Constellation saved to {filename}");
        }
        catch (Exception e)
        {
            Debug.LogError($"❌ Error saving JSON: {e.Message}");
        }
    }

    // Equivalent to load_from_json (C# static factory method)
    public static ConstellationManager LoadFromJson(string filename)
    {
        ConstellationManager manager = new ConstellationManager();
        
        if (!File.Exists(filename))
        {
            Debug.LogWarning($"⚠️ File not found at path: {filename}. Starting new constellation.");
            return manager; // Return new, empty object
        }

        try
        {
            string json = File.ReadAllText(filename);
            
            // Try to deserialize directly into the wrapper
            ConstellationDataWrapper wrapper = JsonUtility.FromJson<ConstellationDataWrapper>(json);

            // Check for deserialization success (JsonUtility doesn't throw, 
            // but returns default/null on malformed data)
            if (wrapper != null && wrapper.stars != null)
            {
                // Assign and then sort (Fix 3 confirmation)
                manager.StarList = wrapper.stars;
                manager.StarList = StarSorter.SortStars(manager.StarList);
                
                Debug.Log($"✅ Loaded constellation with {manager.StarList.Count} stars from {filename}");
                return manager;
            }
            else
            {
                // This catches structurally invalid JSON that JsonUtility couldn't parse
                Debug.LogError($"❌ ERROR decoding JSON at: {filename}. File is structurally corrupted.");
                return null; // Equivalent to Python's 'return None' on corruption
            }
        }
        catch (Exception e)
        {
            // Catches file IO errors
            Debug.LogError($"❌ ERROR reading file: {e.Message}");
            return null; // Return null on critical failure
        }
    }
}