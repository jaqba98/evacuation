using UnityEngine;
using System.IO;

public class FileManager : MonoBehaviour {
    public void CreateRootFolder() {
        string rootPath = Path.Combine(Application.dataPath, "maps");
        if (!Directory.Exists(rootPath)) {
            Directory.CreateDirectory(rootPath);
        }
    }

    public void SaveObjectToJson<T>(T obj, string fileName) {
        string rootPath = Path.Combine(Application.dataPath, "maps");
        string json = JsonUtility.ToJson(obj, true);
        string filePath = Path.Combine(rootPath, $"{fileName}.json");
        Debug.Log(filePath);
        File.WriteAllText(filePath, json);
    }

    public string ReadFileFromJson(string fileName) {
        string rootPath = Path.Combine(Application.dataPath, "maps");
        string filePath = Path.Combine(rootPath, $"{fileName}.json");
        if (File.Exists(filePath)) {
            string jsonContent = File.ReadAllText(filePath);
            return jsonContent;
        }
        else {
            Debug.LogWarning($"File not found at path: {filePath}");
            return null;
        }
    }
}
