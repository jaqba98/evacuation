using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoadSimulation : MonoBehaviour {
    public void Awake() {
        string simulationFilePath = PlayerPrefs.GetString("simulationFilePath");
        string simulationType = PlayerPrefs.GetString("simulationType");
        if (simulationType == "create") {
            OnCreate(simulationFilePath);
            return;
        }
        if (simulationType == "delete") {
            OnDelete(simulationFilePath);
            return;
        }
        if (simulationType == "edit") {
            OnEdit(simulationFilePath);
            return;
        }
        if (simulationType == "start") {
            OnStart(simulationFilePath);
        }
    }

    private void OnCreate(string simulationFilePath) {
        SimulationDomain newSimulationDomain = new SimulationDomain(
            simulationFilePath,
            Vector3.zero,
            Vector3.zero,
            new List<SegmentDomain>(),
            0,
            10
        );
        string simulationDomainJson = JsonUtility.ToJson(newSimulationDomain);
        PlayerPrefs.SetString("simulationDomain", simulationDomainJson);
        SceneManager.LoadScene("EditSimulation");
    }

    private void OnDelete(string simulationFilePath) {}

    private void OnEdit(string simulationFilePath) {}

    private void OnStart(string simulationFilePath) {}
}
