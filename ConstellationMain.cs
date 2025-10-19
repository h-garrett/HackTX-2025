using UnityEngine;
using System.IO;

public class ConstellationController : MonoBehaviour
{
    // The C# script that handles launching the Python process
    public PyStar PyStarLauncher; 
    
    // The absolute path to the JSON file (matches PyStar.jsonPath)
    [SerializeField] private string jsonFilePath = @"C:\Users\garre\GitHub\HackTX-2025\starData.json";

    private ConstellationManager currentConstellation;

    // Call this method from another Unity script (e.g., a UI button press) 
    // to trigger the entire cycle.
    public void StartLoadProcess()
    {
        // 1. Run the external Python script first.
        //    The Python script handles the Load -> Sort -> Save cycle itself.
        //    This ensures the JSON file is sorted/updated BEFORE C# reads it.
        if (PyStarLauncher != null)
        {
            PyStarLauncher.RunPythonScript();
        }
        else
        {
            Debug.LogError("PyStarLauncher is not assigned. Cannot run Python script.");
            return;
        }

        // 2. Wait a small moment for the Python process to finish writing the file.
        //    (In a real game, you might use a callback or file watcher instead of WaitForSeconds)
        StartCoroutine(LoadConstellationDelayed());
    }

    private System.Collections.IEnumerator LoadConstellationDelayed()
    {
        // Give Python a moment to write the file completely. 
        // This is a common pattern when dealing with external processes.
        yield return new WaitForSeconds(0.2f); 

        // 3. C# now loads the final, processed data.
        currentConstellation = ConstellationManager.LoadFromJson(jsonFilePath);

        // 4. Equivalent to Python's "if Constellation1 is not None:" check
        if (currentConstellation != null)
        {
            Debug.Log($"Successfully loaded {currentConstellation.StarList.Count} stars into C# memory.");
            // Example: Do something with the loaded data in C#
            // Example: currentConstellation.Name = "Orion"; 
        }
        else
        {
            Debug.LogError("🛑 Failed to load Constellation data into C# memory (File might be corrupted or missing).");
            // If the load failed, 'currentConstellation' is null, and C# should handle the error.
        }
    }
    
   
    public void LoadProcessAndSave_CsharpOnly()
    {
        // 1. Load: Equivalent to Constellation1 = Constellation.load_from_json(json_file_path)
        ConstellationManager loadedConstellation = ConstellationManager.LoadFromJson(jsonFilePath);
        
        // 2. Check: Equivalent to if Constellation1 is not None:
        if (loadedConstellation != null)
        {
            // (Process/modify the data here)
            
            // 3. Save: Equivalent to Constellation1.save_to_json(json_file_path)
            loadedConstellation.SaveToJson(jsonFilePath);
        }
        else
        {
            Debug.LogWarning("Load failed, skipping save.");
        }
    }
    
}