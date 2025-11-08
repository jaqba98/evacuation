using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadSimulation : MonoBehaviour {
    void Awake() {
        string simulationName = PlayerPrefs.GetString("simulationName");
        string simulationType = PlayerPrefs.GetString("simulationType");
        if (simulationType == "create") {
            OnCreate(simulationName, simulationType);
            return;
        }
        if (simulationType == "start") {
            OnStart(simulationName, simulationType);
            return;
        }
        if (simulationType == "edit") {
            OnEdit(simulationName, simulationType);
            return;
        }
    }

    private void OnCreate(string simulationName, string simulationType) {
        SimulationDomain newSimulationDomain = new SimulationDomain();
        newSimulationDomain.simulationName = simulationName;
        newSimulationDomain.cursorPositionX = 0;
        newSimulationDomain.cursorPositionZ = 0;
        newSimulationDomain.cursorRotation = 0;
        newSimulationDomain.cameraSize = 10;
        newSimulationDomain.segments = new List<SegmentDomain>();
        string json = JsonUtility.ToJson(newSimulationDomain);
        PlayerPrefs.SetString("simulationData", json);
        SceneManager.LoadScene("EditSimulation");
    }

    private void OnStart(string simulationName, string simulationType) {
        if (File.Exists(simulationName)) {
            string json = File.ReadAllText(simulationName);
            PlayerPrefs.SetString("simulationData", json);
        } else {
            SceneManager.LoadScene("MainMenu");
        }
        SceneManager.LoadScene("StartSimulation");
    }

    private void OnEdit(string simulationName, string simulationType) {
        if (File.Exists(simulationName)) {
            string json = File.ReadAllText(simulationName);
            PlayerPrefs.SetString("simulationData", json);
        } else {
            SceneManager.LoadScene("MainMenu");
        }
        SceneManager.LoadScene("EditSimulation");
    }
}
