using UnityEngine;

public class SimulationCommon : MonoBehaviour {
    public SimulationStore simulationStore;
    public DomainManager domainManager;

    public void Init() {
        simulationStore.segmentSize = 4.0f;
        simulationStore.path = domainManager.simulationDomain.path;
        simulationStore.maxCursorPositionLeft = -496;
        simulationStore.maxCursorPositionRight = 500;
        simulationStore.maxCursorPositionUp = 500;
        simulationStore.maxCursorPositionDown = -496;
    }
}
