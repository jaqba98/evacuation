using UnityEngine;
using System.IO;
using System.Linq;

public class FileTool : MonoBehaviour {
    public string[] GetSimulationMapFiles() {
        string rootPath = GetSimulationMapRootPath();
        if (Directory.Exists(rootPath)) {
            string fileName = BuildSimulationMapFileName("*");
            return Directory.GetFiles(rootPath, fileName);
        } else {
            return new string[0];
        }
    }

    public string BuildSimulationMapFileName(string fileName) {
        return $"{fileName}.json";
    }

    public string BuildSimulationMapFilePath(string name) {
        string rootPath = GetSimulationMapRootPath();
        string fileName = BuildSimulationMapFileName(name);
        return Path.Combine(rootPath, fileName);
    }

    private string GetSimulationMapRootPath() {
        return Path.Combine(Application.dataPath, "data", "simulation", "map");
    }
}
