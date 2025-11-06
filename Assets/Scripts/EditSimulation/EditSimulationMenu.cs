using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class EditSimulationMenu : MonoBehaviour {
    public SimulationStore simulationStore;

    [Header("Services")]
    public Signal signal;
    public Cursor cursor;
    public Chooser chooser;
    public Rotate rotate;
    public Segments segments;
    public PositionPanel positionPanel;

    public void Start() {
        Reload();
    }

    public void Reload() {
        segments.Reload();
        signal.Reload();
        cursor.Reload();
        chooser.Reload();
        rotate.Reload();
        positionPanel.Reload();
    }

    public void Save() {
        SimulationDomain newSimulationDomain = new SimulationDomain {
            simulationName = simulationStore.simulationDomain.simulationName,
            cursorPositionX = simulationStore.cursorPositionX,
            cursorPositionZ = simulationStore.cursorPositionZ,
            cursorRotation = simulationStore.cursorRotation,
            segments = simulationStore.segmentsDomain
        };
        string json = JsonUtility.ToJson(newSimulationDomain, true);
        string filePath = newSimulationDomain.simulationName;
        if (!Path.IsPathRooted(filePath)) {
            filePath = Path.Combine(Application.persistentDataPath, filePath + ".json");
        }
        try {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, json);
            Debug.Log($"Simulation saved successfully to: {filePath}");
        } catch (System.Exception ex) {
            Debug.LogError($"Failed to save simulation: {ex.Message}");
        }
    }

    public void Exit() {
        SceneManager.LoadScene("MainMenu");
    }
}
