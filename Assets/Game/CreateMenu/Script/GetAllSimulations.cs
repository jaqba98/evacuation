using UnityEngine;
using System.IO;
using System.Linq;

public class GetAllSimulations : MonoBehaviour {
    public string[] GetSimulations() {
        string path = Path.Combine(Application.dataPath, "simulations");
        if (Directory.Exists(path)) {
            return Directory.GetFiles(path, "*.json")
                .Select(file => Path.GetFileNameWithoutExtension(file))
                .ToArray();
        } else {
            return new string[0];
        }
    }
}
