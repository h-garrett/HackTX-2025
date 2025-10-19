using System.Diagnostics;
using System.IO;
using UnityEngine;

public class PyStar : MonoBehaviour
{

    public string pythonPath = @"C:\Users\garre\AppData\Local\Python\bin\python.exe";
    public string scriptPath = @"C:\Users\garre\GitHub\HackTX-2025\constellation_main.py";
    public string jsonPath = @"C:\Users\garre\GitHub\HackTX-2025\starData.json";
    public void RunPythonScript()
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = pythonPath;
        psi.Arguments = $"\"{scriptPath}\" \"{jsonPath}\"";
        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;

        using (Process process = Process.Start(psi))
        {
            string output = process.StandardOutput.ReadToEnd();
            string errors = process.StandardError.ReadToEnd();
            process.WaitForExit();

            UnityEngine.Debug.Log($"Python output:\n{output}");
            if (!string.IsNullOrEmpty(errors))
                UnityEngine.Debug.LogError($"Python errors:\n{errors}");
        }

        UnityEngine.Debug.Log("Python script finished running.");
    }
}

