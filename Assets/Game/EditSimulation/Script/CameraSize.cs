using UnityEngine;

public class CameraSize : MonoBehaviour {
    public SimulationStore simulationStore;
    public EditSimulation editSimulation;
    public DomainManager domainManager;
    public Camera mainCamera;

    public void Init() {
        simulationStore.cameraSize = domainManager.simulationDomain.cameraSize;
    }

    public void Reload() {
        mainCamera.orthographicSize = simulationStore.cameraSize;
    }

    public void Plus() {
        if (simulationStore.cameraSize > 10) {
            simulationStore.cameraSize -= 5;
            editSimulation.Reload();
        }
    }

    public void Minus() {
        if (simulationStore.cameraSize < 100) {
            simulationStore.cameraSize += 5;
            editSimulation.Reload();
        }
    }
}
