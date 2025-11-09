using UnityEngine;
using System.IO;

public class DomainManager : MonoBehaviour {
    public SimulationStore simulationStore;
    public SimulationDomain simulationDomain;

    public void PreInit() {
        string simulationDomainJson = PlayerPrefs.GetString("simulationDomain");
        simulationDomain = JsonUtility.FromJson<SimulationDomain>(simulationDomainJson);
    }

    public void Save() {
        SimulationDomain newSimulationDomain = new SimulationDomain(
            simulationStore.path,
            simulationStore.cursorPosition,
            simulationStore.cursorRotation,
            simulationStore.segmentDomains,
            simulationStore.currentSegmentIndex,
            simulationStore.cameraSize
        );
        string json = JsonUtility.ToJson(newSimulationDomain, true);
        string filePath = newSimulationDomain.path;
        try {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, json);
        } catch (System.Exception ex) {
            Debug.LogError($"Failed to save simulation: {ex.Message}");
        }
    }
}
